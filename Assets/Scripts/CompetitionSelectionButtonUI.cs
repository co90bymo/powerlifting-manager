using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompetitionSelectionButtonUI : MonoBehaviour
{
    [SerializeField] private Button button;

    [Header("Texts")]
    [SerializeField] private TMP_Text competitionNameText;
    [SerializeField] private TMP_Text feeText;


    [Header("Deadline Warning")]
    [SerializeField] private Image buttonImage;
    [SerializeField] private Outline outline;

    [SerializeField] private Color deadlineColor = new Color(1f, 0f, 0f, 0.25f);
    [SerializeField] private Color outlineColor = Color.red;


    private Competition competition;



    public void SetData(Competition competition)
    {
        this.competition = competition;


        competitionNameText.text =
            competition.CompetitionName;


        RefreshFee();


        button.onClick.RemoveAllListeners();

        button.onClick.AddListener(() =>
        {
            UIManager.Instance.OpenRegisterAthletesPanel(competition);
        });
    }



    public void RefreshFee()
    {
        float fee =
            competition.RegisteredAthletes.Count *
            competition.EntryFee;


        feeText.text =
            $"Fees: {fee:F0}$";


        RefreshDeadlineWarning();
    }



    private void RefreshDeadlineWarning()
    {
        bool isDeadline =
            competition.WeeksUntil() == 0;


        // Button tint
        if (buttonImage != null)
        {
            if (isDeadline)
            {
                buttonImage.color = deadlineColor;
            }
            else
            {
                buttonImage.color = Color.white;
            }
        }


        // Outline
        if (outline != null)
        {
            outline.enabled = isDeadline;

            if (isDeadline)
            {
                outline.effectColor = outlineColor;
                outline.effectDistance = new Vector2(4f, 4f);
            }
        }
    }
}