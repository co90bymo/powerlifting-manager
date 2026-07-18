using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompetitionSelectionButtonUI : MonoBehaviour
{
    [SerializeField] private Button button;

    [Header("Texts")]
    [SerializeField] private TMP_Text competitionNameText;
    [SerializeField] private TMP_Text feeText;


    private Competition competition;



    public void SetData(Competition competition)
    {
        this.competition = competition;


        competitionNameText.text =
            competition.CompetitionName;


        RefreshFee();


        button.onClick.RemoveAllListeners();

        button.onClick.AddListener(() =>
        {
            UIManager.Instance.OpenRegisterAthletesPanel(competition);
        });
    }



    public void RefreshFee()
    {
        float fee =
            competition.RegisteredAthletes.Count *
            competition.EntryFee;


        feeText.text =
            $"Fees: {fee:F0}$";
    }
}