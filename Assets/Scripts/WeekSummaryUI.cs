using UnityEngine;
using TMPro;

public class WeekSummaryUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject notificationPanel;
    [SerializeField] private GameObject advanceWeekPanel;
    [SerializeField] private GameObject competitionPanel;

    [Header("Scroll View")]
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private ProgressRowUI headerRow;

    [Header("UI")]
    [SerializeField] private TMP_Text dateText;

    private bool showName = true;
    private bool showSquat = true;
    private bool showBench = true;
    private bool showDeadlift = true;
    private bool showTotal = true;

    private void Start()
    {
        UnityEngine.Debug.Log("TEST");
        CheckNotifications();
        PopulateProgressView();
        DisplayTime();
    }

    private void PopulateProgressView()
    {
        // Clear old rows but keep header
        foreach (Transform child in contentParent)
        {
            if (child.name != "Progress Header Row")
                Destroy(child.gameObject);
        }

        foreach (TrainingResult result in GameManager.Instance.LastWeekResults)
        {
            GameObject row = Instantiate(rowPrefab, contentParent);

            ProgressRowUI rowUI = row.GetComponent<ProgressRowUI>();

            rowUI.SetData(result);

            rowUI.SetColumnsVisible(
                showName,
                showSquat,
                showBench,
                showDeadlift,
                showTotal
            );
        }

        // Keep header in sync
        headerRow.SetColumnsVisible(
            showName,
            showSquat,
            showBench,
            showDeadlift,
            showTotal
        );
    }

    private void DisplayTime()
    {
        dateText.text =
            GameManager.Instance.CurrentState.GameTime.GetTimeDisplayString();
    }

    private void CheckNotifications()
    {
        // Default state
        notificationPanel.SetActive(false);
        advanceWeekPanel.SetActive(true);
        competitionPanel.SetActive(false);

        // Test notification
        if (GameManager.Instance.CurrentState.GameTime.Year == 1 &&
            GameManager.Instance.CurrentState.GameTime.Week == 1)
        {
            notificationPanel.SetActive(true);
            advanceWeekPanel.SetActive(false);
            return;
        }

        // Competition today?
        foreach (Competition competition in GameManager.Instance.CurrentState.Competitions)
        {
            if (competition.Year == GameManager.Instance.CurrentState.GameTime.Year &&
                competition.Week == GameManager.Instance.CurrentState.GameTime.Week)
            {
                competitionPanel.SetActive(true);
                advanceWeekPanel.SetActive(false);
                return;
            }
        }
    }
}