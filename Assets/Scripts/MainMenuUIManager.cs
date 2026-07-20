using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject slotSelectionPanel;
    [SerializeField] private GameObject newGamePanel;

    private List<Athlete> selectedAthletes = new();
    private List<Athlete> availableAthletes = new();

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
        temp_slot = slot;

        if (GameManager.Instance.SaveManager.SaveExists(slot))
        {
            GameManager.Instance.LoadGame(slot);
            SceneManager.LoadScene("The Gym");
        }
        else
        {
            selectedAthletes.Clear();

            availableAthletes =
                NewGameGenerator.GenerateStartingAthletes();

            PopulateAthletes();

            slotSelectionPanel.SetActive(false);
            newGamePanel.SetActive(true);
        }
    }

    public void ConfirmAthletes()
    {
        GameManager.Instance.StartNewGame(temp_slot);

        foreach (Athlete athlete in selectedAthletes)
        {
            GameManager.Instance.CurrentState.PlayerClub.PlayerRoster.AddAthlete(athlete);
        }

        NewGameGenerator.GenerateWorldAthletes(
            GameManager.Instance.CurrentState
        );

        GameManager.Instance.SaveManager.Save(
            temp_slot,
            GameManager.Instance.CurrentState
        );
    }

    public void CloseNewGame()
    {
        newGamePanel.SetActive(false);
        slotSelectionPanel.SetActive(true);
    }

    public void ToggleSelection(Athlete athlete)
    {
        if (selectedAthletes.Contains(athlete))
            selectedAthletes.Remove(athlete);
        else
            selectedAthletes.Add(athlete);
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
            GameObject obj =
                Instantiate(athleteButtonPrefab, athleteContainer);

            AthleteButton btn = obj.GetComponent<AthleteButton>();
            btn.Init(athlete, this);
        }
    }
}