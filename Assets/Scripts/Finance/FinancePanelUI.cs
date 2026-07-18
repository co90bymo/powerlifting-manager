using TMPro;
using UnityEngine;

public class FinancePanelUI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text currentBalanceText;
    [SerializeField] private TMP_Text nextWeekChangeText;
    [SerializeField] private TMP_Text competitionFeesText;


    private void OnEnable() 
    {
        Refresh();
    }

    public void Refresh()
    {
        DisplayCurrentBalance();
        DisplayNextWeekChange();
        DisplayCompetitionFees();
    }


    private void DisplayCurrentBalance()
    {
        currentBalanceText.text =
            $"{GameManager.Instance.CurrentState.Money:F0} $";
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
            $" {sign}{net:F0} $";
    }


    private void DisplayCompetitionFees()
    {
        float competitionFees =
            GameManager.Instance.FinanceManager.GetAmount(
                FinanceEntryType.CompetitionEntryFee
            );

        competitionFeesText.text =
            $"-{competitionFees:F0} $";
    }
}