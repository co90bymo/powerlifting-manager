using UnityEngine;
using TMPro;

public class ProgressRowUI : MonoBehaviour 
{
    [Header("Texts")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text fatigueText;
    [SerializeField] private TMP_Text squatText;
    [SerializeField] private TMP_Text benchText;
    [SerializeField] private TMP_Text deadliftText;
    [SerializeField] private TMP_Text totalText;

    private CompetitionResult competitionResult;


    // Called when row is created
    public void SetData(TrainingResult result)
    {
        if (gameObject.name == "Progress Row Header")
            return;

        nameText.text = result.Name;
        fatigueText.text = FormatNumber(result.FatigueChange);

        squatText.text = FormatChange(result.SquatGain);
        benchText.text = FormatChange(result.BenchGain);
        deadliftText.text = FormatChange(result.DeadliftGain);

        float total =
            result.SquatGain +
            result.BenchGain +
            result.DeadliftGain;

        totalText.text = FormatChange(total);
    }


    private string FormatChange(float value)
    {
        return value switch
        {
            > 0 => $"+{value}kg",
            < 0 => $"{value}kg",
            _ => "0kg"
        };
    }


    private string FormatNumber(int value)
    {
        return value switch
        {
            > 0 => $"+{value}",
            < 0 => $"{value}",
            _ => "0"
        };
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