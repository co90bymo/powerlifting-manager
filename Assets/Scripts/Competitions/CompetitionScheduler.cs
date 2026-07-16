using UnityEngine;

public class CompetitionScheduler
{
    private const int TEST_COMPETITION_INTERVAL = 4;

    private const int YEARLY_INVITATIONAL_WEEK = 10;



    public void UpdateCompetitions()
    {
        RemoveFinishedCompetitions();

        ScheduleTestCompetition();

        ScheduleYearlyInvitational();
    }



    private void RemoveFinishedCompetitions()
    {
        GameManager.Instance.CurrentState
            .Competitions
            .RemoveAll(x => x.HasBeenRun);


        Debug.Log("Removed finished competitions");
    }



    private void ScheduleTestCompetition()
    {
        if (HasCompetitionType<TestCompetition>())
        {
            return;
        }


        CreateTestCompetition();
    }



    private void ScheduleYearlyInvitational()
    {
        if (HasCompetitionType<YearlyInvitationalCompetition>())
        {
            return;
        }


        CreateYearlyInvitational();
    }



    private bool HasCompetitionType<T>() where T : Competition
    {
        foreach (Competition competition in
                 GameManager.Instance.CurrentState.Competitions)
        {
            if (competition is T)
            {
                return true;
            }
        }


        return false;
    }



    private void CreateTestCompetition()
    {
        GameTime currentTime =
            GameManager.Instance.CurrentState.GameTime;


        int currentAbsoluteWeek =
            currentTime.Year * 52 +
            currentTime.Week;


        int competitionAbsoluteWeek =
            currentAbsoluteWeek +
            TEST_COMPETITION_INTERVAL;



        int competitionYear =
            competitionAbsoluteWeek / 52;


        int competitionWeek =
            competitionAbsoluteWeek % 52;



        TestCompetition competition =
            new TestCompetition
            {
                Year = competitionYear,
                Week = competitionWeek
            };



        GameManager.Instance.CurrentState
            .AddCompetition(competition);



        Debug.Log(
            $"Created Test Competition at Year {competitionYear} Week {competitionWeek}"
        );
    }



    private void CreateYearlyInvitational()
    {
        GameTime currentTime =
            GameManager.Instance.CurrentState.GameTime;



        int targetYear = currentTime.Year;

        int targetWeek = YEARLY_INVITATIONAL_WEEK;



        // If we already passed week 10 this year,
        // create it next year
        if (currentTime.Week >= YEARLY_INVITATIONAL_WEEK)
        {
            targetYear++;
        }



        YearlyInvitationalCompetition competition =
            new YearlyInvitationalCompetition
            {
                Year = targetYear,
                Week = targetWeek
            };



        GameManager.Instance.CurrentState
            .AddCompetition(competition);



        Debug.Log(
            $"Created Yearly Invitational at Year {targetYear} Week {targetWeek}"
        );
    }
}