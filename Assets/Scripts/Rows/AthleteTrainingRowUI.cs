using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AthleteTrainingRowUI : AthleteRowBase
{
    [Header("Texts")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text fatigueText;

    [Header("Visuals")]
    [SerializeField] private Image backgroundImage;

    [Header("Training Group Colors")]
    [SerializeField] private Color unassignedColor = new Color(0.75f, 0.75f, 0.75f);
    [SerializeField] private Color lightColor = new Color(0.60f, 0.85f, 0.60f);
    [SerializeField] private Color normalColor = new Color(0.95f, 0.85f, 0.45f);
    [SerializeField] private Color heavyColor = new Color(0.95f, 0.55f, 0.55f);

    private Athlete athlete;

    public Athlete Athlete => athlete;

    public void SetData(Athlete athlete, GameObject mainPanel)
    {
        this.athlete = athlete;

        nameText.text = athlete.Name;
        fatigueText.text = athlete.Fatigue.ToString();

        RefreshColor();

        SetupProfileButton(mainPanel, athlete);
    }

    public void RefreshColor()
    {
        switch (athlete.TrainingGroup)
        {
            case TrainingGroup.Unassigned:
                backgroundImage.color = unassignedColor;
                break;

            case TrainingGroup.Light:
                backgroundImage.color = lightColor;
                break;

            case TrainingGroup.Normal:
                backgroundImage.color = normalColor;
                break;

            case TrainingGroup.Heavy:
                backgroundImage.color = heavyColor;
                break;
        }
    }
}