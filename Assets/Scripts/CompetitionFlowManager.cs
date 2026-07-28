using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompetitionFlowManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject firstAttemptPanel;
    [SerializeField] private GameObject animationPanel;
    [SerializeField] private GameObject gridPanel;

    [SerializeField] private GameObject resultsPanel;
    [SerializeField] private GameObject mainPanel;


    [Header("UI")]
    [SerializeField] private CompetitionAttemptAnimationUI animationUI;
    [SerializeField] private CompetitionPanelUI competitionPanelUI;

    [SerializeField] private TMP_InputField nextAttemptInputField;



    public List<CompetitionAttempt> attemptInputs = new();

    public List<CompetitionAttempt> nextAttemptInputs = new();


    public int CurrentAttempt { get; private set; } = 1;



    private float tempSquat;
    private float tempBench;
    private float tempDeadlift;



    private int currentAthleteIndex;
    private int currentLiftIndex;



    public void StartCompetitionDay(
        Competition competition
    )
    {
        CurrentAttempt = 1;

        currentAthleteIndex = 0;
        currentLiftIndex = 0;

        firstAttemptPanel.SetActive(true);
    }



    public void StartAnimation()
    {
        firstAttemptPanel.SetActive(false);

        animationPanel.SetActive(true);
        gridPanel.SetActive(true);


        currentAthleteIndex = 0;
        currentLiftIndex = 0;


        if (CurrentAttempt == 3)
        {
            nextAttemptInputField.gameObject.SetActive(false);
        }
        else
        {
            nextAttemptInputField.gameObject.SetActive(true);
        }


        PlayCurrentAttempt();
    }



    private void PlayCurrentAttempt()
    {
        if (currentAthleteIndex >= attemptInputs.Count)
        {
            EndAttempts();
            return;
        }


        CompetitionAttempt attempt =
            attemptInputs[currentAthleteIndex];



        string liftName;
        float weight;
        bool success;



        switch (currentLiftIndex)
        {
            case 0:

                liftName = "Squat";
                weight = attempt.Squat;
                success = attempt.SuccessSquat;

                break;


            case 1:

                liftName = "Bench";
                weight = attempt.Bench;
                success = attempt.SuccessBench;

                break;


            default:

                liftName = "Deadlift";
                weight = attempt.Deadlift;
                success = attempt.SuccessDeadlift;

                break;
        }



        animationUI.PlayAttempt(
            attempt.Athlete.Name,
            liftName,
            weight,
            success
        );
    }



    public void ConfirmAnimation()
    {
        SaveNextAttemptInput();


        currentLiftIndex++;


        if (currentLiftIndex >= 3)
        {
            currentLiftIndex = 0;
            currentAthleteIndex++;
        }


        PlayCurrentAttempt();
    }



    private void SaveNextAttemptInput()
    {
        float input;


        if (!float.TryParse(
            nextAttemptInputField.text,
            out input))
        {
            input = 0;
        }



        switch (currentLiftIndex)
        {
            case 0:

                tempSquat = input;

                break;



            case 1:

                tempBench = input;

                break;



            case 2:

                tempDeadlift = input;



                CompetitionAttempt attempt =
                    new CompetitionAttempt();



                attempt.Athlete =
                    attemptInputs[currentAthleteIndex].Athlete;



                attempt.Squat =
                    tempSquat;


                attempt.Bench =
                    tempBench;


                attempt.Deadlift =
                    tempDeadlift;



                attempt.SuccessSquat =
                    AttemptSuccessCalculator.RollPlayer(
                        attempt.Athlete,
                        LiftType.Squat,
                        attempt.Squat,
                        CurrentAttempt
                    );


                attempt.SuccessBench =
                    AttemptSuccessCalculator.RollPlayer(
                        attempt.Athlete,
                        LiftType.Bench,
                        attempt.Bench,
                        CurrentAttempt
                    );


                attempt.SuccessDeadlift =
                    AttemptSuccessCalculator.RollPlayer(
                        attempt.Athlete,
                        LiftType.Deadlift,
                        attempt.Deadlift,
                        CurrentAttempt
                    );



                nextAttemptInputs.Add(
                    attempt
                );



                tempSquat = 0;
                tempBench = 0;
                tempDeadlift = 0;


                break;
        }



        nextAttemptInputField.text = "";
    }
        private void EndAttempts()
    {
        // IMPORTANT:
        // Run the current attempt BEFORE replacing the data
        competitionPanelUI.RunAttempt(
            attemptInputs,
            CurrentAttempt
        );


        animationPanel.SetActive(false);

        mainPanel.SetActive(true);

        resultsPanel.SetActive(true);

        gridPanel.SetActive(false);



        Debug.Log(
            $"Attempt {CurrentAttempt} finished"
        );



        // Prepare next attempt AFTER results are calculated
        if (CurrentAttempt < 3)
        {
            attemptInputs =
                new List<CompetitionAttempt>(
                    nextAttemptInputs
                );


            nextAttemptInputs.Clear();


            CurrentAttempt++;
        }
        else
        {
            // Competition finished
            CurrentAttempt++;
        }



        Debug.Log(
            "NEXT CURRENT ATTEMPT: "
            + CurrentAttempt
        );
    }





    public void SaveAttemptInputs()
    {
        attemptInputs.Clear();



        AttemptInputRowUI[] rows =
            FindObjectsByType<AttemptInputRowUI>(
                FindObjectsInactive.Include
            );



        foreach (AttemptInputRowUI row in rows)
        {
            CompetitionAttempt data =
                new CompetitionAttempt();



            data.Athlete =
                row.Athlete;



            data.Squat =
                row.GetSquatInput();


            data.Bench =
                row.GetBenchInput();


            data.Deadlift =
                row.GetDeadliftInput();



            // Roll success once here.
            // The animation and competition results will use this same value.

            data.SuccessSquat =
                AttemptSuccessCalculator.RollPlayer(
                    data.Athlete,
                    LiftType.Squat,
                    data.Squat,
                    CurrentAttempt
                );


            data.SuccessBench =
                AttemptSuccessCalculator.RollPlayer(
                    data.Athlete,
                    LiftType.Bench,
                    data.Bench,
                    CurrentAttempt
                );


            data.SuccessDeadlift =
                AttemptSuccessCalculator.RollPlayer(
                    data.Athlete,
                    LiftType.Deadlift,
                    data.Deadlift,
                    CurrentAttempt
                );



            attemptInputs.Add(
                data
            );
        }



        Debug.Log(
            "Saved attempt inputs: "
            + attemptInputs.Count
        );



        foreach (CompetitionAttempt attempt in attemptInputs)
        {
            Debug.Log(
                $"{attempt.Athlete.Name} | " +
                $"Squat: {attempt.Squat} ({attempt.SuccessSquat}) | " +
                $"Bench: {attempt.Bench} ({attempt.SuccessBench}) | " +
                $"Deadlift: {attempt.Deadlift} ({attempt.SuccessDeadlift})"
            );
        }
    }
}