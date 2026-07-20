using System.Collections.Generic;
using UnityEngine;

public class FinanceManager
{
    private List<FinanceEntry> entries = new();


    public IReadOnlyList<FinanceEntry> Entries => entries;



    public void AddIncome(
        FinanceEntryType entryType,
        float amount,
        bool completed)
    {
        entries.Add(
            new FinanceEntry(
                entryType,
                amount,
                FinanceType.Income,
                completed
            )
        );


        if (completed)
        {
            GameManager.Instance.CurrentState.PlayerClub.Money += amount;
        }
    }



    public bool CanAfford(float amount)
    {
        return GameManager.Instance.CurrentState.PlayerClub.Money >= amount;
    }



    public bool TryAddExpense(
        FinanceEntryType entryType,
        float amount,
        bool completed)
    {
        if (completed && !CanAfford(amount))
        {
            return false;
        }


        entries.Add(
            new FinanceEntry(
                entryType,
                amount,
                FinanceType.Expense,
                completed
            )
        );


        if (completed)
        {
            GameManager.Instance.CurrentState.PlayerClub.Money -= amount;
        }


        return true;
    }



    public void ProcessWeekFinances()
    {
        float income = GetWeeklyIncome();
        float expenses = GetWeeklyExpenses();


        UnityEngine.Debug.Log(
            $"Weekly finances: +{income} income, -{expenses} expenses"
        );


        ClearWeek();
    }



    public void ClearWeek()
    {
        entries.Clear();
    }



    public float GetWeeklyIncome()
    {
        float total = 0;


        foreach (FinanceEntry entry in entries)
        {
            if (entry.Type == FinanceType.Income)
                total += entry.Amount;
        }


        return total;
    }



    public float GetWeeklyExpenses()
    {
        float total = 0;


        foreach (FinanceEntry entry in entries)
        {
            if (entry.Type == FinanceType.Expense)
                total += entry.Amount;
        }


        return total;
    }



    public float GetAmount(FinanceEntryType entryType)
    {
        float total = 0;


        foreach (FinanceEntry entry in entries)
        {
            if (entry.EntryType == entryType)
            {
                total += entry.Amount;
            }
        }


        return total;
    }



    public void ApplyPendingTransactions()
    {
        foreach (FinanceEntry entry in entries)
        {
            if (entry.TransactionCompleted)
                continue;


            if (entry.Type == FinanceType.Income)
            {
                GameManager.Instance.CurrentState.PlayerClub.Money += entry.Amount;
            }
            else if (entry.Type == FinanceType.Expense)
            {
                GameManager.Instance.CurrentState.PlayerClub.Money -= entry.Amount;
            }


            entry.TransactionCompleted = true;
        }

        ClearWeek();
    }
}