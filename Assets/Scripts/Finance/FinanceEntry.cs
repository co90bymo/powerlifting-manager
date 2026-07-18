public class FinanceEntry
{
    public FinanceEntryType EntryType;
    public float Amount;
    public FinanceType Type;
    public bool TransactionCompleted;

    public FinanceEntry(
        FinanceEntryType entryType,
        float amount,
        FinanceType type,
        bool transactionCompleted)
    {
        EntryType = entryType;
        Amount = amount;
        Type = type;
        TransactionCompleted = transactionCompleted;
    }
}