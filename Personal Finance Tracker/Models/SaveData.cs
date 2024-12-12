using System.Collections.Generic;

namespace Personal_Finance_Tracker.Models
{
    public class SaveData
    {
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public double Budget { get; set; } = 0;
    }
}
