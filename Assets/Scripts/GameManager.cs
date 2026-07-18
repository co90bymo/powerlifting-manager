using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState { get; private set; }
    public SaveManager SaveManager { get; private set; }
    public FinanceManager FinanceManager { get; private set; }

    public List<TrainingResult> LastWeekResults { get; private set; }

    private CompetitionScheduler competitionScheduler;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SaveManager = new SaveManager();
            competitionScheduler = new CompetitionScheduler();
            FinanceManager = new FinanceManager();
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
        // Generate/update competitions
        competitionScheduler.UpdateCompetitions();

        // Finish previous week finances
        FinanceManager.ApplyPendingTransactions();

        // Move time forward
        CurrentState.GameTime.ProgressTime();

        // Create upcoming week expenses
        GenerateCompetitionEntryFees();

        // Save
        SaveGame(CurrentState.SlotId);

        // Update UI
        UIManager.Instance.InitiateWeek();

        // Show notifications
        CheckNotifications();
    }



    private void GenerateCompetitionEntryFees()
    {
        foreach (Competition competition in CurrentState.Competitions)
        {
            if (competition.WeeksUntil() != 0)
                continue;


            foreach (Athlete athlete in competition.RegisteredAthletes)
            {
                FinanceManager.AddExpense(
                    FinanceEntryType.CompetitionEntryFee,
                    competition.EntryFee,
                    true
                );
            }
        }
    }



    private void CheckNotifications()
    {
        List<Competition> upcomingCompetitions = new();


        foreach (Competition competition in CurrentState.Competitions)
        {
            int weeksUntil = competition.WeeksUntil();


            if (weeksUntil >= 0 && weeksUntil <= 4)
            {
                upcomingCompetitions.Add(competition);
            }
        }


        if (upcomingCompetitions.Count > 0)
        {
            UIManager.Instance.OpenCompetitionRegistration(upcomingCompetitions);
        }
    }



    public void AdvanceWeek()
    {
        LastWeekResults =
            CurrentState.PlayerRoster.TrainAthletes();


        TrainWorldAthletes();


        FindAnyObjectByType<WeekSummaryUI>()
            .RefreshWeekSummary();
    }



    private void TrainWorldAthletes()
    {
        foreach (Athlete athlete in CurrentState.WorldAthletes)
        {
            athlete.TrainAIControlled();
        }
    }
}