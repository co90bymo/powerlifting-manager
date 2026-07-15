using System.Collections.Generic;
using UnityEngine;

public static class NewGameGenerator
{
    public static List<Athlete> GenerateStartingAthletes()
    {
        List<Athlete> athletes = new();

        Athlete athlete1 = new Athlete("Sam Squatter");
        Athlete athlete2 = new Athlete("Dan Deadlifter");
        Athlete athlete3 = new Athlete("Bob Bencher");
        Athlete athlete4 = new Athlete("Tom Franks");
        Athlete athlete5 = new Athlete("Mark Gebauer");
        Athlete athlete6 = new Athlete("Julian Oldman");
        Athlete athlete7 = new Athlete("Christian Ortu");
        Athlete athlete8 = new Athlete("Aiman Abdallah");
        Athlete athlete9 = new Athlete("Benjamin LeFrancais");



        athlete1.Age = 19;
        athlete1.Weight = 72;
        athlete1.Squat = 160;
        athlete1.Bench = 105;
        athlete1.Deadlift = 200;
        athlete1.Owner = AthleteOwner.Player;

        athlete2.Age = 45;
        athlete2.Weight = 87;
        athlete2.Squat = 150;
        athlete2.Bench = 110;
        athlete2.Deadlift = 185;
        athlete2.Owner = AthleteOwner.Player;

        athlete3.Age = 22;
        athlete3.Weight = 101;
        athlete3.Squat = 155;
        athlete3.Bench = 105;
        athlete3.Deadlift = 200;
        athlete3.Owner = AthleteOwner.Player;

        athlete4.Age = 26;
        athlete4.Weight = 83;
        athlete4.Squat = 135;
        athlete4.Bench = 90;
        athlete4.Deadlift = 170;
        athlete4.Owner = AthleteOwner.Player;

        athlete5.Age = 31;
        athlete5.Weight = 97;
        athlete5.Squat = 170;
        athlete5.Bench = 115;
        athlete5.Deadlift = 215;
        athlete5.Owner = AthleteOwner.Player;

        athlete6.Age = 38;
        athlete6.Weight = 109;
        athlete6.Squat = 180;
        athlete6.Bench = 120;
        athlete6.Deadlift = 225;
        athlete6.Owner = AthleteOwner.Player;

        athlete7.Age = 38;
        athlete7.Weight = 99;
        athlete7.Squat = 290;
        athlete7.Bench = 200;
        athlete7.Deadlift = 360;
        athlete7.Owner = AthleteOwner.Player;

        athlete8.Age = 24;
        athlete8.Weight = 72;
        athlete8.Squat = 280;
        athlete8.Bench = 190;
        athlete8.Deadlift = 350;
        athlete8.Owner = AthleteOwner.Player;

        athlete9.Age = 39;
        athlete9.Weight = 106;
        athlete9.Squat = 350;
        athlete9.Bench = 210;
        athlete9.Deadlift = 415;
        athlete9.Owner = AthleteOwner.Player;

        athletes.Add(athlete1);
        athletes.Add(athlete2);
        athletes.Add(athlete3);
        athletes.Add(athlete4);
        athletes.Add(athlete5);
        athletes.Add(athlete6);
        athletes.Add(athlete7);
        athletes.Add(athlete8);
        athletes.Add(athlete9);


        return athletes;
    }

    public static void GenerateWorldAthletes(GameState gameState)
    {
        // Keep the test athlete
        Athlete athlete1 = new Athlete("Max Power");
        athlete1.Age = 23;
        athlete1.Weight = 83;
        athlete1.Squat = 180;
        athlete1.Bench = 120;
        athlete1.Deadlift = 220;
        athlete1.Owner = AthleteOwner.World;

        gameState.WorldAthletes.Add(athlete1);

        // Create 20 additional random athletes
        for (int i = 0; i < 100; i++)
        {
            gameState.WorldAthletes.Add(
                GenerateRandomAthlete()
            );
        }
    }

    private static Athlete GenerateRandomAthlete()
    {
        Athlete athlete = new Athlete(
            NameGenerator.GenerateName()
        );

        // Age
        athlete.Age = UnityEngine.Random.Range(18, 61);

        // Weight
        float roll = UnityEngine.Random.value;

        if (roll < 0.25f)
        {
            // 25% between 50 and 80
            athlete.Weight = Mathf.Floor(
                UnityEngine.Random.Range(50f, 80f)
            );
        }
        else if (roll < 0.75f)
        {
            // 50% between 80 and 100
            athlete.Weight = Mathf.Floor(
                UnityEngine.Random.Range(80f, 100f)
            );
        }
        else
        {
            // 25% between 100 and 150
            athlete.Weight = Mathf.Floor(
                UnityEngine.Random.Range(100f, 150f)
            );
        }


        // Very small strength bonus based on bodyweight
        float weightBonus = (athlete.Weight - 50f) / 100f;


        athlete.Bench = Mathf.Floor(
            UnityEngine.Random.Range(
                60f + weightBonus * 20f,
                180f + weightBonus * 40f
            )
        );


        athlete.Squat = Mathf.Floor(
            UnityEngine.Random.Range(
                80f + weightBonus * 30f,
                300f + weightBonus * 60f
            )
        );


        athlete.Deadlift = Mathf.Floor(
            UnityEngine.Random.Range(
                100f + weightBonus * 40f,
                340f + weightBonus * 80f
            )
        );


        athlete.Owner = AthleteOwner.World;

        return athlete;
    }
}