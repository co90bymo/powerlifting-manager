public class YearlyInvitationalCompetition : Competition
{
    public override string CompetitionName =>
        "Yearly Invitational";


    public override string Description =>
        "A prestigious yearly invitational competition.";


    public YearlyInvitationalCompetition()
    {
        EntryFee = 100;


        RequiredReputation = 30;


        PrizeMoney[0] = 1000;
        PrizeMoney[1] = 500;
        PrizeMoney[2] = 250;


        ReputationRewards[0] = 25;
        ReputationRewards[1] = 10;
        ReputationRewards[2] = 2;
    }
}