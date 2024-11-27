using System.Windows.Forms;
using System.Collections.Generic;
using Personal_Finance_Tracker.Models;
using Personal_Finance_Tracker.Forms;
using System.IO;
using System.Text.Json;

namespace Personal_Finance_Tracker
{
    public partial class frmMain : Form
    {
        private List<Transaction> transactions = new List<Transaction>();
        private string dataFilePath = "transactions.json";

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            LoadTransactions();
            RefreshDataGrid();
            UpdateSummary();
        }

        private void btnAddTransaction_Click(object sender, System.EventArgs e)
        {
            frmAddTransaction frmAddTransaction = new frmAddTransaction();
            if (frmAddTransaction.ShowDialog() == DialogResult.OK)
            {
                transactions.Add(frmAddTransaction.NewTransaction);
                SaveTransactions();
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

        private void SaveTransactions()
        {
            try
            {
                string json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(dataFilePath, json);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Failed to save transactions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransactions() 
        {
            try 
            {
                if (File.Exists(dataFilePath))
                {
                    string json = File.ReadAllText(dataFilePath);
                    transactions = JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();

                }
            }
            catch (IOException ex) 
            {
                MessageBox.Show($"Failed to load transactions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                transactions = new List<Transaction>();
            }
        }
    }
}
