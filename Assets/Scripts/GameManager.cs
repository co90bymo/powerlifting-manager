using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentState { get; private set; }
    public SaveManager SaveManager { get; private set; }
    public List<TrainingResult> LastWeekResults { get; private set; }


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

    public void AdvanceWeek()
    {
        LastWeekResults = CurrentState.PlayerRoster.TrainAthletes();

        TrainWorldAthletes();
        
    }

    private void TrainWorldAthletes()
    {
        foreach (Athlete athlete in CurrentState.WorldAthletes)
        {
            athlete.TrainAIControlled();
        }
    }
}
