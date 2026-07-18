using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Competition
{
    public int Year;
    public int Week;

    public float FirstPlacePrize = 500;
    public float SecondPlacePrize = 250;
    public float ThirdPlacePrize = 100;
    public float EntryFee = 50f;

    public List<Athlete> RegisteredAthletes { get; private set; } = new();


    public virtual string CompetitionName =>
        "Competition";

    public virtual string Description =>
        "No description.";

    public bool HasBeenRun;


    public (List<CompetitionResult> overallResults,
            List<CompetitionResult> totalResults,
            float totalPrizeMoney) RunCompetition()
    {
        List<CompetitionResult> allResults = new();


        Dictionary<WeightClass, List<Athlete>> groups = new();

        List<Athlete> participants = new();

        participants.AddRange(
            RegisteredAthletes
        );

        participants.AddRange(
            GameManager.Instance.CurrentState.WorldAthletes
        );


        foreach (Athlete athlete in participants)
        {
            WeightClass weightClass = athlete.GetWeightClass();

            if (!groups.ContainsKey(weightClass))
                groups[weightClass] = new();

            groups[weightClass].Add(athlete);
        }



        foreach (var group in groups)
        {
            List<CompetitionResult> classResults = new();


            foreach (Athlete athlete in group.Value)
            {
                float[] squatAttempts =
                    athlete.GetCompetitionAttempts(athlete.Squat);

                float[] benchAttempts =
                    athlete.GetCompetitionAttempts(athlete.Bench);

                float[] deadliftAttempts =
                    athlete.GetCompetitionAttempts(athlete.Deadlift);


                CompetitionResult result = new()
                {
                    Athlete = athlete,
                    WeightClass = group.Key,

                    BestSquat = squatAttempts[2],
                    BestBench = benchAttempts[2],
                    BestDeadlift = deadliftAttempts[2]
                };


                result.Total =
                    result.BestSquat +
                    result.BestBench +
                    result.BestDeadlift;


                result.Dots =
                    CalculateDots(
                        athlete.Weight,
                        result.Total
                    );


                classResults.Add(result);
            }



            classResults.Sort((a, b) =>
                b.Total.CompareTo(a.Total));


            for (int i = 0; i < classResults.Count; i++)
                classResults[i].Place = i + 1;


            AssignWeightClassPrizeMoney(classResults);

            allResults.AddRange(classResults);
        }



        List<CompetitionResult> overallResults =
            allResults
            .OrderByDescending(x => x.Dots)
            .ToList();


        for (int i = 0; i < overallResults.Count; i++)
            overallResults[i].OverallPlace = i + 1;


        AssignOverallPrizeMoney(overallResults);



        List<CompetitionResult> totalResults =
            allResults
            .OrderByDescending(x => x.Total)
            .ToList();



        AwardPlayerPrizeMoney(overallResults);



        SaveAthleteCompetitionHistory(overallResults);

        HasBeenRun = true;


        return (
            overallResults,
            totalResults,
            0
        );
    }



    private void AssignWeightClassPrizeMoney(List<CompetitionResult> results)
    {
        foreach (CompetitionResult result in results)
        {
            switch (result.Place)
            {
                case 1:
                    result.WeightClassPrizeMoney = FirstPlacePrize;
                    break;

                case 2:
                    result.WeightClassPrizeMoney = SecondPlacePrize;
                    break;

                case 3:
                    result.WeightClassPrizeMoney = ThirdPlacePrize;
                    break;

                default:
                    result.WeightClassPrizeMoney = 0;
                    break;
            }
        }
    }



    private void AssignOverallPrizeMoney(List<CompetitionResult> results)
    {
        foreach (CompetitionResult result in results)
        {
            switch (result.OverallPlace)
            {
                case 1:
                    result.OverallPrizeMoney = FirstPlacePrize;
                    break;

                case 2:
                    result.OverallPrizeMoney = SecondPlacePrize;
                    break;

                case 3:
                    result.OverallPrizeMoney = ThirdPlacePrize;
                    break;

                default:
                    result.OverallPrizeMoney = 0;
                    break;
            }
        }
    }



    private void AwardPlayerPrizeMoney(List<CompetitionResult> results)
    {
        foreach (CompetitionResult result in results)
        {
            if (result.Athlete.Owner == AthleteOwner.Player)
            {
                float prizeMoney = result.PrizeMoney;


                if (prizeMoney > 0)
                {
                    GameManager.Instance.FinanceManager.AddIncome(
                        FinanceEntryType.PrizeMoney,
                        prizeMoney,
                        true
                    );
                }
            }
        }
    }



    private float CalculateDots(float bodyWeight, float total)
    {
        float coefficient =
            500f /
            (
                -0.0000010930f * Mathf.Pow(bodyWeight, 4)
                + 0.0007391293f * Mathf.Pow(bodyWeight, 3)
                - 0.1918759221f * Mathf.Pow(bodyWeight, 2)
                + 24.0900756f * bodyWeight
                - 307.75076f
            );

        return total * coefficient;
    }



    public int WeeksUntil()
    {
        GameTime time =
            GameManager.Instance.CurrentState.GameTime;


        int currentWeek =
            time.Year * 52 + time.Week;


        int competitionWeek =
            Year * 52 + Week;


        return competitionWeek - currentWeek;
    }



    private void SaveAthleteCompetitionHistory(List<CompetitionResult> results)
    {
        foreach (CompetitionResult result in results)
        {
            Athlete athlete = result.Athlete;


            AthleteCompetitionResult history =
                new AthleteCompetitionResult
                {
                    CompetitionName = CompetitionName,

                    Year = Year,
                    Week = Week,

                    Age = athlete.Age,
                    BodyWeight = athlete.Weight,

                    OverallRank = result.OverallPlace,
                    WeightClassRank = result.Place,

                    Dots = result.Dots,

                    Total = result.Total,

                    Squat = result.BestSquat,
                    Bench = result.BestBench,
                    Deadlift = result.BestDeadlift,

                    OverallPrizeMoney = result.OverallPrizeMoney,

                    WeightClassPrizeMoney = result.WeightClassPrizeMoney,

                    TotalPrizeMoney =
                        result.OverallPrizeMoney +
                        result.WeightClassPrizeMoney
                };


            athlete.CompetitionHistory.Add(history);


            athlete.BestCompetitionSquat =
                Mathf.Max(athlete.BestCompetitionSquat, result.BestSquat);

            athlete.BestCompetitionBench =
                Mathf.Max(athlete.BestCompetitionBench, result.BestBench);

            athlete.BestCompetitionDeadlift =
                Mathf.Max(athlete.BestCompetitionDeadlift, result.BestDeadlift);

            athlete.BestCompetitionTotal =
                Mathf.Max(athlete.BestCompetitionTotal, result.Total);

            athlete.BestCompetitionDots =
                Mathf.Max(athlete.BestCompetitionDots, result.Dots);
        }
    }



    public void ToggleAthleteRegistration(Athlete athlete)
    {
        if (RegisteredAthletes.Contains(athlete))
        {
            RegisteredAthletes.Remove(athlete);
        }
        else
        {
            RegisteredAthletes.Add(athlete);
        }
    }



    public bool IsAthleteRegistered(Athlete athlete)
    {
        return RegisteredAthletes.Contains(athlete);
    }
}