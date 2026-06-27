using System.Diagnostics;
using UnityEngine;
using TMPro;

public class WeekSummaryUI : MonoBehaviour
{
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject rowPrefab;
    // Only need reference to the text. Not sure if we want to make it clickable later
    [SerializeField] private TMPro.TextMeshProUGUI dateText;

    private void Start()
    {
        PopulateProgressView();
        DisplayTime();
    }

    private void PopulateProgressView()
    {
        // safety: clear old rows (important even now)
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var r in GameManager.Instance.LastWeekResults)
        {
            GameObject row = Instantiate(rowPrefab, contentParent);

            TMP_Text text = row.GetComponentInChildren<TMP_Text>();

            text.text =
                $"{r.Name} | Squat +{r.SquatGain} | Bench +{r.BenchGain} | Deadlift +{r.DeadliftGain}";
        }
    }

    public void DisplayTime()
        {
            //change button tmp text
            dateText.text = GameManager.Instance.CurrentState.GameTime.GetTimeDisplayString();
        }
}