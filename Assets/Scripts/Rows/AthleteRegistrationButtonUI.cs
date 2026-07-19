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
    [SerializeField] private Color selectedColor = Color.green;
    [SerializeField] private Color lockedColor = Color.gray;


    private Athlete athlete;
    private Competition competition;


    private bool selected;
    private bool registered;
    private bool selectable = true;



    public void SetData(
        Athlete athlete,
        Competition competition)
    {
        this.athlete = athlete;
        this.competition = competition;


        athleteText.text =
            $"{athlete.Name} | {athlete.Squat + athlete.Bench + athlete.Deadlift} | Fatigue: {athlete.Fatigue}";


        registered =
            competition.IsAthleteRegistered(athlete);


        selected = false;


        button.onClick.RemoveAllListeners();



        if (registered)
        {
            button.interactable = false;

            backgroundImage.color =
                lockedColor;

            return;
        }



        button.interactable = true;


        button.onClick.AddListener(() =>
        {
            selected = !selected;


            CompetitionRegisterPanelUI panel =
                FindAnyObjectByType<CompetitionRegisterPanelUI>();


            if (selected)
            {
                panel.SelectAthlete(athlete);
            }
            else
            {
                panel.RemoveSelectedAthlete(athlete);
            }


            UpdateVisual();
        });



        UpdateVisual();
    }



    public void SetSelectable(bool selectable)
    {
        this.selectable = selectable;


        // Selected athletes must always remain removable
        if (selected)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = selectable;
        }


        UpdateVisual();
    }



    private void UpdateVisual()
    {
        if (registered)
        {
            backgroundImage.color =
                lockedColor;

            return;
        }


        if (selected)
        {
            backgroundImage.color =
                selectedColor;

            return;
        }


        if (!selectable)
        {
            backgroundImage.color =
                lockedColor;

            return;
        }


        backgroundImage.color =
            normalColor;
    }
}