using UnityEngine;

public class CompetitionPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject notificationPanel;
    [SerializeField] private GameObject advanceWeekPanel;
    [SerializeField] private GameObject competitionPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RunCompetition();
    }

    public void OnClickEndCompetitionButton()
    {
        notificationPanel.SetActive(false);
        competitionPanel.SetActive(false);
        advanceWeekPanel.SetActive(true);
    }

    private void RunCompetition()
    {
        
    }

}