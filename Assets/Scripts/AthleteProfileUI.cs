using UnityEngine;

public class AthleteProfileUI : MonoBehaviour
{
    [SerializeField] private GameObject profilePanel;


    public void OpenProfile()
    {
        profilePanel.SetActive(true);
    }


    public void CloseProfile()
    {
        profilePanel.SetActive(false);
    }
}