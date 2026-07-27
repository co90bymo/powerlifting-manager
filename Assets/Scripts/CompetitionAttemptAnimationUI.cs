using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompetitionAttemptAnimationUI : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] private Image lifterImage;

    [SerializeField] private TMP_Text athleteNameText;
    [SerializeField] private TMP_Text liftText;
    [SerializeField] private TMP_Text weightText;
    [SerializeField] private TMP_Text resultText;

    [SerializeField] private GameObject confirmButton;



    public void PlayAttempt(
        string athleteName,
        string liftName,
        float weight,
        bool successful
    )
    {
        StartCoroutine(
            PlayRoutine(
                athleteName,
                liftName,
                weight,
                successful
            )
        );
    }



    private IEnumerator PlayRoutine(
        string athleteName,
        string liftName,
        float weight,
        bool successful
    )
    {
        confirmButton.SetActive(false);


        athleteNameText.text =
            athleteName;


        liftText.text =
            liftName;


        weightText.text =
            $"{weight} kg";


        resultText.text = "";


        lifterImage.color =
            Color.white;



        yield return new WaitForSeconds(0.5f);



        lifterImage.color =
            Color.black;



        resultText.text =
            successful
            ? "SUCCESSFUL"
            : "MISSED";



        confirmButton.SetActive(true);
    }
}