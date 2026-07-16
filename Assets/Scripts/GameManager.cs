using UnityEngine;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentState { get; private set; }
    public SaveManager SaveManager { get; private set; }
    public List<TrainingResult> LastWeekResults { get; private set; }
    private CompetitionScheduler CompetitionScheduler;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SaveManager = new SaveManager();
            CompetitionScheduler = new CompetitionScheduler();
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
        CompetitionScheduler.UpdateCompetitions();
        CurrentState.GameTime.ProgressTime();
        SaveGame(CurrentState.SlotId);
        FindAnyObjectByType<UIManager>().RefreshUI();
    }

    public void AdvanceWeek()
    {
        LastWeekResults = CurrentState.PlayerRoster.TrainAthletes();

        TrainWorldAthletes();

        FindAnyObjectByType<WeekSummaryUI>().RefreshWeekSummary();    
    }

    private void TrainWorldAthletes()
    {
        foreach (Athlete athlete in CurrentState.WorldAthletes)
        {
            athlete.TrainAIControlled();
        }
    }
}
