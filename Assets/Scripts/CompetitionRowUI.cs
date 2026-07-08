using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class CompetitionRowUI : MonoBehaviour 
{
    [Header("Texts")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text squatText;
    [SerializeField] private TMP_Text benchText;
    [SerializeField] private TMP_Text deadliftText;
    [SerializeField] private TMP_Text totalText;

    private CompetitionResult competitionResult;


    // Called when row is created
    public void SetData(CompetitionResult competitionResult)
    {
            // Header row should never display athlete data
        if (gameObject.name == "Competition Header Row")
            return;

        this.competitionResult = competitionResult;

        nameText.text = competitionResult.Athlete.Name;
        squatText.text = $"{competitionResult.BestSquat} kg";
        benchText.text = $"{competitionResult.BestBench} kg";
        deadliftText.text = $"{competitionResult.BestDeadlift} kg";
        totalText.text = $"{competitionResult.Total} kg";
    }

    // Called by filter system
    public void SetColumnsVisible(bool showName, bool showSquat, bool showBench, bool showDeadlift, bool showTotal)
    {
        nameText.gameObject.SetActive(showName);
        squatText.gameObject.SetActive(showSquat);
        benchText.gameObject.SetActive(showBench);
        deadliftText.gameObject.SetActive(showDeadlift);
        totalText.gameObject.SetActive(showTotal);
    }
}
