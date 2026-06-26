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

    public void Train()
    {
        Squat += 2.5f;
        Bench += 2.5f;
        Deadlift += 2.5f;
    }
}