using UnityEngine;
using System.Collections.Generic;


public class CompetitionPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject notificationPanel;
    [SerializeField] private GameObject welcomeMessagePanel;
    [SerializeField] private GameObject advanceWeekPanel;
    [SerializeField] private GameObject competitionPanel;
    [SerializeField] private GameObject resultsViewHolderPanel;
    [SerializeField] private GameObject summaryPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject firstAttemptPanel;
    [SerializeField] private GameObject competitionAnimationPanel;
    [SerializeField] private GameObject competitionAnimationGrid;



    [Header("First Attempt")]
    [SerializeField] private CompetitionFlowManager competitionFlowManager;

    [SerializeField] private Transform firstAttemptContent;
    [SerializeField] private GameObject attemptInputRowPrefab;

    [Header("Results")]
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject competitionRowPrefab;
    [SerializeField] private CompetitionRowUI headerRow;
    [SerializeField] private TMPro.TMP_Text earnedPrizeMoneyText;

    public List<CompetitionAttempt> attemptInputs = new();



    private List<CompetitionResult> totalResults;
    private List<CompetitionResult> dotsResults;


    // True = show OverallPlace (DOTS ranking)
    // False = show Place (weight class ranking)
    private bool showOverallPlace = true;



    public void OnClickEndCompetitionButton()
    {
        welcomeMessagePanel.SetActive(true);
        notificationPanel.SetActive(false);
        competitionPanel.SetActive(false);
        summaryPanel.SetActive(false);
        advanceWeekPanel.SetActive(true);
    }

    public void OnClickConfirmWelcomeMessage()
    {
        welcomeMessagePanel.SetActive(false);

        Competition competition =
            GameManager.Instance.CurrentState.Competitions[0];

        GameManager.Instance.StartCompetitionDay(competition);
    }


    public void OnClickConfirmResults()
    {
        if (competitionFlowManager.CurrentAttempt > 3)
        {
            summaryPanel.SetActive(true);
            resultsViewHolderPanel.SetActive(false);
        }
        else
        {
            OpenCompetitionAnimationPanel(false);
            competitionFlowManager.StartAnimation();
        }
    }


    public void OpenFirstAttemptPanel()
    {
        firstAttemptPanel.SetActive(true);
        PopulateFirstAttemptPanel();
    }


    public void CloseFirstAttemptPanel()
    {
        firstAttemptPanel.SetActive(false);
    }

    public void OpenResultsViewHolderPanel()
    {
        resultsViewHolderPanel.SetActive(true);
    }


    public void CloseResultsViewHolderPanel()
    {
        resultsViewHolderPanel.SetActive(false);
    }

    public void OpenCompetitionAnimationPanel(bool firstRound)
    {
        if (firstRound)
        {
            competitionFlowManager.SaveAttemptInputs();
        }

        competitionAnimationPanel.SetActive(true);
        competitionAnimationGrid.SetActive(true);
        firstAttemptPanel.SetActive(false);
        mainPanel.SetActive(false);
    }


    public void CloseCompetitionAnimationPanel()
    {
       competitionAnimationPanel.SetActive(false);
       competitionAnimationGrid.SetActive(false);
       mainPanel.SetActive(true);
    }


    public void RunAttempt(
    List<CompetitionAttempt> playerAttempts, int attempt
    )
    {
        var results =
            GameManager.Instance.CurrentState
                .Competitions[0]
                .RunAttempt(
                    attempt,
                    playerAttempts
                );

        dotsResults = results.overallResults;
        totalResults = results.totalResults;

        showOverallPlace = true;

        PopulateResultsView(true);


        float earnedPrizeMoney =
            0f;


        foreach (FinanceEntry entry in GameManager.Instance.FinanceManager.Entries)
        {
            if (entry.Type == FinanceType.Income &&
                entry.EntryType == FinanceEntryType.PrizeMoney)
            {
                earnedPrizeMoney += entry.Amount;
            }
        }


        earnedPrizeMoneyText.text =
            $"You earned {earnedPrizeMoney:F2}$ from this competition";
    }



    private void PopulateResultsView(bool overallRanking, System.Predicate<CompetitionResult> filter = null)
    {
        ClearResults();


        List<CompetitionResult> results;


        if (overallRanking)
        {
            results = dotsResults;
        }
        else
        {
            results = totalResults;
        }



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
                showOverallPlace,
                mainPanel
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

    public void PopulateFirstAttemptPanel()
    {
        foreach (Transform child in firstAttemptContent)
        {
            Destroy(child.gameObject);
        }

        Competition competition =
            GameManager.Instance.CurrentState.Competitions[0];

        foreach (Athlete athlete in competition.RegisteredAthletes)
        {
            GameObject row =
                Instantiate(
                    attemptInputRowPrefab,
                    firstAttemptContent
                );

            row.GetComponent<AttemptInputRowUI>()
                .SetData(athlete);
        }
    }


    // ==========================
    // BUTTON FUNCTIONS
    // ==========================


    public void ShowOverallResults()
    {
        showOverallPlace = true;

        PopulateResultsView(true);
    }



    public void Show52kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            false,
            result => result.WeightClass == WeightClass.U52
        );
    }



    public void Show56kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            false,
            result => result.WeightClass == WeightClass.U56
        );
    }



    public void Show60kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            false,
            result => result.WeightClass == WeightClass.U60
        );
    }



    public void Show67_5kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            false,
            result => result.WeightClass == WeightClass.U67_5
        );
    }



    public void Show75kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            false,
            result => result.WeightClass == WeightClass.U75
        );
    }



    public void Show82_5kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            false,
            result => result.WeightClass == WeightClass.U82_5
        );
    }



    public void Show90kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            false,
            result => result.WeightClass == WeightClass.U90
        );
    }



    public void Show100kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            false,
            result => result.WeightClass == WeightClass.U100
        );
    }



    public void Show110kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            false,
            result => result.WeightClass == WeightClass.U110
        );
    }



    public void Show125kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            false,
            result => result.WeightClass == WeightClass.U125
        );
    }



    public void Show140kg()
    {
        showOverallPlace = false;

        PopulateResultsView(
            false,
            result => result.WeightClass == WeightClass.U140
        );
    }



    public void ShowSHW()
    {
        showOverallPlace = false;

        PopulateResultsView(
            false,
            result => result.WeightClass == WeightClass.SHW
        );
    }
}