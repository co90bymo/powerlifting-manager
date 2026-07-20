using System.Collections.Generic;

public class Club
{
    public string Name;

    public float Money;

    public float Reputation;

    public Roster PlayerRoster;

    public List<Facility> Facilities;



    public Club()
    {
        Name = "Player Club";

        Money = 1000;

        Reputation = 0;


        PlayerRoster = new Roster();

        Facilities = new List<Facility>();
    }
}