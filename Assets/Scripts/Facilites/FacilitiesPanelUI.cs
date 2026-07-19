using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FacilitiesPanelUI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text headerText;
    [SerializeField] private TMP_Text weeklyCostText;


    [Header("Image")]
    [SerializeField] private Image facilityImage;


    [Header("Facility Sprites")]
    [SerializeField] private Sprite gymSprite;
    [SerializeField] private Sprite testFacilitySprite;


    [Header("Buttons")]
    [SerializeField] private Button upgradeButton;


    private Facility currentFacility;



    private void OnEnable()
    {
        OpenGym();
    }



    public void OpenGym()
    {
        Facility gym =
            GameManager.Instance.CurrentState.Facilities[0];

        DisplayFacility(
            gym,
            gymSprite
        );
    }



    public void OpenTestFacility()
    {
        Facility testFacility =
            new Facility
            {
                FacilityType = FacilityType.Test,
                WeeklyCost = 500,
                MaintenanceCost = 50,
                FinanceEntryType = FinanceEntryType.GymRent,
                Owner = true
            };


        DisplayFacility(
            testFacility,
            testFacilitySprite
        );
    }



    private void DisplayFacility(
        Facility facility,
        Sprite sprite
    )
    {
        currentFacility = facility;


        headerText.text =
            facility.FacilityType.ToString();


        weeklyCostText.text =
            $"Weekly Cost: {facility.WeeklyCost:F0}$";


        facilityImage.sprite = sprite;


        upgradeButton.interactable = true;
    }
}