using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompetitionRegisterPanelUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject competitionSelectionPanel;
    [SerializeField] private GameObject registerAthletesPanel;


    [Header("Competition Selection")]
    [SerializeField] private Transform competitionButtonContainer;
    [SerializeField] private GameObject competitionButtonPrefab;


    [Header("Athlete Selection")]
    [SerializeField] private Transform athleteButtonContainer;
    [SerializeField] private GameObject athleteButtonPrefab;


    [Header("UI")]
    [SerializeField] private TMP_Text currentBalanceText;
    [SerializeField] private TMP_Text individualFeeText;
    [SerializeField] private TMP_Text totalFeeText;


    private List<Competition> upcomingCompetitions = new();

    private List<CompetitionSelectionButtonUI> competitionButtons = new();


    private Competition selectedCompetition;



    public void SetCompetitions(List<Competition> competitions)
    {
        upcomingCompetitions =
            new List<Competition>(competitions);

        PopulateCompetitionButtons();

        RefreshUI();
    }



    private void PopulateCompetitionButtons()
    {
        foreach (Transform child in competitionButtonContainer)
        {
            Destroy(child.gameObject);
        }


        competitionButtons.Clear();


        foreach (Competition competition in upcomingCompetitions)
        {
            GameObject buttonObject =
                Instantiate(
                    competitionButtonPrefab,
                    competitionButtonContainer
                );


            CompetitionSelectionButtonUI buttonUI =
                buttonObject.GetComponent<CompetitionSelectionButtonUI>();


            buttonUI.SetData(competition);


            competitionButtons.Add(buttonUI);
        }
    }



    public void OpenRegisterAthletesPanel(Competition competition)
    {
        selectedCompetition = competition;

        competitionSelectionPanel.SetActive(false);
        registerAthletesPanel.SetActive(true);

        PopulateAthleteButtons();

        RefreshUI();
    }



    private void PopulateAthleteButtons()
    {
        foreach (Transform child in athleteButtonContainer)
        {
            Destroy(child.gameObject);
        }


        foreach (Athlete athlete in
                 GameManager.Instance.CurrentState.PlayerRoster.Athletes)
        {
            GameObject buttonObject =
                Instantiate(
                    athleteButtonPrefab,
                    athleteButtonContainer
                );


            AthleteRegistrationButtonUI buttonUI =
                buttonObject.GetComponent<AthleteRegistrationButtonUI>();


            buttonUI.SetData(
                athlete,
                selectedCompetition
            );
        }
    }



    public void CloseRegisterAthletesPanel()
    {
        registerAthletesPanel.SetActive(false);
        competitionSelectionPanel.SetActive(true);

        selectedCompetition = null;

        RefreshUI();
    }



    // ============================
    // UI REFRESH
    // ============================

    public void RefreshUI()
    {
        RefreshCurrentBalance();
        RefreshIndividualFee();
        RefreshTotalFee();
        RefreshCompetitionButtons();
    }



    private void RefreshCurrentBalance()
    {
        currentBalanceText.text =
            $"Current Balance: {GameManager.Instance.CurrentState.Money:F0}$";
    }



    private void RefreshIndividualFee()
    {
        if (selectedCompetition == null)
        {
            individualFeeText.text =
                "Competition Fee: 0$";

            return;
        }


        float fee =
            GetCompetitionFee(selectedCompetition);


        individualFeeText.text =
            $"Competition Fee: {fee:F0}$";
    }



    private void RefreshTotalFee()
    {
        float totalFee = 0;


        foreach (Competition competition in upcomingCompetitions)
        {
            totalFee += GetCompetitionFee(competition);
        }


        totalFeeText.text =
            $"Total Fee: {totalFee:F0}$";
    }



    private void RefreshCompetitionButtons()
    {
        foreach (CompetitionSelectionButtonUI button in competitionButtons)
        {
            button.RefreshFee();
        }
    }



    private float GetCompetitionFee(Competition competition)
    {
        return competition.RegisteredAthletes.Count *
               competition.EntryFee;
    }
}