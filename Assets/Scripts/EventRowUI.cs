using TMPro;
using UnityEngine;

public class EventRowUI : MonoBehaviour
{
    [SerializeField] private TMP_Text eventNameText;
    [SerializeField] private TMP_Text weekText;

    private Competition competition;
    private SchedulerUIManager schedulerUIManager;

    public void Init(Competition competition, SchedulerUIManager schedulerUIManager)
    {
        this.competition = competition;
        this.schedulerUIManager = schedulerUIManager;

        eventNameText.text = competition.CompetitionName;

        int weeks = competition.WeeksUntil();

        if (weeks <= 0)
        {
            weekText.text = "This week";
        }
        else if (weeks == 1)
        {
            weekText.text = "In 1 week";
        }
        else
        {
            weekText.text = $"In {weeks} weeks";
        }
    }

    public void OnClick()
    {
        schedulerUIManager.ShowCompetitionInfo(competition);
    }
}