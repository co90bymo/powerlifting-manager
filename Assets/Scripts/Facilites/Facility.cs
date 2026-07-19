public class Facility
{
    public FacilityType FacilityType;
    public float WeeklyCost;
    public float MaintenanceCost;
    public FinanceEntryType FinanceEntryType;
    public bool Owner;


    public virtual void ChangeOwner(bool owned)
    {
        Owner = owned;
    }


    public virtual FinanceEntry CreateWeeklyFinanceEntry()
    {
        return new FinanceEntry(
            FinanceEntryType,
            WeeklyCost,
            FinanceType.Expense,
            false
        );
    }
}