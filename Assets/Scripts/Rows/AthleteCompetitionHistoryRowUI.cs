using TMPro;
using UnityEngine;

public class AthleteCompetitionHistoryRowUI : MonoBehaviour
{
    [SerializeField] private TMP_Text competitionText;
    [SerializeField] private TMP_Text ageText;
    [SerializeField] private TMP_Text bodyweightText;

    [SerializeField] private TMP_Text rankingText;

    [SerializeField] private TMP_Text squatText;
    [SerializeField] private TMP_Text benchText;
    [SerializeField] private TMP_Text deadliftText;
    [SerializeField] private TMP_Text totalText;
    [SerializeField] private TMP_Text dotsText;

    [Header("Prize Money")]
    [SerializeField] private TMP_Text weightClassPrizeText;
    [SerializeField] private TMP_Text overallPrizeText;
    [SerializeField] private TMP_Text totalPrizeText;

    public void SetData(AthleteCompetitionResult result)
    {
        competitionText.text = result.CompetitionName;

        ageText.text = result.Age.ToString();
        bodyweightText.text = $"{result.BodyWeight:F1}";

        // Weight Class Rank (Overall Rank)
        rankingText.text =
            $"{result.WeightClassRank} ({result.OverallRank})";

        squatText.text = result.Squat.ToString();
        benchText.text = result.Bench.ToString();
        deadliftText.text = result.Deadlift.ToString();

        totalText.text = result.Total.ToString();
        dotsText.text = result.Dots.ToString("F2");

        weightClassPrizeText.text =
            $"${result.WeightClassPrizeMoney:F0}";

        overallPrizeText.text =
            $"${result.OverallPrizeMoney:F0}";

        totalPrizeText.text =
            $"${result.TotalPrizeMoney:F0}";
    }
}