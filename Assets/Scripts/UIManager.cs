using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gymPanel;
    [SerializeField] private GameObject rosterPanel;
    [SerializeField] private GameObject trainingPanel; 
    [SerializeField] private GameObject schedulePanel;
    [SerializeField] private GameObject financesPanel;

    [SerializeField] private RosterUI rosterUI; 
    [SerializeField] private TrainingBoard trainingBoard; 
    // Only need reference to the text
    [SerializeField] private TMPro.TextMeshProUGUI dateText;
    [SerializeField] private TMPro.TextMeshProUGUI financesText;


    private void Start()
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




    public void DisplayTime()
    {
        //change button tmp text
        dateText.text = GameManager.Instance.CurrentState.GameTime.GetTimeDisplayString();
    }


    public void DisplayMoney()
    {
        //change button tmp text
        financesText.text = $"{GameManager.Instance.CurrentState.Money:F0} $";
    }
}