using System.Collections.Generic;

public class Roster
{
    private List<Athlete> athletes = new();

    public bool IsEmpty => athletes.Count == 0;
}