using System;

namespace Personal_Finance_Tracker.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public bool IsIncome => Amount >= 0;
    }
}
