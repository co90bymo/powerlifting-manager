using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Competition
{
    public int Year;
    public int Week;

    public float EntryFee = 50f;


    // ============================
    // Prize Money
    // ============================

    // Index:
    // 0 = First place
    // 1 = Second place
    // 2 = Third place
    public List<float> PrizeMoney = new()
    {
        500,
        250,
        100
    };


    // ============================
    // Reputation
    // ============================

    // Minimum club reputation required to enter
    public int RequiredReputation = 0;


    // Reputation gained by placement
    // Index:
    // 0 = First place
    // 1 = Second place
    // 2 = Third place
    public List<int> ReputationRewards { get; private set; } = new()
    {
        10,
        3,
        1
    };


    public List<Athlete> RegisteredAthletes { get; private set; } = new();


    public virtual string CompetitionName =>
        "Competition";


    public virtual string Description =>
        "No description.";


    public bool HasBeenRun;



    // ============================
    // Competition Execution
    // ============================
  public (
    List<CompetitionResult> overallResults,
    List<CompetitionResult> totalResults
)
RunAttempt(
    int attempt,
    List<CompetitionAttempt> playerResults
)
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
        WeightClass weightClass =
            athlete.GetWeightClass();


        if (!groups.ContainsKey(weightClass))
        {
            groups[weightClass] = new();
        }


        groups[weightClass].Add(athlete);
    }



    float aiAttemptMultiplier = attempt switch
    {
        1 => 0.90f,
        2 => 0.95f,
        3 => 1.00f,
        _ => 1.00f
    };



    foreach (var group in groups)
    {
        List<CompetitionResult> classResults = new();



        foreach (Athlete athlete in group.Value)
        {
            CompetitionResult result = new();

            result.Athlete = athlete;
            result.WeightClass = group.Key;



            // Player entered attempts
            if (athlete.Owner == AthleteOwner.Player)
            {
                CompetitionAttempt playerAttempt =
                    playerResults.Find(
                        x => x.Athlete == athlete
                    );


                if (playerAttempt != null)
                {
                    result.BestSquat =
                        playerAttempt.Squat;

                    result.BestBench =
                        playerAttempt.Bench;

                    result.BestDeadlift =
                        playerAttempt.Deadlift;
                }
            }



            // AI generated attempts
            else
            {
                result.BestSquat =
                    athlete.Squat * aiAttemptMultiplier;

                result.BestBench =
                    athlete.Bench * aiAttemptMultiplier;

                result.BestDeadlift =
                    athlete.Deadlift * aiAttemptMultiplier;
            }



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



        classResults.Sort(
            (a,b) =>
                b.Total.CompareTo(a.Total)
        );


        for (int i = 0; i < classResults.Count; i++)
        {
            classResults[i].Place = i + 1;
        }



        // Only final attempt awards weight class prizes
        if (attempt == 3)
        {
            AssignWeightClassPrizeMoney(
                classResults
            );
        }



        allResults.AddRange(
            classResults
        );
    }




    List<CompetitionResult> overallResults =
        allResults
            .OrderByDescending(
                x => x.Dots
            )
            .ToList();



    for (int i = 0; i < overallResults.Count; i++)
    {
        overallResults[i].OverallPlace =
            i + 1;
    }



    List<CompetitionResult> totalResults =
        allResults
            .OrderByDescending(
                x => x.Total
            )
            .ToList();



    // Final competition rewards
    if (attempt == 3)
    {
        AssignOverallPrizeMoney(
            overallResults
        );


        AwardPlayerPrizeMoney(
            overallResults
        );


        AwardPlayerReputation(
            overallResults
        );


        SaveAthleteCompetitionHistory(
            overallResults
        );


        HasBeenRun = true;
    }



    return
    (
        overallResults,
        totalResults
    );
}
    // ============================
    // Prize Money Assignment
    // ============================

    private void AssignWeightClassPrizeMoney(
        List<CompetitionResult> results
    )
    {
        foreach (CompetitionResult result in results)
        {
            int index =
                result.Place - 1;


            if (index >= 0 &&
                index < PrizeMoney.Count)
            {
                result.WeightClassPrizeMoney =
                    PrizeMoney[index];
            }
            else
            {
                result.WeightClassPrizeMoney = 0;
            }
        }
    }



    private void AssignOverallPrizeMoney(
        List<CompetitionResult> results
    )
    {
        foreach (CompetitionResult result in results)
        {
            int index =
                result.OverallPlace - 1;


            if (index >= 0 &&
                index < PrizeMoney.Count)
            {
                result.OverallPrizeMoney =
                    PrizeMoney[index];
            }
            else
            {
                result.OverallPrizeMoney = 0;
            }
        }
    }



    private void AwardPlayerPrizeMoney(
        List<CompetitionResult> results
    )
    {
        foreach (CompetitionResult result in results)
        {
            if (result.Athlete.Owner ==
                AthleteOwner.Player)
            {
                float prizeMoney =
                    result.PrizeMoney;



                if (prizeMoney > 0)
                {
                    GameManager.Instance
                    .FinanceManager
                    .AddIncome(
                        FinanceEntryType.PrizeMoney,
                        prizeMoney,
                        true
                    );
                }
            }
        }
    }

    private void AwardPlayerReputation(
        List<CompetitionResult> results
    )
    {
        foreach (CompetitionResult result in results)
        {
            if (result.Athlete.Owner != AthleteOwner.Player)
                continue;


            int index =
                result.Place - 1; // Weight class placement


            if (index >= 0 &&
                index < ReputationRewards.Count)
            {
                int reputationGain =
                    ReputationRewards[index];


                GameManager.Instance
                    .CurrentState
                    .PlayerClub
                    .Reputation += reputationGain;
            }
        }
    }

    public bool CanPlayerRegister()
    {
        return GameManager.Instance
            .CurrentState
            .PlayerClub
            .Reputation >= RequiredReputation;
    }



    // ============================
    // Helpers
    // ============================

    private float CalculateDots(
        float bodyWeight,
        float total
    )
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
            GameManager.Instance
            .CurrentState
            .GameTime;


        int currentWeek =
            time.Year * 52 + time.Week;


        int competitionWeek =
            Year * 52 + Week;


        return competitionWeek - currentWeek;
    }



    // ============================
    // Athlete History
    // ============================

    private void SaveAthleteCompetitionHistory(
        List<CompetitionResult> results
    )
    {
        foreach (CompetitionResult result in results)
        {
            Athlete athlete =
                result.Athlete;



            AthleteCompetitionResult history =
                new AthleteCompetitionResult
                {
                    CompetitionName =
                        CompetitionName,


                    Year =
                        Year,


                    Week =
                        Week,


                    Age =
                        athlete.Age,


                    BodyWeight =
                        athlete.Weight,


                    OverallRank =
                        result.OverallPlace,


                    WeightClassRank =
                        result.Place,


                    Dots =
                        result.Dots,


                    Total =
                        result.Total,


                    Squat =
                        result.BestSquat,


                    Bench =
                        result.BestBench,


                    Deadlift =
                        result.BestDeadlift,


                    OverallPrizeMoney =
                        result.OverallPrizeMoney,


                    WeightClassPrizeMoney =
                        result.WeightClassPrizeMoney,


                    TotalPrizeMoney =
                        result.OverallPrizeMoney +
                        result.WeightClassPrizeMoney
                };



            athlete.CompetitionHistory.Add(
                history
            );



            athlete.BestCompetitionSquat =
                Mathf.Max(
                    athlete.BestCompetitionSquat,
                    result.BestSquat
                );


            athlete.BestCompetitionBench =
                Mathf.Max(
                    athlete.BestCompetitionBench,
                    result.BestBench
                );


            athlete.BestCompetitionDeadlift =
                Mathf.Max(
                    athlete.BestCompetitionDeadlift,
                    result.BestDeadlift
                );


            athlete.BestCompetitionTotal =
                Mathf.Max(
                    athlete.BestCompetitionTotal,
                    result.Total
                );


            athlete.BestCompetitionDots =
                Mathf.Max(
                    athlete.BestCompetitionDots,
                    result.Dots
                );
        }
    }



    // ============================
    // Registration
    // ============================

    public void RegisterAthletes(
        List<Athlete> athletes
    )
    {
        foreach (Athlete athlete in athletes)
        {
            if (!RegisteredAthletes.Contains(athlete))
            {
                RegisteredAthletes.Add(athlete);
            }
        }
    }



    public bool IsAthleteRegistered(
        Athlete athlete
    )
    {
        return RegisteredAthletes.Contains(
            athlete
        );
    }
}