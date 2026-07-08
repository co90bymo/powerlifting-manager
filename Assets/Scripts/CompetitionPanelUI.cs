using UnityEngine;
using System.Collections.Generic;


public class CompetitionPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject notificationPanel;
    [SerializeField] private GameObject advanceWeekPanel;
    [SerializeField] private GameObject competitionPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject competitionRowPrefab;
    [SerializeField] private CompetitionRowUI headerRow;

    private List<CompetitionResult> results;

    private bool showName = true;
    private bool showSquat = true;
    private bool showBench = true;
    private bool showDeadlift = true;
    private bool showTotal = true;

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
        results =
            GameManager.Instance.CurrentState
                .Competitions[0]
                .RunCompetition();

        // later:
        PopulateResultsView();
    }

    private void PopulateResultsView()
    {
        // Clear old rows
        foreach (Transform child in contentParent)
        {
            if (child.name != "Competition Header Row")
                Destroy(child.gameObject);
        }

        foreach (CompetitionResult result in results) // replace Athletes with results
        {
            GameObject row = Instantiate(competitionRowPrefab, contentParent);

            CompetitionRowUI rowUI = row.GetComponent<CompetitionRowUI>();

            rowUI.SetData(result); 

            rowUI.SetColumnsVisible(showName, showSquat, showBench, showDeadlift, showTotal);
        }

        headerRow.SetColumnsVisible(
                showName,
                showSquat,
                showBench,
                showDeadlift,
                showTotal
            );
    }
}