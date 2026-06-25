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
}
