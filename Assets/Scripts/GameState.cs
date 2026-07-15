using System.Dynamic;
using System.Collections.Generic;

public class GameState
{
    public int SlotId { get; set; }
    public Roster PlayerRoster { get; private set; }
    public GameTime GameTime { get; private set; }
    public List<Competition> Competitions { get; private set; }
    public List<Athlete> WorldAthletes { get; private set; }
    public float Money { get; set; }

    public GameState()
    {
        PlayerRoster = new Roster();
        GameTime = new GameTime();
        Competitions = new List<Competition>();
        WorldAthletes = new List<Athlete>();

        Money = 0;
    }

}