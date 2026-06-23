using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AthleteButton : MonoBehaviour
{
    private Athlete athlete;
    private MainMenuUIManager uiManager;
    [SerializeField] private TextMeshProUGUI buttonText;

    public void Init(Athlete athlete, MainMenuUIManager uiManager)
    {
        this.athlete = athlete;
        this.uiManager = uiManager;
        ChangeTextDisplay();
    }

    public void OnClick()
    {
        uiManager.ToggleSelection(athlete);

        // this will be replaced by visuals later
        ChangeTextDisplay();
    }

    public void ChangeTextDisplay()
    {
        bool selected = uiManager.IsSelected(athlete);

        buttonText.text = selected
        ? athlete.Name + " (selected)"
        : athlete.Name;
    }

}