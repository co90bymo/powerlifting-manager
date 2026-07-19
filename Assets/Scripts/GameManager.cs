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
        CurrentState.Facilities.Add(new Gym());
        CurrentState.SlotId = slot;
        CurrentState.Money = 1000;
        GenerateFacilityExpenses();
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
        
        GenerateFacilityExpenses();

        // Save
        SaveGame(CurrentState.SlotId);

        // Update UI
        UIManager.Instance.InitiateWeek();

        // Show notifications
        CheckNotifications();
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

    private void GenerateFacilityExpenses()
    {
        foreach (Facility facility in CurrentState.Facilities)
        {
            FinanceEntry entry =
                facility.CreateWeeklyFinanceEntry();

            FinanceManager.TryAddExpense(
                entry.EntryType,
                entry.Amount,
                entry.TransactionCompleted
            );
        }
    }
}