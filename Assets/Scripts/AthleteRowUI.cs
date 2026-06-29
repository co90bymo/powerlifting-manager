using TMPro;
using UnityEngine;

public class AthleteRowUI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text squatText;
    [SerializeField] private TMP_Text benchText;
    [SerializeField] private TMP_Text deadliftText;

    private Athlete athlete;

    // Called when row is created
    public void SetData(Athlete athlete)
    {
            // Header row should never display athlete data
        if (gameObject.name == "HeaderRow")
            return;
            
        this.athlete = athlete;

        nameText.text = athlete.Name;
        squatText.text = $"{athlete.Squat} kg";
        benchText.text = $"{athlete.Bench} kg";
        deadliftText.text = $"{athlete.Deadlift} kg";
    }

    // Called by filter system
    public void SetColumnsVisible(bool showName, bool showSquat, bool showBench, bool showDeadlift)
    {
        nameText.gameObject.SetActive(showName);
        squatText.gameObject.SetActive(showSquat);
        benchText.gameObject.SetActive(showBench);
        deadliftText.gameObject.SetActive(showDeadlift);
    }
}