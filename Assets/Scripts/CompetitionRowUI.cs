using UnityEngine;
using TMPro;
using UnityEngine.UI;

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


    [Header("Row Formatting")]
    [SerializeField] private Image rowBackground;

    [SerializeField] private Color normalRowColor = Color.white;
    [SerializeField] private Color topThreeRowColor = new Color(0.85f, 0.85f, 0.85f);
    [SerializeField] private Color playerRowColor = new Color(0.65f, 0.65f, 0.65f);


    [Header("Name Colors")]
    [SerializeField] private Color normalNameColor = Color.black;

    [SerializeField] private Color goldColor = new Color(1f, 0.75f, 0f);
    [SerializeField] private Color silverColor = new Color(0.75f, 0.75f, 0.75f);
    [SerializeField] private Color bronzeColor = new Color(0.8f, 0.45f, 0.2f);



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
        }
        else
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



        ApplyAthleteFormatting(
            competitionResult,
            showOverallPlace
        );
    }




    private void ApplyAthleteFormatting(
        CompetitionResult result,
        bool showOverallPlace
    )
    {
        // Reset formatting
        nameText.fontStyle = FontStyles.Normal;
        nameText.color = normalNameColor;

        rowBackground.color = normalRowColor;



        // Determine displayed ranking
        int place = showOverallPlace
            ? result.OverallPlace
            : result.Place;



        bool isTopThree = place <= 3;

        bool isPlayer =
            result.Athlete.Owner == AthleteOwner.Player;



        // Podium formatting
        if (isTopThree)
        {
            nameText.fontStyle = FontStyles.Bold;

            rowBackground.color = topThreeRowColor;
        }



        // Player formatting overrides row color
        if (isPlayer)
        {
            nameText.fontStyle = FontStyles.Bold;

            rowBackground.color = playerRowColor;
        }



        // Medal text colors override normal black
        if (place == 1)
        {
            nameText.color = goldColor;
        }
        else if (place == 2)
        {
            nameText.color = silverColor;
        }
        else if (place == 3)
        {
            nameText.color = bronzeColor;
        }
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