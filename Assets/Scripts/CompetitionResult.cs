using UnityEngine;

public class CompetitionResult
{
    public Athlete Athlete;

    public WeightClass WeightClass;

    public float BestSquat;
    public float BestBench;
    public float BestDeadlift;

    public float Total;

    // Placement inside weight class
    public int Place;

    // DOTS score for overall ranking
    public float Dots;

    // Placement across all weight classes
    public int OverallPlace;
}