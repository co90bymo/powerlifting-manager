using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Competition
{
    public int Year;
    public int Week;

    public bool HasBeenRun;


    public List<CompetitionResult> RunCompetition()
    {
        Debug.Log($"Running competition in Year {Year}, Week {Week}");

        List<CompetitionResult> allResults = new();


        // 1. Split athletes by weight class
        Dictionary<WeightClass, List<Athlete>> groups = new();

        foreach (Athlete athlete in GameManager.Instance.CurrentState.PlayerRoster.Athletes)
        {
            WeightClass weightClass = athlete.GetWeightClass();

            if (!groups.ContainsKey(weightClass))
            {
                groups[weightClass] = new List<Athlete>();
            }

            groups[weightClass].Add(athlete);
        }



        // 2. Run competition for each weight class
        foreach (var group in groups)
        {
            WeightClass weightClass = group.Key;
            List<Athlete> athletes = group.Value;

            Debug.Log($"Running {weightClass} competition");


            List<CompetitionResult> classResults = new();


            foreach (Athlete athlete in athletes)
            {
                float[] squatAttempts = athlete.GetCompetitionAttempts(athlete.Squat);
                float[] benchAttempts = athlete.GetCompetitionAttempts(athlete.Bench);
                float[] deadliftAttempts = athlete.GetCompetitionAttempts(athlete.Deadlift);


                CompetitionResult result = new()
                {
                    Athlete = athlete,
                    WeightClass = weightClass,

                    BestSquat = squatAttempts[2],
                    BestBench = benchAttempts[2],
                    BestDeadlift = deadliftAttempts[2]
                };


                result.Total =
                    result.BestSquat +
                    result.BestBench +
                    result.BestDeadlift;


                result.Dots = CalculateDots(
                    athlete.Weight,
                    result.Total
                );


                classResults.Add(result);
            }



            // 3. Sort this weight class by total
            classResults.Sort((a, b) =>
                b.Total.CompareTo(a.Total)
            );


            // Assign weight class placing
            for (int i = 0; i < classResults.Count; i++)
            {
                classResults[i].Place = i + 1;
            }


            allResults.AddRange(classResults);
        }



        // 4. Overall DOTS ranking
        List<CompetitionResult> overallResults = allResults
            .OrderByDescending(x => x.Dots)
            .ToList();


        // Assign overall placing
        for (int i = 0; i < overallResults.Count; i++)
        {
            overallResults[i].OverallPlace = i + 1;
        }



        // 5. Print final competition report
        Debug.Log("========== FINAL COMPETITION RESULTS ==========");


        Debug.Log("----- OVERALL DOTS RANKING -----");

        foreach (CompetitionResult result in overallResults)
        {
            Debug.Log(
                $"{result.OverallPlace}. {result.Athlete.Name} | " +
                $"{result.WeightClass} | " +
                $"Total: {result.Total}kg | " +
                $"DOTS: {result.Dots:F2}"
            );
        }



        Debug.Log("----- RESULTS BY WEIGHT CLASS -----");

        foreach (WeightClass weightClass in System.Enum.GetValues(typeof(WeightClass)))
        {
            Debug.Log($"--- {weightClass} ---");

            foreach (CompetitionResult result in overallResults)
            {
                if (result.WeightClass == weightClass)
                {
                    Debug.Log(
                        $"{result.Place}. {result.Athlete.Name} | " +
                        $"Total: {result.Total}kg | " +
                        $"DOTS: {result.Dots:F2}"
                    );
                }
            }
        }


        Debug.Log("==============================================");



        HasBeenRun = true;


        return overallResults;
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
}