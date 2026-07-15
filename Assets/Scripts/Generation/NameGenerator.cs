using UnityEngine;

public static class NameGenerator
{
    private static string[] firstNames =
    {
        // English
        "James", "John", "Michael", "William", "David",
        "Robert", "Daniel", "Thomas", "Christopher", "Matthew",

        // German
        "Lukas", "Felix", "Maximilian", "Leon", "Julian",
        "Moritz", "Florian", "Sebastian", "Jonas", "Niklas",

        // Eastern European
        "Ivan", "Alexei", "Dmitri", "Andrei", "Mikhail",
        "Viktor", "Sergei", "Pavel", "Roman", "Marek",

        // Nordic
        "Erik", "Lars", "Henrik", "Anders", "Magnus",
        "Johan", "Oskar", "Emil", "Nils", "Sven",

        // International
        "Carlos", "Marco", "Diego", "Kenji", "Hiroshi",
        "Mateo", "Adrian", "Victor", "Luis", "Noah"
    };


    private static string[] lastNames =
    {
        // English
        "Smith", "Johnson", "Williams", "Brown", "Taylor",
        "Anderson", "Thomas", "Jackson", "White", "Harris",

        // German
        "Müller", "Schmidt", "Schneider", "Fischer", "Weber",
        "Wagner", "Becker", "Hoffmann", "Koch", "Richter",

        // Eastern European
        "Petrov", "Ivanov", "Volkov", "Sokolov", "Morozov",
        "Kuznetsov", "Pavlov", "Romanov", "Orlov", "Smirnov",

        // Nordic
        "Hansen", "Johansson", "Larsson", "Andersen", "Eriksen",
        "Nielsen", "Lund", "Berg", "Dahl", "Holm",

        // International
        "Rossi", "Bianchi", "Garcia", "Martinez", "Sato",
        "Tanaka", "Yamamoto", "Silva", "Costa", "Moretti"
    };


    public static string GenerateName()
    {
        string firstName =
            firstNames[Random.Range(0, firstNames.Length)];

        string lastName =
            lastNames[Random.Range(0, lastNames.Length)];

        return $"{firstName} {lastName}";
    }
}