using UnityEngine;

public class GymPanelUI : MonoBehaviour
{
    private void OnEnable()
    {
        UIManager.Instance.RefreshUI();
    }
}