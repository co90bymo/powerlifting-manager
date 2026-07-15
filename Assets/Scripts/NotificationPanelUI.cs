using UnityEngine;

public class NotificationPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject notificationPanel;
    [SerializeField] private GameObject advanceWeekPanel;
    [SerializeField] private GameObject competitionPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnClickConfirmButton()
    {
        Competition testCompetition = new Competition
        {
            Year = 1,
            Week = 2
        };
        GameManager.Instance.CurrentState.Competitions.Add(testCompetition);

        notificationPanel.SetActive(false);
        advanceWeekPanel.SetActive(true);
        competitionPanel.SetActive(false);
    }

}
