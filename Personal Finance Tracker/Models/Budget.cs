namespace Personal_Finance_Tracker.Models
{
    public class Budget
    {
        public double MonthlyBudget { get; set; }
        public double CurrentExpenses { get; set; }
        public bool IsExceeded => CurrentExpenses > MonthlyBudget;
        public double RemainingBudget => MonthlyBudget - CurrentExpenses;
    }
}
