using UnityEngine;

public class RosterUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject athleteRowPrefab;
    [SerializeField] private AthleteRowUI headerRow;

    private bool showName = true;
    private bool showSquat = true;
    private bool showBench = true;
    private bool showDeadlift = true;

    public void SetFilter(bool name, bool squat, bool bench, bool deadlift)
    {
        showName = name;
        showSquat = squat;
        showBench = bench;
        showDeadlift = deadlift;

        Refresh();
    }

    public void Refresh()
    {
        // Clear old rows but keep the header
        foreach (Transform child in contentParent)
        {
            if (child.gameObject != headerRow.gameObject)
            {
                Destroy(child.gameObject);
            }
        }

        var roster = GameManager.Instance.CurrentState.PlayerRoster;

        if (roster == null || roster.IsEmpty())
        {
            Debug.Log("Roster is empty.");
            return;
        }

        // Update header once
        headerRow.SetColumnsVisible(
            showName,
            showSquat,
            showBench,
            showDeadlift
        );

        // Create athlete rows
        foreach (Athlete athlete in roster.Athletes)
        {
            GameObject row = Instantiate(athleteRowPrefab, contentParent);

            AthleteRowUI rowUI = row.GetComponent<AthleteRowUI>();

            rowUI.SetData(athlete);

            rowUI.SetColumnsVisible(
                showName,
                showSquat,
                showBench,
                showDeadlift
            );
        }
    }

    // Compatibility wrapper for existing code
    public void PrintRoster()
    {
        Refresh();
    }
}