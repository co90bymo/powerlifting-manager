using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Competition
{
    public int Year;
    public int Week;

    public float EntryFee = 50f;

    private Dictionary<Athlete, CompetitionResult> athleteResults = new Dictionary<Athlete, CompetitionResult>();


    // ============================
    // Prize Money
    // ============================

    // Index:
    // 0 = First place
    // 1 = Second place
    // 2 = Third place
    public List<float> PrizeMoney = new()
    {
        500,
        250,
        100
    };


    // ============================
    // Reputation
    // ============================

    // Minimum club reputation required to enter
    public int RequiredReputation = 0;


    // Reputation gained by placement
    // Index:
    // 0 = First place
    // 1 = Second place
    // 2 = Third place
    public List<int> ReputationRewards { get; private set; } = new()
    {
        10,
        3,
        1
    };


    public List<Athlete> RegisteredAthletes { get; private set; } = new();


    public virtual string CompetitionName =>
        "Competition";


    public virtual string Description =>
        "No description.";


    public bool HasBeenRun;



    // ============================
    // Competition Execution
    // ============================
   public (
    List<CompetitionResult> overallResults,
    List<CompetitionResult> totalResults
    )
    RunAttempt(
        int attempt,
        List<CompetitionAttempt> playerResults
    )
    {
        Dictionary<WeightClass, List<Athlete>> groups = new();

        List<Athlete> participants = new();

        participants.AddRange(RegisteredAthletes);
        participants.AddRange(GameManager.Instance.CurrentState.WorldAthletes);



        // First attempt -> create persistent competition results
        if (attempt == 1 && athleteResults.Count == 0)
        {
            athleteResults.Clear();

            foreach (Athlete athlete in participants)
            {
                athleteResults.Add(
                    athlete,
                    new CompetitionResult()
                    {
                        Athlete = athlete,
                        WeightClass = athlete.GetWeightClass()
                    });
            }
        }



        foreach (Athlete athlete in participants)
        {
            WeightClass wc =
                athlete.GetWeightClass();

            if (!groups.ContainsKey(wc))
            {
                groups.Add(
                    wc,
                    new List<Athlete>()
                );
            }

            groups[wc].Add(athlete);
        }



        float aiAttemptMultiplier = attempt switch
        {
            1 => 0.90f,
            2 => 0.95f,
            3 => 1.00f,
            _ => 1.00f
        };



        foreach (var group in groups)
        {
            foreach (Athlete athlete in group.Value)
            {
                CompetitionResult result =
                    athleteResults[athlete];



                // ==========================
                // PLAYER
                // ==========================

                if (athlete.Owner == AthleteOwner.Player)
                {
                    CompetitionAttempt playerAttempt =
                        playerResults.Find(
                            x => x.Athlete == athlete
                        );


                    if (playerAttempt != null)
                    {
                        result.AddSquatAttempt(
                            new CompetitionAttempt()
                            {
                                Athlete = athlete,
                                Squat = playerAttempt.Squat,
                                SuccessSquat = playerAttempt.SuccessSquat
                            });


                        result.AddBenchAttempt(
                            new CompetitionAttempt()
                            {
                                Athlete = athlete,
                                Bench = playerAttempt.Bench,
                                SuccessBench = playerAttempt.SuccessBench
                            });


                        result.AddDeadliftAttempt(
                            new CompetitionAttempt()
                            {
                                Athlete = athlete,
                                Deadlift = playerAttempt.Deadlift,
                                SuccessDeadlift = playerAttempt.SuccessDeadlift
                            });
                    }
                }



                // ==========================
                // AI
                // ==========================

                else
                {
                    float squat =
                        athlete.Squat * aiAttemptMultiplier;

                    float bench =
                        athlete.Bench * aiAttemptMultiplier;

                    float deadlift =
                        athlete.Deadlift * aiAttemptMultiplier;



                    bool squatSuccess =
                        AttemptSuccessCalculator.RollAI(
                            athlete,
                            LiftType.Squat,
                            squat,
                            attempt
                        );


                    bool benchSuccess =
                        AttemptSuccessCalculator.RollAI(
                            athlete,
                            LiftType.Bench,
                            bench,
                            attempt
                        );


                    bool deadliftSuccess =
                        AttemptSuccessCalculator.RollAI(
                            athlete,
                            LiftType.Deadlift,
                            deadlift,
                            attempt
                        );



                    result.AddSquatAttempt(
                        new CompetitionAttempt()
                        {
                            Athlete = athlete,
                            Squat = squat,
                            SuccessSquat = squatSuccess
                        });


                    result.AddBenchAttempt(
                        new CompetitionAttempt()
                        {
                            Athlete = athlete,
                            Bench = bench,
                            SuccessBench = benchSuccess
                        });


                    result.AddDeadliftAttempt(
                        new CompetitionAttempt()
                        {
                            Athlete = athlete,
                            Deadlift = deadlift,
                            SuccessDeadlift = deadliftSuccess
                        });
                }



                result.RecalculateTotal();


                result.Dots =
                    CalculateDots(
                        athlete.Weight,
                        result.Total
                    );
            }



            List<CompetitionResult> classResults =
                athleteResults.Values
                    .Where(
                        x => x.WeightClass == group.Key
                    )
                    .OrderByDescending(
                        x => x.Total
                    )
                    .ToList();



            for (int i = 0; i < classResults.Count; i++)
            {
                classResults[i].Place = i + 1;
            }



            if (attempt == 3)
            {
                AssignWeightClassPrizeMoney(
                    classResults
                );
            }
        }



        List<CompetitionResult> overallResults =
            athleteResults.Values
                .OrderByDescending(
                    x => x.Dots
                )
                .ToList();



        for (int i = 0; i < overallResults.Count; i++)
        {
            overallResults[i].OverallPlace =
                i + 1;
        }



        List<CompetitionResult> totalResults =
            athleteResults.Values
                .OrderByDescending(
                    x => x.Total
                )
                .ToList();



        if (attempt == 3)
        {
            AssignOverallPrizeMoney(
                overallResults
            );


            AwardPlayerPrizeMoney(
                overallResults
            );


            AwardPlayerReputation(
                overallResults
            );


            SaveAthleteCompetitionHistory(
                overallResults
            );


            HasBeenRun = true;


            athleteResults.Clear();
        }



        return
        (
            overallResults,
            totalResults
        );
    }
    // ============================
    // Prize Money Assignment
    // ============================

    private void AssignWeightClassPrizeMoney(
        List<CompetitionResult> results
    )
    {
        foreach (CompetitionResult result in results)
        {
            int index =
                result.Place - 1;


            if (index >= 0 &&
                index < PrizeMoney.Count)
            {
                result.WeightClassPrizeMoney =
                    PrizeMoney[index];
            }
            else
            {
                result.WeightClassPrizeMoney = 0;
            }
        }
    }



    private void AssignOverallPrizeMoney(
        List<CompetitionResult> results
    )
    {
        foreach (CompetitionResult result in results)
        {
            int index =
                result.OverallPlace - 1;


            if (index >= 0 &&
                index < PrizeMoney.Count)
            {
                result.OverallPrizeMoney =
                    PrizeMoney[index];
            }
            else
            {
                result.OverallPrizeMoney = 0;
            }
        }
    }



    private void AwardPlayerPrizeMoney(
        List<CompetitionResult> results
    )
    {
        foreach (CompetitionResult result in results)
        {
            if (result.Athlete.Owner ==
                AthleteOwner.Player)
            {
                float prizeMoney =
                    result.PrizeMoney;



                if (prizeMoney > 0)
                {
                    GameManager.Instance
                    .FinanceManager
                    .AddIncome(
                        FinanceEntryType.PrizeMoney,
                        prizeMoney,
                        true
                    );
                }
            }
        }
    }

    private void AwardPlayerReputation(
        List<CompetitionResult> results
    )
    {
        foreach (CompetitionResult result in results)
        {
            if (result.Athlete.Owner != AthleteOwner.Player)
                continue;


            int index =
                result.Place - 1; // Weight class placement


            if (index >= 0 &&
                index < ReputationRewards.Count)
            {
                int reputationGain =
                    ReputationRewards[index];


                GameManager.Instance
                    .CurrentState
                    .PlayerClub
                    .Reputation += reputationGain;
            }
        }
    }

    public bool CanPlayerRegister()
    {
        return GameManager.Instance
            .CurrentState
            .PlayerClub
            .Reputation >= RequiredReputation;
    }



    // ============================
    // Helpers
    // ============================

    private float CalculateDots(
        float bodyWeight,
        float total
    )
    {
        float coefficient =
            500f /
            (
                -0.0000010930f * Mathf.Pow(bodyWeight, 4)
                + 0.0007391293f * Mathf.Pow(bodyWeight, 3)
                - 0.1918759221f * Mathf.Pow(bodyWeight, 2)
                + 24.0900756f * bodyWeight
                - 307.75076f
            );


        return total * coefficient;
    }



    public int WeeksUntil()
    {
        GameTime time =
            GameManager.Instance
            .CurrentState
            .GameTime;


        int currentWeek =
            time.Year * 52 + time.Week;


        int competitionWeek =
            Year * 52 + Week;


        return competitionWeek - currentWeek;
    }



    // ============================
    // Athlete History
    // ============================

    private void SaveAthleteCompetitionHistory(
        List<CompetitionResult> results
    )
    {
        foreach (CompetitionResult result in results)
        {
            Athlete athlete =
                result.Athlete;



            AthleteCompetitionResult history =
                new AthleteCompetitionResult
                {
                    CompetitionName =
                        CompetitionName,


                    Year =
                        Year,


                    Week =
                        Week,


                    Age =
                        athlete.Age,


                    BodyWeight =
                        athlete.Weight,


                    OverallRank =
                        result.OverallPlace,


                    WeightClassRank =
                        result.Place,


                    Dots =
                        result.Dots,


                    Total =
                        result.Total,


                    Squat =
                        result.BestSquat,


                    Bench =
                        result.BestBench,


                    Deadlift =
                        result.BestDeadlift,


                    OverallPrizeMoney =
                        result.OverallPrizeMoney,


                    WeightClassPrizeMoney =
                        result.WeightClassPrizeMoney,


                    TotalPrizeMoney =
                        result.OverallPrizeMoney +
                        result.WeightClassPrizeMoney
                };



            athlete.CompetitionHistory.Add(
                history
            );



            athlete.BestCompetitionSquat =
                Mathf.Max(
                    athlete.BestCompetitionSquat,
                    result.BestSquat
                );


            athlete.BestCompetitionBench =
                Mathf.Max(
                    athlete.BestCompetitionBench,
                    result.BestBench
                );


            athlete.BestCompetitionDeadlift =
                Mathf.Max(
                    athlete.BestCompetitionDeadlift,
                    result.BestDeadlift
                );


            athlete.BestCompetitionTotal =
                Mathf.Max(
                    athlete.BestCompetitionTotal,
                    result.Total
                );


            athlete.BestCompetitionDots =
                Mathf.Max(
                    athlete.BestCompetitionDots,
                    result.Dots
                );
        }
    }



    // ============================
    // Registration
    // ============================

    public void RegisterAthletes(
        List<Athlete> athletes
    )
    {
        foreach (Athlete athlete in athletes)
        {
            if (!RegisteredAthletes.Contains(athlete))
            {
                RegisteredAthletes.Add(athlete);
            }
        }
    }



    public bool IsAthleteRegistered(
        Athlete athlete
    )
    {
        return RegisteredAthletes.Contains(
            athlete
        );
    }
}