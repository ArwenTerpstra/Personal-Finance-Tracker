using System.Windows.Forms;
using System.Collections.Generic;
using Personal_Finance_Tracker.Models;
using Personal_Finance_Tracker.Forms;
using System.IO;
using System.Text.Json;
using System.Linq;
using System;

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

            lblTotalIncome.Text = $"Income: ${totalIncome}";
            lblTotalExpenses.Text = $"Expenses: ${totalExpenses}";
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

        private void ApplyFiltersAndSort(string sortBy = "Date", bool ascending = true)
        {
            List<Transaction> filteredTransactions = transactions;

            if (dtpFromDate.Value <= dtpToDate.Value)
            {
                filteredTransactions = filteredTransactions
                    .Where(t => t.Date >= dtpFromDate.Value && t.Date <= dtpToDate.Value)
                    .ToList();
            }

            if (cbxFilterCategory.SelectedItem != null && cbxFilterCategory.SelectedItem.ToString() != "All")
            {
                filteredTransactions = filteredTransactions
                    .Where(t => t.Category == cbxFilterCategory.SelectedItem.ToString())
                    .ToList();
            }

            if (chbShowIncomeOnly.Checked)
            { 
                filteredTransactions = filteredTransactions
                    .Where(t => t.IsIncome)
                    .ToList();
            }
            else if (chbShowExpensesOnly.Checked)
            {
                filteredTransactions = filteredTransactions
                    .Where(t => !t.IsIncome)
                    .ToList();
            }

            switch (sortBy)
            {
                case "Date":
                    filteredTransactions = ascending
                        ? filteredTransactions.OrderBy(t => t.Date).ToList()
                        : filteredTransactions.OrderByDescending(t => t.Date).ToList();
                    break;

                case "Amount":
                    filteredTransactions = ascending
                        ? filteredTransactions.OrderBy(t => t.Amount).ToList()
                        : filteredTransactions.OrderByDescending(t => t.Amount).ToList();
                    break;
                case "Category":
                    filteredTransactions = ascending
                        ? filteredTransactions.OrderBy(t => t.Category).ToList()
                        : filteredTransactions.OrderByDescending(t => t.Category).ToList();
                    break;
            }

            dgvTransactions.DataSource = null;
            dgvTransactions.DataSource = filteredTransactions;
        }
        private void ApplyFiltersAndSortWithCurrentSettings()
        {
            string sortBy = cbxSortBy.SelectedItem?.ToString() ?? string.Empty;
            bool ascending = chkSortAscending.Checked;

            if (!string.IsNullOrEmpty(sortBy))
            {
                ApplyFiltersAndSort(sortBy, ascending);
            }
        }

        private void chbShowIncomeOnly_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chbShowIncomeOnly.Checked)
            {
                chbShowExpensesOnly.Checked = false;
            }
            ApplyFiltersAndSortWithCurrentSettings();
        }
        private void chbShowExpensesOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShowExpensesOnly.Checked)
            {
                chbShowIncomeOnly.Checked = false;
            }
            ApplyFiltersAndSortWithCurrentSettings();
        }

        private void cbxFilterCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ApplyFiltersAndSortWithCurrentSettings();
        }

        private void dtpFromDate_ValueChanged(object sender, System.EventArgs e)
        {
            ApplyFiltersAndSortWithCurrentSettings();
        }

        private void dtpToDate_ValueChanged(object sender, System.EventArgs e)
        {
            ApplyFiltersAndSortWithCurrentSettings();
        }

        private void btnResetFilters_Click(object sender, System.EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now.AddMonths(-12);
            dtpToDate.Value = DateTime.Now.AddMonths(12);
            cbxFilterCategory.SelectedIndex = 0;
            chbShowIncomeOnly.Checked = false;
            chbShowExpensesOnly.Checked = false;

            cbxSortBy.SelectedIndex = 0;
            chkSortAscending.Checked = false;

            ApplyFiltersAndSortWithCurrentSettings();
        }

        private void cbxSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSortWithCurrentSettings();
        }

        private void chkSortAscending_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSortWithCurrentSettings();
        }
    }
}
