public class Athlete
{
    public string Name { get; private set; }

    public float Squat { get; set; }
    public float Bench { get; set; }
    public float Deadlift { get; set; }

    public Athlete(string name)
    {
        Name = name;

        Squat = 60;
        Bench = 40;
        Deadlift = 80;
    }

    public TrainingResult Train()
    {
        float beforeSquat = Squat;
        float beforeBench = Bench;
        float beforeDeadlift = Deadlift;

        Squat += 2.5f;
        Bench += 2.5f;
        Deadlift += 2.5f;

        return new TrainingResult
        {
            Name = Name,
            SquatGain = Squat - beforeSquat,
            BenchGain = Bench - beforeBench,
            DeadliftGain = Deadlift - beforeDeadlift
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