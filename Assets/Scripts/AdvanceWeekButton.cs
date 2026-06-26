using UnityEngine;

public class AdvanceWeekButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.AdvanceWeek();
    }
}