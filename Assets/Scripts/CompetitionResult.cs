using System.Collections.Generic;
using UnityEngine;

public class CompetitionResult
{
    public Athlete Athlete;

    public WeightClass WeightClass;


    // All attempts
    public List<CompetitionAttempt> SquatAttempts = new();
    public List<CompetitionAttempt> BenchAttempts = new();
    public List<CompetitionAttempt> DeadliftAttempts = new();


    // Current best successful lifts
    public float BestSquat;
    public float BestBench;
    public float BestDeadlift;


    public float Total;


    public int Place;

    public float Dots;

    public int OverallPlace;


    public float WeightClassPrizeMoney;
    public float OverallPrizeMoney;


    public float PrizeMoney =>
        WeightClassPrizeMoney + OverallPrizeMoney;



    public void AddSquatAttempt(CompetitionAttempt attempt)
    {
        SquatAttempts.Add(attempt);

        if (attempt.SuccessSquat &&
            attempt.Squat > BestSquat)
        {
            BestSquat = attempt.Squat;
        }
    }


    public void AddBenchAttempt(CompetitionAttempt attempt)
    {
        BenchAttempts.Add(attempt);

        if (attempt.SuccessBench &&
            attempt.Bench > BestBench)
        {
            BestBench = attempt.Bench;
        }
    }


    public void AddDeadliftAttempt(CompetitionAttempt attempt)
    {
        DeadliftAttempts.Add(attempt);

        if (attempt.SuccessDeadlift &&
            attempt.Deadlift > BestDeadlift)
        {
            BestDeadlift = attempt.Deadlift;
        }
    }



    public void RecalculateTotal()
    {
        Total =
            BestSquat +
            BestBench +
            BestDeadlift;
    }
}