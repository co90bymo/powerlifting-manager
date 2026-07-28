using UnityEngine;

public static class AttemptSuccessCalculator
{
    public static bool RollAI(
        Athlete athlete,
        LiftType lift,
        float attemptWeight,
        int attemptNumber)
    {
        // Placeholder for now
        return Random.value > 0.25f;
    }


    public static bool RollPlayer(
        Athlete athlete,
        LiftType lift,
        float attemptWeight,
        int attemptNumber)
    {
        float chance =
            GetPlayerSuccessChance(
                athlete,
                lift,
                attemptWeight,
                attemptNumber
            );

        return Random.value <= chance;
    }


    public static float GetPlayerSuccessChance(
        Athlete athlete,
        LiftType lift,
        float attemptWeight,
        int attemptNumber)
    {
        float athleteBest = lift switch
        {
            LiftType.Squat => athlete.Squat,
            LiftType.Bench => athlete.Bench,
            LiftType.Deadlift => athlete.Deadlift,
            _ => 0
        };

        float ratio =
            attemptWeight / athleteBest;

        if (ratio <= 0.90f) return 0.99f;
        if (ratio <= 0.95f) return 0.97f;
        if (ratio <= 1.00f) return 0.90f;
        if (ratio <= 1.02f) return 0.75f;
        if (ratio <= 1.05f) return 0.45f;
        if (ratio <= 1.08f) return 0.20f;
        if (ratio <= 1.11f) return 0.10f;
        if (ratio <= 1.13f) return 0.01f;


        return 0.05f;
    }
}


public enum LiftType
{
    Squat,
    Bench,
    Deadlift
}