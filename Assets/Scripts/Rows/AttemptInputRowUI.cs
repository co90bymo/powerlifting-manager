using TMPro;
using UnityEngine;


public class AttemptInputRowUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text athleteNameText;


    [Header("Inputs")]
    [SerializeField] private TMP_InputField squatInputField;
    [SerializeField] private TMP_InputField benchInputField;
    [SerializeField] private TMP_InputField deadliftInputField;



    private Athlete athlete;



    public void SetData(Athlete athlete)
    {
        this.athlete = athlete;

        athleteNameText.text = athlete.Name;


        squatInputField.text = "";
        benchInputField.text = "";
        deadliftInputField.text = "";
    }



    public Athlete Athlete => athlete;



    public float GetSquatInput()
    {
        return ParseInput(squatInputField);
    }



    public float GetBenchInput()
    {
        return ParseInput(benchInputField);
    }



    public float GetDeadliftInput()
    {
        return ParseInput(deadliftInputField);
    }



    private float ParseInput(
        TMP_InputField field
    )
    {
        if(float.TryParse(field.text, out float value))
        {
            return value;
        }

        return 0;
    }
}