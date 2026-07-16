using UnityEngine;
using UnityEngine.UI;

public class AthleteRowBase : MonoBehaviour
{
    [SerializeField] private Button rowButton;

    private GameObject previousPanel;
    private Athlete athlete;


    protected void SetupProfileButton(GameObject previousPanel, Athlete athlete)
    {
        this.previousPanel = previousPanel;
        this.athlete = athlete;

        rowButton.onClick.RemoveAllListeners();

        rowButton.onClick.AddListener(() =>
        {
            UIManager.Instance.OpenPlayerProfile(this.previousPanel, this.athlete);
        });
    }
}