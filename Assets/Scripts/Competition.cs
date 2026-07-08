using System.Collections.Generic;
using UnityEngine;

public class Competition
{
    public int Year;
    public int Week;

    public bool HasBeenRun;

    public List<CompetitionResult> RunCompetition()
    {
        UnityEngine.Debug.Log($"Running competition in Year {Year}, Week {Week}");

        List<CompetitionResult> results = new();

        foreach (Athlete athlete in GameManager.Instance.CurrentState.PlayerRoster.Athletes)
        {
            float[] squatAttempts = athlete.GetCompetitionAttempts(athlete.Squat);
            float[] benchAttempts = athlete.GetCompetitionAttempts(athlete.Bench);
            float[] deadliftAttempts = athlete.GetCompetitionAttempts(athlete.Deadlift);

            UnityEngine.Debug.Log($"{athlete.Name}");

            UnityEngine.Debug.Log(
                $"Squat: {squatAttempts[0]}, {squatAttempts[1]}, {squatAttempts[2]}"
            );

            UnityEngine.Debug.Log(
                $"Bench: {benchAttempts[0]}, {benchAttempts[1]}, {benchAttempts[2]}"
            );

            UnityEngine.Debug.Log(
                $"Deadlift: {deadliftAttempts[0]}, {deadliftAttempts[1]}, {deadliftAttempts[2]}"
            );

            CompetitionResult result = new()
            {
                Athlete = athlete,
                BestSquat = squatAttempts[2],
                BestBench = benchAttempts[2],
                BestDeadlift = deadliftAttempts[2],
            };

            result.Total =
                result.BestSquat +
                result.BestBench +
                result.BestDeadlift;

            results.Add(result);
        }

        // Sort descending by total
        results.Sort((a, b) => b.Total.CompareTo(a.Total));

        // Assign placings
        for (int i = 0; i < results.Count; i++)
        {
            results[i].Place = i + 1;
        }

        HasBeenRun = true;

        return results;
    }
}