using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class ProgressRowUI : MonoBehaviour 
{
    [Header("Texts")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text squatText;
    [SerializeField] private TMP_Text benchText;
    [SerializeField] private TMP_Text deadliftText;
    [SerializeField] private TMP_Text totalText;

    private CompetitionResult competitionResult;


    // Called when row is created
    public void SetData(TrainingResult result)
    {
        if (gameObject.name == "HeaderRow")
            return;

        nameText.text = result.Name;
        squatText.text = $"+{result.SquatGain} kg";
        benchText.text = $"+{result.BenchGain} kg";
        deadliftText.text = $"+{result.DeadliftGain} kg";

        float total =
            result.SquatGain +
            result.BenchGain +
            result.DeadliftGain;

        totalText.text = $"+{total} kg";
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
