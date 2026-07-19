using System.Collections.Generic;
using System.Linq;

public class GameState
{
    public int SlotId { get; set; }

    public Roster PlayerRoster { get; private set; }

    public GameTime GameTime { get; private set; }

    public List<Competition> Competitions { get; private set; }

    public List<Athlete> WorldAthletes { get; private set; }

    public List<Facility> Facilities { get; private set; }

    public float Money { get; set; }


    public GameState()
    {
        PlayerRoster = new Roster();
        GameTime = new GameTime();

        Competitions = new List<Competition>();

        WorldAthletes = new List<Athlete>();

        Facilities = new List<Facility>();
        // Facilities.Add(new Gym());

        Money = 0;
    }



    public void AddCompetition(Competition competition)
    {
        Competitions.Add(competition);

        SortCompetitions();
    }



    private void SortCompetitions()
    {
        Competitions =
            Competitions
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Week)
                .ToList();
    }
}