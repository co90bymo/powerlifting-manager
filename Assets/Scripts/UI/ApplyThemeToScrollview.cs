using UnityEngine;
using UnityEngine.UI;


public class ApplyThemeToScrollView : MonoBehaviour
{
    [Header("Optional")]
    [SerializeField] private Image backgroundImage;


    [SerializeField] private VerticalLayoutGroup layout;


    private void Start()
    {
        Apply();
    }


    public void Apply()
    {
        if (UIThemeManager.Instance == null)
            return;


        UITheme theme =
            UIThemeManager.Instance.Theme;


        if (theme == null)
            return;



        // Background
        if (backgroundImage != null)
        {
            backgroundImage.color =
                theme.scrollViewBackgroundColor;
        }


        // Spacing
        if (layout != null)
        {
            layout.spacing =
                theme.scrollViewSpacing;
        }
    }
}