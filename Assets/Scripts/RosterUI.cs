using System.Collections.Generic;
using TMPro;
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
        // Clear old rows
        foreach (Transform child in contentParent)
        {
            if (child.name != "HeaderRow")
                Destroy(child.gameObject);
        }

        var roster = GameManager.Instance.CurrentState.PlayerRoster;

        if (roster == null || roster.IsEmpty())
            return;

        foreach (Athlete athlete in roster.Athletes)
        {
            GameObject row = Instantiate(athleteRowPrefab, contentParent);

            AthleteRowUI rowUI = row.GetComponent<AthleteRowUI>();

            rowUI.SetData(athlete);

            rowUI.SetColumnsVisible(showName, showSquat, showBench, showDeadlift);

            headerRow.SetColumnsVisible(
                showName,
                showSquat,
                showBench,
                showDeadlift
            );
        }
    }

    public void PrintRoster()
    {
        // Clear old rows
        foreach (Transform child in contentParent)
        {
            if(child.name != "HeaderRow")
            Destroy(child.gameObject);
        }

        var roster = GameManager.Instance.CurrentState.PlayerRoster;

        if (roster.IsEmpty())
        {
            Debug.Log("Roster is empty.");
            return;
        }

        foreach (Athlete athlete in roster.Athletes)
        {
            GameObject row = Instantiate(athleteRowPrefab, contentParent);

            AthleteRowUI rowUI = row.GetComponent<AthleteRowUI>();

            rowUI.SetData(athlete);
        }
    }
}