using System.Diagnostics;
using UnityEngine;
using TMPro;

public class WeekSummaryUI : MonoBehaviour
{
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject rowPrefab;

    private void Start()
    {
        PopulateProgressView();
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
}