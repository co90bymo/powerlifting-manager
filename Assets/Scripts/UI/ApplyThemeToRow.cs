using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ApplyThemeToRow : MonoBehaviour
{
    [Header("Optional")]
    [SerializeField] private Image backgroundImage;

    [SerializeField] private LayoutElement layoutElement;


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
                theme.rowBackgroundColor;
        }



        // Height
        if (layoutElement != null)
        {
            layoutElement.preferredHeight =
                theme.rowHeight;
        }



        // Text color
        TMP_Text[] texts =
            GetComponentsInChildren<TMP_Text>(true);


        foreach (TMP_Text text in texts)
        {
            text.color =
                theme.rowTextColor;
        }
    }
}