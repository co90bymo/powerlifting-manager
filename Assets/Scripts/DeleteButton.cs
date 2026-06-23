using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    [SerializeField] private SlotButton SlotButton;

    public void DeleteSlot(int slot)
    {
        GameManager.Instance.SaveManager.Delete(slot);
        SlotButton.Refresh();
    }
}