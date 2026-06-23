using TMPro;
using UnityEngine;

public class RosterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rosterText;

    public void PrintRoster()
    {
        if (GameManager.Instance.CurrentState.PlayerRoster.IsEmpty())
        {
            rosterText.text = "Roster is empty.";
        }
        else
        {
            rosterText.text = "";

            foreach (Athlete athlete in GameManager.Instance.CurrentState.PlayerRoster.Athletes)
            {
                rosterText.text += athlete.Name + "\n";
            }
        }
    }
}