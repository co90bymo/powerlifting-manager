using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentState { get; private set; }
    public SaveManager SaveManager { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SaveManager = new SaveManager();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartNewGame(int slot)
    {
        CurrentState = new GameState();
        CurrentState.SlotId = slot;
    }
    
    public void LoadGame(int slot)
    {
        CurrentState = SaveManager.Load(slot);

        UnityEngine.Debug.Log("Load Game" + CurrentState.GameTime.Week);
    }

    public void SaveGame(int slot)
    {
        SaveManager.Save(slot, CurrentState);
    }

    public void StartNextWeek()
    {
        CurrentState.GameTime.ProgressTime();
        SaveGame(CurrentState.SlotId);
    }

    // This function contains the core simulation step of the game after the end of every week
    public void AdvanceWeek()
    {
        // Player Roster loops through all our athletes and calls Train() on them
        CurrentState.PlayerRoster.TrainAthletes();
    }
}
