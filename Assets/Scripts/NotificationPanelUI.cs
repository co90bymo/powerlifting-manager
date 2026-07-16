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
        UnityEngine.Debug.Log("CREATE TEST COMPETIITON");
        Competition testCompetition = new TestCompetition
        {
            Year = 1,
            Week = 3
        };
        GameManager.Instance.CurrentState.AddCompetition(testCompetition);


        notificationPanel.SetActive(false);
        advanceWeekPanel.SetActive(true);
        competitionPanel.SetActive(false);
    }

}
