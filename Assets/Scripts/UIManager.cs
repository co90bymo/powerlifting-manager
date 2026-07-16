using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject gymPanel;
    [SerializeField] private GameObject rosterPanel;
    [SerializeField] private GameObject trainingPanel;
    [SerializeField] private GameObject schedulePanel;
    [SerializeField] private GameObject financesPanel;
    [SerializeField] private GameObject advanceWeekPanel;
    [SerializeField] private GameObject playerProfilePanel;

    [SerializeField] private RosterUI rosterUI;
    [SerializeField] private TrainingBoard trainingBoard;
    [SerializeField] private AthleteProfileUI athleteProfileUI;

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

    public void RefreshUI()
    {
        DisplayTime();
        DisplayMoney();
    }

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

        if(previousPanel != null)
        {
            previousPanel.SetActive(true);
        }
    }

    public void DisplayTime()
    {
        dateText.text = GameManager.Instance.CurrentState.GameTime.GetTimeDisplayString();
    }

    public void DisplayMoney()
    {
        financesText.text = $"{GameManager.Instance.CurrentState.Money:F0} $";
    }
}