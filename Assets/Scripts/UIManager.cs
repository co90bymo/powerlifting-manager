using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }


    [Header("Main Panels")]
    [SerializeField] private GameObject gymPanel;
    [SerializeField] private GameObject rosterPanel;
    [SerializeField] private GameObject trainingPanel;
    [SerializeField] private GameObject schedulePanel;
    [SerializeField] private GameObject financesPanel;
    [SerializeField] private GameObject advanceWeekPanel;

    [Header("Special Panels")]
    [SerializeField] private GameObject playerProfilePanel;
    [SerializeField] private GameObject competitionRegistrationPanel;

    [SerializeField] private CompetitionRegisterPanelUI competitionRegisterPanelUI;


    [Header("UI Controllers")]
    [SerializeField] private RosterUI rosterUI;
    [SerializeField] private TrainingBoard trainingBoard;
    [SerializeField] private AthleteProfileUI athleteProfileUI;


    [Header("HUD")]
    [SerializeField] private TMPro.TextMeshProUGUI dateText;
    [SerializeField] private TMPro.TextMeshProUGUI financesText;


    private GameObject previousPanel;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    private void Start()
    {
        RefreshUI();
    }



    public void InitiateWeek()
    {
        RefreshUI();
    }



    public void RefreshUI()
    {
        DisplayTime();
        DisplayMoney();
    }



    // -----------------------
    // Roster
    // -----------------------

    public void OpenRoster()
    {
        gymPanel.SetActive(false);
        rosterPanel.SetActive(true);

        rosterUI.PrintRoster();
    }

    public void CloseRoster()
    {
        rosterPanel.SetActive(false);
        gymPanel.SetActive(true);
    }



    // -----------------------
    // Training
    // -----------------------

    public void OpenTrainingMenu()
    {
        gymPanel.SetActive(false);
        trainingPanel.SetActive(true);

        trainingBoard.Refresh();
    }

    public void CloseTrainingMenu()
    {
        trainingPanel.SetActive(false);
        gymPanel.SetActive(true);
    }



    // -----------------------
    // Schedule
    // -----------------------

    public void OpenSchedule()
    {
        gymPanel.SetActive(false);
        schedulePanel.SetActive(true);
    }

    public void CloseSchedule()
    {
        schedulePanel.SetActive(false);
        gymPanel.SetActive(true);
    }



    // -----------------------
    // Finances
    // -----------------------

    public void OpenFinances()
    {
        gymPanel.SetActive(false);
        financesPanel.SetActive(true);
    }

    public void CloseFinances()
    {
        financesPanel.SetActive(false);
        gymPanel.SetActive(true);
    }



    // -----------------------
    // Advance Week
    // -----------------------

    public void OpenAdvanceWeek()
    {
        gymPanel.SetActive(false);
        advanceWeekPanel.SetActive(true);
    }

    public void CloseAdvanceWeek()
    {
        advanceWeekPanel.SetActive(false);
        gymPanel.SetActive(true);
    }



    // -----------------------
    // Competition Registration
    // -----------------------

    public void OpenCompetitionRegistration()
    {
        OpenCompetitionRegistration(null);
    }

    public void OpenCompetitionRegistration(List<Competition> competitions)
    {
        if (competitions != null)
        {
            competitionRegisterPanelUI.SetCompetitions(competitions);
        }

        gymPanel.SetActive(false);
        competitionRegistrationPanel.SetActive(true);
    }

    public void CloseCompetitionRegistration()
    {
        competitionRegistrationPanel.SetActive(false);
        gymPanel.SetActive(true);
    }

    public void OpenRegisterAthletesPanel(Competition competition)
    {
        competitionRegisterPanelUI.OpenRegisterAthletesPanel(competition);
    }



    // -----------------------
    // Athlete Profile
    // -----------------------

    public void OpenPlayerProfile(GameObject currentPanel, Athlete athlete)
    {
        previousPanel = currentPanel;

        athleteProfileUI.SetData(athlete);
        athleteProfileUI.Refresh();

        currentPanel.SetActive(false);
        playerProfilePanel.SetActive(true);
    }

    public void ClosePlayerProfile()
    {
        playerProfilePanel.SetActive(false);

        if (previousPanel != null)
        {
            previousPanel.SetActive(true);
        }
    }



    // -----------------------
    // HUD
    // -----------------------

    private void DisplayTime()
    {
        dateText.text =
            GameManager.Instance.CurrentState.GameTime.GetTimeDisplayString();
    }

    private void DisplayMoney()
    {
        financesText.text =
            $"{GameManager.Instance.CurrentState.Money:F0} $";
    }
}