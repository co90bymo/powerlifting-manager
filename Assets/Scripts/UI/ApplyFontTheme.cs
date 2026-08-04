using TMPro;
using UnityEngine;

public class ApplyFontTheme: MonoBehaviour
{
    private void Start()
    {
        Debug.Log("UIThemeApplier started");

        ApplyTheme();
    }


    public void ApplyTheme()
    {
        if (UIThemeManager.Instance == null)
        {
            Debug.Log("No UIThemeManager found");
            return;
        }


        if (UIThemeManager.Instance.Theme == null)
        {
            Debug.Log("No UITheme assigned");
            return;
        }


        TMP_Text[] texts =
            GetComponentsInChildren<TMP_Text>(true);


        Debug.Log(
            "Found TMP texts: " + texts.Length
        );


        foreach (TMP_Text text in texts)
        {
            Debug.Log(
                "Changing font on: " + text.name
            );

            text.font =
                UIThemeManager.Instance.Theme.defaultFont;
        }
    }
}