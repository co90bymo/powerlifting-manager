public class Gym : Facility
{
    public Gym()
    {
        FacilityType = FacilityType.Gym;

        FinanceEntryType = FinanceEntryType.GymRent;

        WeeklyCost = 100;

        MaintenanceCost = 0;

        Owner = true;
    }



    public override FinanceEntry CreateWeeklyFinanceEntry()
    {
        return new FinanceEntry(
            FinanceEntryType,
            WeeklyCost + MaintenanceCost,
            FinanceType.Expense,
            false
        );
    }
}