using TMPro;
using UnityEngine;

public class RosterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rosterText;

    public void PrintRoster()
    {
        if (GameManager.Instance.Roster.IsEmpty)
        {
            rosterText.text = "Roster is empty.";
        }
        else
        {
            rosterText.text = "Roster has athletes.";
        }
    }
}