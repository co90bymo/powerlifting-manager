using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gymPanel;
    [SerializeField] private GameObject rosterPanel;
    [SerializeField] private RosterUI rosterUI; 

    public void OpenRoster()
    {
        gymPanel.SetActive(false);
        rosterPanel.SetActive(true);
        rosterUI.PrintRoster(); 
    }

    public void CloseRoster()
    {
        rosterPanel.SetActive(false);
        gymPanel.SetActive(true);
    }
}