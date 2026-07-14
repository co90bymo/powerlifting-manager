using UnityEngine;
using System.Collections.Generic;


public class CompetitionPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject notificationPanel;
    [SerializeField] private GameObject welcomeMessagePanel;
    [SerializeField] private GameObject advanceWeekPanel;
    [SerializeField] private GameObject competitionPanel;



    [Header("Results")]
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject competitionRowPrefab;
    [SerializeField] private CompetitionRowUI headerRow;


    private List<CompetitionResult> results;

    // True = show OverallPlace (DOTS ranking)
    // False = show Place (weight class ranking)
    private bool showOverallPlace = true;



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


    public void OnClickConfirmWelcomeMessage()
    {
        welcomeMessagePanel.SetActive(false);
    }




    private void RunCompetition()
    {
        results =
            GameManager.Instance.CurrentState
                .Competitions[0]
                .RunCompetition();


        // Default view = overall DOTS results
        showOverallPlace = true;
        PopulateResultsView();
    }



    private void PopulateResultsView(System.Predicate<CompetitionResult> filter = null)
    {
        ClearResults();


        foreach (CompetitionResult result in results)
        {
            // If a filter exists, check if this result should be shown
            if (filter != null && !filter(result))
                continue;


            GameObject row =
                Instantiate(
                    competitionRowPrefab,
                    contentParent
                );


            CompetitionRowUI rowUI =
                row.GetComponent<CompetitionRowUI>();


            rowUI.SetData(
                result,
                showOverallPlace
            );
        }
    }



    private void ClearResults()
    {
        foreach (Transform child in contentParent)
        {
            if (child.name != "Competition Result Row Header")
            {
                Destroy(child.gameObject);
            }
        }
    }



    // ==========================
    // BUTTON FUNCTIONS
    // ==========================


    public void ShowOverallResults()
    {
        showOverallPlace = true;

        PopulateResultsView();
    }



    public void Show52kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            result => result.WeightClass == WeightClass.U52
        );
    }



    public void Show56kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            result => result.WeightClass == WeightClass.U56
        );
    }



    public void Show60kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            result => result.WeightClass == WeightClass.U60
        );
    }



    public void Show67_5kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            result => result.WeightClass == WeightClass.U67_5
        );
    }



    public void Show75kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            result => result.WeightClass == WeightClass.U75
        );
    }



    public void Show82_5kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            result => result.WeightClass == WeightClass.U82_5
        );
    }



    public void Show90kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            result => result.WeightClass == WeightClass.U90
        );
    }



    public void Show100kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            result => result.WeightClass == WeightClass.U100
        );
    }



    public void Show110kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            result => result.WeightClass == WeightClass.U110
        );
    }



    public void Show125kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            result => result.WeightClass == WeightClass.U125
        );
    }



    public void Show140kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            result => result.WeightClass == WeightClass.U140
        );
    }



    public void ShowSHW()
    {
        showOverallPlace = false;

        PopulateResultsView(
            result => result.WeightClass == WeightClass.SHW
        );
    }
}