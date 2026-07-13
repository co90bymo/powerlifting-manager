using UnityEngine;
public class Athlete
{
    public string Name { get; private set; }

    public float Squat { get; set; }
    public float Bench { get; set; }
    public float Deadlift { get; set; }
    public int Age { get; set; } = 18;
    public float Weight { get; set; } = 83f;
    public int Fatigue { get; set; } = 0;
    public TrainingGroup TrainingGroup { get; set; } = TrainingGroup.Unassigned;
    // Not needed now, this is to later keep track of order inside TrainignGroups - purely cosmetic
    public int TrainingOrder { get; set; } = 0;

    public Athlete(string name)
    {
        Name = name;

        Squat = 60;
        Bench = 40;
        Deadlift = 80;

        Age = 18;
        Weight = 90;
        Fatigue = 0;
    }

    public TrainingResult Train()
    {
        float beforeSquat = Squat;
        float beforeBench = Bench;
        float beforeDeadlift = Deadlift;
        int beforeFatigue = Fatigue;


        switch (TrainingGroup)
        {
            case TrainingGroup.Unassigned:
                Squat -= 5;
                Bench -= 5;
                Deadlift -= 5;
                Fatigue -= 3;
                break;


            case TrainingGroup.Light:
                Squat += 1.25f;
                Bench += 1.25f;
                Deadlift += 1.25f;
                break;


            case TrainingGroup.Normal:
                if (Fatigue + 1 <= 10)
                {
                    Squat += 2.5f;
                    Bench += 2.5f;
                    Deadlift += 2.5f;
                    Fatigue += 1;
                }
                break;


            case TrainingGroup.Heavy:
                if (Fatigue + 3 <= 10)
                {
                    Squat += 7.5f;
                    Bench += 7.5f;
                    Deadlift += 7.5f;
                    Fatigue += 3;
                }
                break;
        }


        Fatigue = Mathf.Clamp(Fatigue, 0, 10);


        return new TrainingResult
        {
            Name = Name,
            SquatGain = Squat - beforeSquat,
            BenchGain = Bench - beforeBench,
            DeadliftGain = Deadlift - beforeDeadlift,
            FatigueChange = Fatigue - beforeFatigue
        };
    }

    public float[] GetCompetitionAttempts(float maxLift)
    {
        return new float[]
        {
            maxLift * 0.85f,
            maxLift * 0.925f,
            maxLift
        };
    }
}