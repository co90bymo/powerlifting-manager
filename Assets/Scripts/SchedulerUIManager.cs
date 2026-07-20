using TMPro;
using UnityEngine;

public class SchedulerUIManager : MonoBehaviour
{
    [SerializeField] private Transform eventContainer;
    [SerializeField] private GameObject eventRowPrefab;

    [SerializeField] private TMP_Text eventInfoText;
    [SerializeField] private TMP_Text firstPlaceMoneyText;
    [SerializeField] private TMP_Text secondPlaceMoneyText;
    [SerializeField] private TMP_Text thirdPlaceMoneyText;
    [SerializeField] private TMP_Text firstPlaceRepText;
    [SerializeField] private TMP_Text secondPlaceRepText;
    [SerializeField] private TMP_Text thirdPlaceRepText;
    [SerializeField] private TMP_Text priceMoneyHeaderText;

    private void OnEnable()
    {
        PopulateEvents();
        eventInfoText.text = "";
        firstPlaceMoneyText.text = "";
        secondPlaceMoneyText.text = "";
        thirdPlaceMoneyText.text = "";
        priceMoneyHeaderText.text = "";
        firstPlaceRepText.text = "";
        secondPlaceRepText.text = "";
        thirdPlaceRepText.text = "";
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
        firstPlaceMoneyText.text = $"1. Place: {competition.PrizeMoney[0]:0}$";
        secondPlaceMoneyText.text = $"2. Place: {competition.PrizeMoney[1]:0}$";
        thirdPlaceMoneyText.text = $"3. Place: {competition.PrizeMoney[2]:0}$";

        firstPlaceRepText.text = $"| {competition.ReputationRewards[0]:0}";
        secondPlaceRepText.text = $"| {competition.ReputationRewards[1]:0}";
        thirdPlaceRepText.text = $"| {competition.ReputationRewards[2]:0}";

    }
}