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

            CurrentState = new GameState();
            SaveManager = new SaveManager();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartNewGame()
    {
        CurrentState = new GameState();
    }
    
    public void LoadGame(int slot)
    {
        CurrentState = SaveManager.Load(slot);
    }
}