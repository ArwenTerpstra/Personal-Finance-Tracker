using System.Windows.Forms;
using System.Collections.Generic;
using Personal_Finance_Tracker.Models;
using Personal_Finance_Tracker.Forms;

namespace Personal_Finance_Tracker
{
    // Comment to test github...
    public partial class frmMain : Form
    {
        private List<Transaction> transactions = new List<Transaction>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {

        }

        private void btnAddTransaction_Click(object sender, System.EventArgs e)
        {
            frmAddTransaction frmAddTransaction = new frmAddTransaction();
            if (frmAddTransaction.ShowDialog() == DialogResult.OK)
            {
                transactions.Add(frmAddTransaction.NewTransaction);
                RefreshDataGrid();
                UpdateSummary();
            }
        }
        private void RefreshDataGrid()
        {
            dgvTransactions.DataSource = null;
            dgvTransactions.DataSource = transactions;
        }

        private void UpdateSummary()
        {
            double totalIncome = 0;
            double totalExpenses = 0;

            foreach (Transaction transaction in transactions)
            {
                if (transaction.IsIncome)
                {
                    totalIncome += transaction.Amount;
                }
                else
                {
                    totalExpenses += transaction.Amount;
                }
            }

            lblTotalIncome.Text = $"Total Income: ${totalIncome}";
            lblTotalExpenses.Text = $"Total Expenses: ${totalExpenses}";
            lblBalance.Text = $"Balance: ${totalIncome - totalExpenses}";
        }
    }
}
