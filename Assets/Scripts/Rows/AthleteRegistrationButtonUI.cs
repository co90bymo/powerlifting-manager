using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AthleteRegistrationButtonUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text athleteText;
    [SerializeField] private Image backgroundImage;


    [Header("Colors")]
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color registeredColor = Color.green;


    private Athlete athlete;
    private Competition competition;



    public void SetData(Athlete athlete, Competition competition)
    {
        this.athlete = athlete;
        this.competition = competition;


        athleteText.text =
            $"{athlete.Name} | {athlete.Squat + athlete.Bench + athlete.Deadlift} | Fatigue: {athlete.Fatigue}";


        button.onClick.RemoveAllListeners();


        button.onClick.AddListener(() =>
        {
            competition.ToggleAthleteRegistration(athlete);

            UpdateVisual();
        });


        UpdateVisual();
    }



    private void UpdateVisual()
    {
        CompetitionRegisterPanelUI panel =
            FindAnyObjectByType<CompetitionRegisterPanelUI>();


        if (panel != null)
        {
            panel.RefreshUI();
        }


        if (competition.IsAthleteRegistered(athlete))
        {
            backgroundImage.color = registeredColor;
        }
        else
        {
            backgroundImage.color = normalColor;
        }
    }
}