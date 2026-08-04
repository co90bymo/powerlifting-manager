using UnityEngine;

public class UIThemeManager : MonoBehaviour
{
    public static UIThemeManager Instance;

    [SerializeField]
    private UITheme theme;


    public UITheme Theme => theme;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
}