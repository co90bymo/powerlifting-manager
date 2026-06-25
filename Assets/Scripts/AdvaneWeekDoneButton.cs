using UnityEngine;

public class AdvanceWeekDoneButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.CurrentState.GameTime.ProgressTime();
        
        int slot = GameManager.Instance.CurrentState.SlotId;
        GameManager.Instance.SaveGame(slot);
    }
}