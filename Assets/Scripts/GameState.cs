using System.Dynamic;

public class GameState
{
    public int SlotId { get; set; }
    public Roster PlayerRoster { get; private set; }
    public GameTime GameTime { get; private set; }

    public GameState()
    {
        PlayerRoster = new Roster();
        GameTime = new GameTime();
    }

}