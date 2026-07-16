using UnityEngine;
using TMPro;

public class AthleteProfileUI : MonoBehaviour
{
    [SerializeField] private GameObject profilePanel;
    [SerializeField] private GameObject statsDisplay;
    [SerializeField] private GameObject historyDisplay;

    [Header("Basic Info")]
    [SerializeField] private TMP_Text nameAndAgeText;
    [SerializeField] private TMP_Text weightText;

    [Header("Lifts")]
    [SerializeField] private TMP_Text squatText;
    [SerializeField] private TMP_Text benchText;
    [SerializeField] private TMP_Text deadliftText;
    [SerializeField] private TMP_Text totalText;

    [Header("History")]
    [SerializeField] private Transform historyContent;
    [SerializeField] private GameObject historyRowPrefab;

    [Header("Personal Bests")]
    [SerializeField] private TMP_Text personalBestSquatText;
    [SerializeField] private TMP_Text personalBestBenchText;
    [SerializeField] private TMP_Text personalBestDeadliftText;
    [SerializeField] private TMP_Text personalBestTotalText;
    [SerializeField] private TMP_Text personalBestDotsText;

    public void Refresh()
    {
        OpenStats();
    }

    public void SetData(Athlete athlete)
    {
        // ------------------------
        // Stats
        // ------------------------

        nameAndAgeText.text =
            $"{athlete.Name} ({athlete.Age})";

        weightText.text =
            $"{athlete.Weight:F1} kg";

        squatText.text =
            $"Squat: {athlete.Squat} kg";

        benchText.text =
            $"Bench: {athlete.Bench} kg";

        deadliftText.text =
            $"Deadlift: {athlete.Deadlift} kg";

        totalText.text =
            $"Total: {athlete.Squat + athlete.Bench + athlete.Deadlift} kg";

        personalBestSquatText.text =
            $"S: {athlete.BestCompetitionSquat} kg";

        personalBestBenchText.text =
            $"B: {athlete.BestCompetitionBench} kg";

        personalBestDeadliftText.text =
            $"D: {athlete.BestCompetitionDeadlift} kg";

        personalBestTotalText.text =
            $"T: {athlete.BestCompetitionTotal} kg";

        personalBestDotsText.text =
            $"Dots: {athlete.BestCompetitionDots:F2}";

        // ------------------------
        // Competition History
        // ------------------------

        PopulateHistory(athlete);
    }

    private void PopulateHistory(Athlete athlete)
    {
        // Delete previous rows (leave header)
        foreach (Transform child in historyContent)
        {
            if (child.name != "Athlete History Row Header")
                Destroy(child.gameObject);
        }

        foreach (AthleteCompetitionResult result in athlete.CompetitionHistory)
        {
            GameObject row =
                Instantiate(historyRowPrefab, historyContent);

            AthleteCompetitionHistoryRowUI rowUI =
                row.GetComponent<AthleteCompetitionHistoryRowUI>();

            rowUI.SetData(result);
        }
    }

    public void OpenStats()
    {
        statsDisplay.SetActive(true);
        historyDisplay.SetActive(false);
    }

    public void OpenHistory()
    {
        statsDisplay.SetActive(false);
        historyDisplay.SetActive(true);
    }
}