using TMPro;
using UnityEngine;

public class SchedulerUIManager : MonoBehaviour
{
    [SerializeField] private Transform eventContainer;
    [SerializeField] private GameObject eventRowPrefab;

    [SerializeField] private TMP_Text eventInfoText;
    [SerializeField] private TMP_Text firstPlaceText;
    [SerializeField] private TMP_Text secondPlaceText;
    [SerializeField] private TMP_Text thirdPlaceText;
    [SerializeField] private TMP_Text priceMoneyHeaderText;

    private void OnEnable()
    {
        PopulateEvents();
        eventInfoText.text = "";
        firstPlaceText.text = "";
        secondPlaceText.text = "";
        thirdPlaceText.text = "";
        priceMoneyHeaderText.text = "";
    }

    private void PopulateEvents()
    {
        ClearEvents();

        foreach (Competition competition in GameManager.Instance.CurrentState.Competitions)
        {
            GameObject obj = Instantiate(
                eventRowPrefab,
                eventContainer
            );

            EventRowUI row = obj.GetComponent<EventRowUI>();

            row.Init(competition, this);
        }
    }

    private void ClearEvents()
    {
        foreach (Transform child in eventContainer)
        {
            Destroy(child.gameObject);
        }
    }

    public void ShowCompetitionInfo(Competition competition)
    {
        eventInfoText.text = competition.Description;
        priceMoneyHeaderText.text = "Price Money:";
        firstPlaceText.text = $"1. Place: {competition.FirstPlacePrize:0}$";
        secondPlaceText.text = $"2. Place: {competition.SecondPlacePrize:0}$";
        thirdPlaceText.text = $"3. Place: {competition.ThirdPlacePrize:0}$";
    }
}