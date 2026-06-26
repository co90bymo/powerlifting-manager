using System.Collections.Generic;

public class Roster
{
    public List<Athlete> Athletes { get; private set; }

    public Roster()
    {
        Athletes = new List<Athlete>();
    }

    public void AddAthlete(Athlete athlete)
    {
        Athletes.Add(athlete);
    }

    public bool IsEmpty()
    {
        return Athletes.Count == 0;
    }

    public void Clear()
    {
        Athletes.Clear();
    }

    public void AddRange(IEnumerable<Athlete> athletes)
    {
        Athletes.AddRange(athletes);
    }

    public void TrainAthletes()
    {
        foreach (Athlete athlete in Athletes)
        {
            athlete.Train();
        }
    }
}