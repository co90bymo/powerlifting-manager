using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompetitionRegisterPanelUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject competitionSelectionPanel;
    [SerializeField] private GameObject registerAthletesPanel;
    [SerializeField] private GameObject confirmationPopupPanel;


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
    [SerializeField] private TMP_Text confirmationMessageText;


    private List<Competition> upcomingCompetitions = new();

    private List<CompetitionSelectionButtonUI> competitionButtons = new();


    public List<Athlete> selectedAthletes = new();


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


        selectedAthletes.Clear();


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
                 GameManager.Instance.CurrentState.PlayerClub.PlayerRoster.Athletes)
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


        UpdateAthleteSelectionAvailability();
    }



    public void SelectAthlete(Athlete athlete)
    {
        if (selectedCompetition == null)
            return;


        if (!CanSelectAthlete())
            return;


        if (!selectedAthletes.Contains(athlete))
        {
            selectedAthletes.Add(athlete);
        }


        RefreshUI();

        UpdateAthleteSelectionAvailability();
    }



    public void RemoveSelectedAthlete(Athlete athlete)
    {
        selectedAthletes.Remove(athlete);


        RefreshUI();

        UpdateAthleteSelectionAvailability();
    }



    private bool CanSelectAthlete()
    {
        if (selectedCompetition == null)
            return false;


        float futureFee =
            (selectedAthletes.Count + 1) *
            selectedCompetition.EntryFee;


        return GameManager.Instance.FinanceManager
            .CanAfford(futureFee);
    }



    private void UpdateAthleteSelectionAvailability()
    {
        if (selectedCompetition == null)
            return;


        float currentFee =
            selectedAthletes.Count *
            selectedCompetition.EntryFee;


        bool canSelectMore =
            GameManager.Instance.FinanceManager
                .CanAfford(currentFee + selectedCompetition.EntryFee);



        foreach (Transform child in athleteButtonContainer)
        {
            AthleteRegistrationButtonUI buttonUI =
                child.GetComponent<AthleteRegistrationButtonUI>();


            if (buttonUI != null)
            {
                buttonUI.SetSelectable(canSelectMore);
            }
        }
    }



    public void OpenConfirmationPopup()
    {
        if (selectedCompetition == null)
            return;


        if (selectedAthletes.Count == 0)
            return;


        float totalFee =
            selectedAthletes.Count *
            selectedCompetition.EntryFee;


        confirmationMessageText.text =
            $"Register for {totalFee:F0}$ ?";


        confirmationPopupPanel.SetActive(true);
    }



    public void CloseConfirmationPopup()
    {
        confirmationPopupPanel.SetActive(false);
    }



    public void RegisterSelectedAthletes()
    {
        if (selectedCompetition == null)
            return;


        float fee =
            selectedAthletes.Count *
            selectedCompetition.EntryFee;



        bool paid =
            GameManager.Instance.FinanceManager.TryAddExpense(
                FinanceEntryType.CompetitionEntryFee,
                fee,
                true
            );


        if (!paid)
        {
            CloseConfirmationPopup();
            return;
        }



        selectedCompetition.RegisterAthletes(
            selectedAthletes
        );


        selectedAthletes.Clear();


        CloseConfirmationPopup();


        PopulateAthleteButtons();

        RefreshUI();
    }



    public void CloseRegisterAthletesPanel()
    {
        registerAthletesPanel.SetActive(false);
        competitionSelectionPanel.SetActive(true);


        selectedCompetition = null;

        selectedAthletes.Clear();


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
            $"Current Balance: {GameManager.Instance.CurrentState.PlayerClub.Money:F0}$";
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
            selectedAthletes.Count *
            selectedCompetition.EntryFee;


        individualFeeText.text =
            $"Competition Fee: {fee:F0}$";
    }



    private void RefreshTotalFee()
    {
        float totalFee = 0;


        foreach (Competition competition in upcomingCompetitions)
        {
            totalFee +=
                competition.RegisteredAthletes.Count *
                competition.EntryFee;
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
}