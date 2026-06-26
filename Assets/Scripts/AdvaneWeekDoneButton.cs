using UnityEngine;

public class AdvanceWeekDoneButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.StartNextWeek();
    }
}