using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            CurrentState = new GameState();
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
}