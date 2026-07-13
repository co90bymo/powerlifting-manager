using UnityEngine;
using UnityEngine.UI;

public class RosterFilterUI : MonoBehaviour
{
    [Header("Toggles")]
    [SerializeField] private Toggle nameToggle;
    [SerializeField] private Toggle ageToggle;
    [SerializeField] private Toggle weightToggle;
    [SerializeField] private Toggle fatigueToggle;
    [SerializeField] private Toggle squatToggle;
    [SerializeField] private Toggle benchToggle;
    [SerializeField] private Toggle deadliftToggle;

    [Header("Reference")]
    [SerializeField] private RosterUI rosterUI;

    private void Start()
    {
        // Hook toggle events
        nameToggle.onValueChanged.AddListener(OnFilterChanged);
        ageToggle.onValueChanged.AddListener(OnFilterChanged);
        weightToggle.onValueChanged.AddListener(OnFilterChanged);
        fatigueToggle.onValueChanged.AddListener(OnFilterChanged);
        squatToggle.onValueChanged.AddListener(OnFilterChanged);
        benchToggle.onValueChanged.AddListener(OnFilterChanged);
        deadliftToggle.onValueChanged.AddListener(OnFilterChanged);

        // Initialize once
        ApplyFilter();
    }

    private void OnFilterChanged(bool _)
    {
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        rosterUI.SetFilter(
            nameToggle.isOn,
            ageToggle.isOn,
            weightToggle.isOn,
            fatigueToggle.isOn,
            squatToggle.isOn,
            benchToggle.isOn,
            deadliftToggle.isOn
        );
    }
}