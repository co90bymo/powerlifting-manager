using UnityEngine;

public class TrainingBoard : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform unassignedContent;
    [SerializeField] private Transform lightContent;
    [SerializeField] private Transform normalContent;
    [SerializeField] private Transform heavyContent;

    [Header("Prefab")]
    [SerializeField] private GameObject athleteTrainingRowPrefab;

    [SerializeField] private GameObject mainPanel;



    public void Refresh()
    {
        ClearBoard();

        var roster = GameManager.Instance.CurrentState.PlayerRoster;

        if (roster == null || roster.IsEmpty())
        {
            Debug.Log("Roster is empty.");
            return;
        }


        foreach (Athlete athlete in roster.Athletes)
        {
            Transform parent = GetParentForGroup(athlete.TrainingGroup);

            GameObject row = Instantiate(athleteTrainingRowPrefab, parent);

            row.GetComponent<AthleteTrainingRowUI>().SetData(athlete, mainPanel);
        }
    }


    private Transform GetParentForGroup(TrainingGroup group)
    {
        switch (group)
        {
            case TrainingGroup.Unassigned:
                return unassignedContent;

            case TrainingGroup.Light:
                return lightContent;

            case TrainingGroup.Normal:
                return normalContent;

            case TrainingGroup.Heavy:
                return heavyContent;

            default:
                return unassignedContent;
        }
    }


    private void ClearBoard()
    {
        ClearContent(unassignedContent);
        ClearContent(lightContent);
        ClearContent(normalContent);
        ClearContent(heavyContent);
    }

    private void ClearContent(Transform content)
    {
        foreach (Transform child in content)
        {
            if (child.name == "Header")
                continue;

            Destroy(child.gameObject);
        }
    }
}