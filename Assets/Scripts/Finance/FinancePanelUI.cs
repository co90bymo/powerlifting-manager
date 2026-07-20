using TMPro;
using UnityEngine;

public class FinancePanelUI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text currentBalanceText;
    [SerializeField] private TMP_Text nextWeekChangeText;
    [SerializeField] private TMP_Text competitionFeesText;
    [SerializeField] private TMP_Text totalFacilitiesCostText;
    [SerializeField] private TMP_Text pendingPaymentsText;


    private void OnEnable()
    {
        Refresh();
    }


    public void Refresh()
    {
        DisplayCurrentBalance();
        DisplayNextWeekChange();
        DisplayCompetitionFees();
        DisplayTotalFacilitiesCost();
        DisplayPendingPayments();
    }



    private void DisplayCurrentBalance()
    {
        currentBalanceText.text =
            $"{GameManager.Instance.CurrentState.PlayerClub.Money:F0} $";
    }



    private void DisplayNextWeekChange()
    {
        float income =
            GameManager.Instance.FinanceManager.GetWeeklyIncome();

        float expenses =
            GameManager.Instance.FinanceManager.GetWeeklyExpenses();

        float net = income - expenses;

        string sign = net >= 0 ? "+" : "";

        nextWeekChangeText.text =
            $"{sign}{net:F0} $";
    }



    private void DisplayCompetitionFees()
    {
        float competitionFees =
            GameManager.Instance.FinanceManager.GetAmount(
                FinanceEntryType.CompetitionEntryFee
            );

        if (competitionFees <= 0)
        {
            competitionFeesText.text = "0 $";
        }
        else
        {
            competitionFeesText.text =
                $"-{competitionFees:F0} $ (Paid)";
        }
    }



    private void DisplayTotalFacilitiesCost()
    {
        float totalCost = 0;

        foreach (Facility facility in
                 GameManager.Instance.CurrentState.PlayerClub.Facilities)
        {
            if (!facility.Owner)
                continue;

            totalCost += facility.WeeklyCost;
            totalCost += facility.MaintenanceCost;
        }

        totalFacilitiesCostText.text =
            $"-{totalCost:F0} $";
    }



    private void DisplayPendingPayments()
    {
        float pending = 0;

        foreach (FinanceEntry entry in
                 GameManager.Instance.FinanceManager.Entries)
        {
            if (!entry.TransactionCompleted &&
                entry.Type == FinanceType.Expense)
            {
                pending += entry.Amount;
            }
        }

        if (pending <= 0)
        {
            pendingPaymentsText.text = "0 $";
        }
        else
        {
            pendingPaymentsText.text =
                $"-{pending:F0} $";
        }
    }
}