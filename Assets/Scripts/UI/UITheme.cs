using TMPro;
using UnityEngine;

[CreateAssetMenu(
    fileName = "UITheme",
    menuName = "UI/UI Theme"
)]
public class UITheme : ScriptableObject
{
    [Header("Typography")]
    public TMP_FontAsset defaultFont;


    [Header("Scroll Views")]
    public Color scrollViewBackgroundColor = new Color(
        0.08f,
        0.08f,
        0.08f
    );

    public float scrollViewSpacing = 10f;



    [Header("Rows")]
    public Color rowBackgroundColor = new Color(
        0.12f,
        0.12f,
        0.12f
    );


    public Color rowTextColor = new Color(
        0.9f,
        0.9f,
        0.9f
    );


    public float rowHeight = 50f;
}