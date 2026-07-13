using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gymPanel;
    [SerializeField] private GameObject rosterPanel;
    [SerializeField] private GameObject trainingPanel; 
    [SerializeField] private RosterUI rosterUI; 
    [SerializeField] private TrainingBoard trainingBoard; 
    // Only need reference to the text
    [SerializeField] private TMPro.TextMeshProUGUI dateText;

    private void Start()
    {
        DisplayTime();
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


    public void DisplayTime()
    {
        //change button tmp text
        dateText.text = GameManager.Instance.CurrentState.GameTime.GetTimeDisplayString();
    }
}