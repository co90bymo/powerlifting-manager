using UnityEngine;
using TMPro;

public class SlotButton : MonoBehaviour
{
    [SerializeField] private int slotId;
    [SerializeField] private TMP_Text buttonText;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        bool hasSave = GameManager.Instance.SaveManager.SaveExists(slotId);

        if (hasSave)
        {
            buttonText.text = "Game " + slotId;
        }
        else
        {
            buttonText.text = "Slot " + slotId;
        }
    }
}