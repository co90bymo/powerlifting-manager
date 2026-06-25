public class GameState
{
    public Roster PlayerRoster { get; private set; }
    public GameTime GameTime { get; private set; }

    public GameState()
    {
        PlayerRoster = new Roster();
        GameTime = new GameTime();
    }

}