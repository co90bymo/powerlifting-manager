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
    [SerializeField] private GameObject facilitiesPanel;
    [SerializeField] private GameObject advanceWeekPanel;
    [SerializeField] private GameObject reputationPanel;
    [SerializeField] private GameObject clubPanel;


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
    [SerializeField] private TMPro.TextMeshProUGUI reputationText;



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
        DisplayReputation();
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
    // Facilities
    // -----------------------

    public void OpenFacilities()
    {
        gymPanel.SetActive(false);
        facilitiesPanel.SetActive(true);
    }


    public void CloseFacilities()
    {
        facilitiesPanel.SetActive(false);
        gymPanel.SetActive(true);
    }

    // -----------------------
    // Reputation
    // -----------------------

    public void OpenReputation()
    {
        gymPanel.SetActive(false);
        reputationPanel.SetActive(true);
    }


    public void CloseReputation()
    {
        reputationPanel.SetActive(false);
        gymPanel.SetActive(true);
    }

    // -----------------------
    // Club
    // -----------------------

    public void OpenClub()
    {
        gymPanel.SetActive(false);
        clubPanel.SetActive(true);
    }


    public void CloseClub()
    {
        clubPanel.SetActive(false);
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
            $"{GameManager.Instance.CurrentState.PlayerClub.Money:F0} $";
    }

    private void DisplayReputation()
    {
        reputationText.text =
            $"{GameManager.Instance.CurrentState.PlayerClub.Reputation}";
    }
}