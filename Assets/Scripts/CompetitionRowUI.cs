using UnityEngine;
using TMPro;

public class CompetitionRowUI : MonoBehaviour 
{
    [Header("Basic Info")]
    [SerializeField] private TMP_Text placeText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text ageText;
    [SerializeField] private TMP_Text weightText;

    [Header("Competition Results")]
    [SerializeField] private TMP_Text dotsText;
    [SerializeField] private TMP_Text totalText;

    [Header("Lifts")]
    [SerializeField] private TMP_Text squatText;
    [SerializeField] private TMP_Text benchText;
    [SerializeField] private TMP_Text deadliftText;


    private CompetitionResult competitionResult;



    // Called when row is created
    public void SetData(CompetitionResult competitionResult, bool showOverallPlace)
    {
        // Store reference for future clicking/profile opening
        this.competitionResult = competitionResult;

        if (showOverallPlace)
        {
            placeText.text =
                competitionResult.OverallPlace.ToString();
        } else
        {
            placeText.text =
                competitionResult.Place.ToString();
        }

        nameText.text =
            competitionResult.Athlete.Name;

        ageText.text =
            competitionResult.Athlete.Age.ToString();

        weightText.text =
            $"{competitionResult.Athlete.Weight} kg";


        dotsText.text =
            $"{competitionResult.Dots:F2}";

        totalText.text =
            $"{competitionResult.Total} kg";


        squatText.text =
            $"{competitionResult.BestSquat} kg";

        benchText.text =
            $"{competitionResult.BestBench} kg";

        deadliftText.text =
            $"{competitionResult.BestDeadlift} kg";
    }



    // Later: clicking a row can open athlete profile
    public void OnClickRow()
    {
        Debug.Log(
            $"Clicked athlete: {competitionResult.Athlete.Name}"
        );

        // Future:
        // Open Athlete Profile Panel
    }
}