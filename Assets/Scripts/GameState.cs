using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class GameState
{
    public int SlotId { get; set; }

    public GameTime GameTime { get; private set; }

    public List<Competition> Competitions { get; private set; }

    public List<Athlete> WorldAthletes { get; private set; }

    public Club PlayerClub { get; private set; }


public GameState()
{
    GameTime = new GameTime();

    Competitions = new List<Competition>();

    WorldAthletes = new List<Athlete>();

    PlayerClub = new Club();
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