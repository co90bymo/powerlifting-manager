using System;

[Serializable]
public class AthleteCompetitionResult
{
    public string CompetitionName;

    public int Year;
    public int Week;

    public int Age;
    public float BodyWeight;

    // Rankings
    public int OverallRank;
    public int WeightClassRank;

    // Performance
    public float Dots;

    public float Total;

    public float Squat;
    public float Bench;
    public float Deadlift;

    // Prize money
    public float OverallPrizeMoney;
    public float WeightClassPrizeMoney;
    public float TotalPrizeMoney;
}