public class YearlyInvitationalCompetition : Competition
{
    public override string CompetitionName =>
        "Yearly Invitational";

    public override string Description =>
        "A prestigious yearly invitational competition.";

    public YearlyInvitationalCompetition()
    {
        // Change to 0 later, this is just for test
        EntryFee = 100;
    }
}