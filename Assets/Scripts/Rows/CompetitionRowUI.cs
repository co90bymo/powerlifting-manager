using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class CompetitionRowUI : AthleteRowBase
{
    [Header("Basic Info")]
    [SerializeField] private TMP_Text placeText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text ageText;
    [SerializeField] private TMP_Text weightText;


    [Header("Competition Results")]
    [SerializeField] private TMP_Text dotsText;
    [SerializeField] private TMP_Text totalText;


    [Header("Attempt Display")]
    [SerializeField] private TMP_Text squatAttempt1Text;
    [SerializeField] private TMP_Text squatAttempt2Text;
    [SerializeField] private TMP_Text squatAttempt3Text;

    [SerializeField] private TMP_Text benchAttempt1Text;
    [SerializeField] private TMP_Text benchAttempt2Text;
    [SerializeField] private TMP_Text benchAttempt3Text;

    [SerializeField] private TMP_Text deadliftAttempt1Text;
    [SerializeField] private TMP_Text deadliftAttempt2Text;
    [SerializeField] private TMP_Text deadliftAttempt3Text;



    [Header("Attempt Colors")]
    [SerializeField] private Color successfulAttemptColor = Color.black;
    [SerializeField] private Color failedAttemptColor = Color.red;



    [Header("Row Formatting")]
    [SerializeField] private Image rowBackground;

    [SerializeField] private Color normalRowColor = Color.white;
    [SerializeField] private Color topThreeRowColor = new Color(0.85f, 0.85f, 0.85f);
    [SerializeField] private Color playerRowColor = new Color(0.65f, 0.65f, 0.65f);



    [Header("Name Colors")]
    [SerializeField] private Color normalNameColor = Color.black;

    [SerializeField] private Color goldColor = new Color(1f, 0.75f, 0f);
    [SerializeField] private Color silverColor = new Color(0.75f, 0.75f, 0.75f);
    [SerializeField] private Color bronzeColor = new Color(0.8f, 0.45f, 0.2f);



    private CompetitionResult competitionResult;



    public void SetData(
        CompetitionResult competitionResult,
        bool showOverallPlace,
        GameObject competitionRootPanel)
    {
        this.competitionResult = competitionResult;


        placeText.text = showOverallPlace
            ? competitionResult.OverallPlace.ToString()
            : competitionResult.Place.ToString();


        nameText.text =
            competitionResult.Athlete.Name;


        ageText.text =
            competitionResult.Athlete.Age.ToString();


        weightText.text =
            $"{competitionResult.Athlete.Weight} kg";



        dotsText.text =
            $"{competitionResult.Dots:F2}";


        totalText.text =
            $"{competitionResult.Total} kg";



        DisplayAttempts();



        ApplyAthleteFormatting(
            competitionResult,
            showOverallPlace
        );



        SetupProfileButton(
            competitionRootPanel,
            competitionResult.Athlete
        );
    }





    private void DisplayAttempts()
    {
        SetAttemptText(
            squatAttempt1Text,
            GetAttempt(competitionResult.SquatAttempts, 0),
            LiftType.Squat);

        SetAttemptText(
            squatAttempt2Text,
            GetAttempt(competitionResult.SquatAttempts, 1),
            LiftType.Squat);

        SetAttemptText(
            squatAttempt3Text,
            GetAttempt(competitionResult.SquatAttempts, 2),
            LiftType.Squat);



        SetAttemptText(
            benchAttempt1Text,
            GetAttempt(competitionResult.BenchAttempts, 0),
            LiftType.Bench);

        SetAttemptText(
            benchAttempt2Text,
            GetAttempt(competitionResult.BenchAttempts, 1),
            LiftType.Bench);

        SetAttemptText(
            benchAttempt3Text,
            GetAttempt(competitionResult.BenchAttempts, 2),
            LiftType.Bench);



        SetAttemptText(
            deadliftAttempt1Text,
            GetAttempt(competitionResult.DeadliftAttempts, 0),
            LiftType.Deadlift);

        SetAttemptText(
            deadliftAttempt2Text,
            GetAttempt(competitionResult.DeadliftAttempts, 1),
            LiftType.Deadlift);

        SetAttemptText(
            deadliftAttempt3Text,
            GetAttempt(competitionResult.DeadliftAttempts, 2),
            LiftType.Deadlift);
    }





    private CompetitionAttempt GetAttempt(
        List<CompetitionAttempt> attempts,
        int index)
    {
        if (attempts == null ||
            attempts.Count <= index)
        {
            return null;
        }


        return attempts[index];
    }





    private enum LiftType
    {
        Squat,
        Bench,
        Deadlift
    }





    private void SetAttemptText(
        TMP_Text text,
        CompetitionAttempt attempt,
        LiftType lift)
    {
        if (attempt == null)
        {
            text.text = "/";
            SetTextColor(text, successfulAttemptColor);
            return;
        }



        float weight = 0;
        bool success = false;



        switch (lift)
        {
            case LiftType.Squat:

                weight = attempt.Squat;
                success = attempt.SuccessSquat;

                break;


            case LiftType.Bench:

                weight = attempt.Bench;
                success = attempt.SuccessBench;

                break;


            case LiftType.Deadlift:

                weight = attempt.Deadlift;
                success = attempt.SuccessDeadlift;

                break;
        }



        if (weight <= 0)
        {
            text.text = "/";
            SetTextColor(text, successfulAttemptColor);
            return;
        }



        if (success)
        {
            text.text =
                $"{weight}";

            SetTextColor(
                text,
                successfulAttemptColor
            );
        }
        else
        {
            text.text =
                $"{weight} X";

            SetTextColor(
                text,
                failedAttemptColor
            );
        }
    }





    private void SetTextColor(
        TMP_Text text,
        Color color)
    {
        text.color = color;
        text.faceColor = color;
    }





    private void ApplyAthleteFormatting(
        CompetitionResult result,
        bool showOverallPlace)
    {
        nameText.fontStyle =
            FontStyles.Normal;

        nameText.color =
            normalNameColor;


        rowBackground.color =
            normalRowColor;



        int place =
            showOverallPlace
            ? result.OverallPlace
            : result.Place;



        bool isTopThree =
            place <= 3;


        bool isPlayer =
            result.Athlete.Owner ==
            AthleteOwner.Player;



        if (isTopThree)
        {
            nameText.fontStyle =
                FontStyles.Bold;

            rowBackground.color =
                topThreeRowColor;
        }



        if (isPlayer)
        {
            nameText.fontStyle =
                FontStyles.Bold;

            rowBackground.color =
                playerRowColor;
        }



        if (place == 1)
        {
            nameText.color =
                goldColor;
        }
        else if (place == 2)
        {
            nameText.color =
                silverColor;
        }
        else if (place == 3)
        {
            nameText.color =
                bronzeColor;
        }
    }
}