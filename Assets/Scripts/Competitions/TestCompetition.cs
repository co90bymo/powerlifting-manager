public class TestCompetition : Competition
{
    public override string CompetitionName =>
        "Test Competition";


    public override string Description =>
        "A temporary competition used during development.";


    public TestCompetition()
    {
        EntryFee = 50;


        RequiredReputation = 0;


        PrizeMoney[0] = 500;
        PrizeMoney[1] = 250;
        PrizeMoney[2] = 100;


        ReputationRewards[0] = 10;
        ReputationRewards[1] = 3;
        ReputationRewards[2] = 1;
    }
}