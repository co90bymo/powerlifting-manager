using TMPro;
using UnityEngine;

public class AthleteCardUI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text fatigueText;

    private Athlete athlete;

    public Athlete Athlete => athlete;

    public void SetData(Athlete athlete)
    {
        this.athlete = athlete;

        nameText.text = athlete.Name;
        fatigueText.text = $"{athlete.Fatigue}";
    }
}