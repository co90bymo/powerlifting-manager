using TMPro;
using UnityEngine;

public class AthleteRowUI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text ageText;
    [SerializeField] private TMP_Text weightText;
    [SerializeField] private TMP_Text fatigueText;
    [SerializeField] private TMP_Text squatText;
    [SerializeField] private TMP_Text benchText;
    [SerializeField] private TMP_Text deadliftText;

    private Athlete athlete;

    // Called when row is created
    public void SetData(Athlete athlete)
    {
            // Header row should never display athlete data
        if (gameObject.name == "Header Row")
            return;
            
        this.athlete = athlete;

        nameText.text = athlete.Name;
        ageText.text = $"{athlete.Age}";
        weightText.text = $"{athlete.Weight}kg";
        fatigueText.text = $"{athlete.Fatigue}";
        squatText.text = $"{athlete.Squat}kg";
        benchText.text = $"{athlete.Bench}kg";
        deadliftText.text = $"{athlete.Deadlift}kg";
    }

    // Called by filter system
    public void SetColumnsVisible(
        bool showName,
        bool showAge,
        bool showWeight,
        bool showFatigue,
        bool showSquat,
        bool showBench,
        bool showDeadlift)
    {
        nameText.transform.parent.gameObject.SetActive(showName);
        ageText.transform.parent.gameObject.SetActive(showAge);
        weightText.transform.parent.gameObject.SetActive(showWeight);
        fatigueText.transform.parent.gameObject.SetActive(showFatigue);
        squatText.transform.parent.gameObject.SetActive(showSquat);
        benchText.transform.parent.gameObject.SetActive(showBench);
        deadliftText.transform.parent.gameObject.SetActive(showDeadlift);
    }
}