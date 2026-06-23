using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject slotSelectionPanel;
    [SerializeField] private GameObject newGamePanel;

    // If player wishes to start a new game
    private List<Athlete> selectedAthletes = new List<Athlete>();
    private List<Athlete> availableAthletes = new List<Athlete>();

    [SerializeField] private Transform athleteContainer;
    [SerializeField] private GameObject athleteButtonPrefab;

    public int temp_slot;




    public void OpenSlotSelection()
    {
        mainMenuPanel.SetActive(false);
        slotSelectionPanel.SetActive(true);
    }

    public void CloseSlotSelection()
    {
        slotSelectionPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void OpenNewGame(int slot)
    {
        if (GameManager.Instance.SaveManager.SaveExists(slot))
        {
            GameManager.Instance.LoadGame(slot);
            SceneManager.LoadScene("The Gym");
        } 
        else
        {
            // new game state
            availableAthletes.Clear();
            selectedAthletes.Clear();
            temp_slot = slot;
            //
            Athlete TestAthlete = new Athlete("test athlete");
            Athlete TestAthlete2 = new Athlete("test athlete2");
            availableAthletes.Add(TestAthlete);
            availableAthletes.Add(TestAthlete2);
            PopulateAthletes();
            slotSelectionPanel.SetActive(false);
            newGamePanel.SetActive(true);
        }
    }

    public void ConfirmAthletes()
    {
        GameManager.Instance.StartNewGame();
        foreach (Athlete a in selectedAthletes)
        {
            GameManager.Instance.CurrentState.PlayerRoster.AddAthlete(a);
        }
        GameManager.Instance.SaveManager.Save(temp_slot, GameManager.Instance.CurrentState);
    }

    public void CloseNewGame()
    {
        newGamePanel.SetActive(false);
        slotSelectionPanel.SetActive(true);
    }

    public void ToggleSelection(Athlete athlete)
    {
        if (selectedAthletes.Contains(athlete))
        {
            selectedAthletes.Remove(athlete);
        }
        else
        {
            selectedAthletes.Add(athlete);
        }
    }

    public bool IsSelected(Athlete athlete)
    {
        return selectedAthletes.Contains(athlete);
    }


    private void PopulateAthletes()
    {
        foreach (Transform child in athleteContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (Athlete athlete in availableAthletes)
        {
            GameObject obj = Instantiate(athleteButtonPrefab, athleteContainer);

            AthleteButton btn = obj.GetComponent<AthleteButton>();
            btn.Init(athlete, this);
        }
    }

}