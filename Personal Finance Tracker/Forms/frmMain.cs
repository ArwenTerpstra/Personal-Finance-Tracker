using System.Windows.Forms;
using System.Collections.Generic;
using Personal_Finance_Tracker.Models;
using Personal_Finance_Tracker.Forms;
using System.IO;
using System.Text.Json;
using System.Linq;
using System;
using System.Drawing;

namespace Personal_Finance_Tracker
{
    public partial class frmMain : Form
    {
        private List<Transaction> transactions = new List<Transaction>();
        private Budget userBudget = new Budget { MonthlyBudget = 0, CurrentExpenses = 0 };

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            string lastUsedFilePath = Properties.Settings.Default.LastUsedFilePath;

            if (lastUsedFilePath != string.Empty)
            {
                LoadTransactions(lastUsedFilePath);
            }

            RefreshDataGrid();
            UpdateSummary();
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

        private void UpdateBudgetStatus()
        {
            if (userBudget.MonthlyBudget > 0)
            {
                if (userBudget.IsExceeded)
                {
                    lblBudgetStatus.Text = $"Budget Exceeded! Overspent by ${Math.Abs(userBudget.RemainingBudget)}";
                    lblBudgetStatus.ForeColor = Color.Red;

                    if (userBudget.IsExceeded)
                    {
                        MessageBox.Show("You have exceeded your monthly budget!", "Budget Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    lblBudgetStatus.Text = $"Remaining Budget: ${userBudget.RemainingBudget}";
                    lblBudgetStatus.ForeColor = Color.Green;
                }
            }
            else
            {
                lblBudgetStatus.Text = "No budget set.";
                lblBudgetStatus.ForeColor = Color.Gray;
            }
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

            userBudget.CurrentExpenses = totalExpenses;

            lblTotalIncome.Text = $"Income: ${totalIncome}";
            lblTotalExpenses.Text = $"Expenses: ${totalExpenses}";
            lblBalance.Text = $"Balance: ${totalIncome - totalExpenses}";

            UpdateBudgetStatus();
        }

        private void UpdateFormTitle(string filePath)
        {
            this.Text = $"Personal Finance Tracker - {Path.GetFileName(filePath)}";
        }

        private void SaveTransactions(string filePath)
        {
            try
            {
                var saveData = new { Transactions = transactions, Budget = userBudget.MonthlyBudget };
                string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);

                Properties.Settings.Default.LastUsedFilePath = filePath;
                Properties.Settings.Default.Save();

                MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Failed to save transactions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransactions(string filePath) 
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    var loadData = JsonSerializer.Deserialize<SaveData>(json);

                    transactions = loadData?.Transactions ?? new List<Transaction>();
                    userBudget.MonthlyBudget = loadData?.Budget ?? 0;

                    Properties.Settings.Default.LastUsedFilePath = filePath;
                    Properties.Settings.Default.Save();

                    MessageBox.Show("Data loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Failed to load transactions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                transactions = new List<Transaction>();
                userBudget.MonthlyBudget = 0;
            }
            catch (JsonException ex) 
            {
                MessageBox.Show($"Failed to parse the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                transactions = new List<Transaction>();
                userBudget.MonthlyBudget = 0;
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

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) 
            {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Transactions File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    SaveTransactions(filePath);
                    UpdateFormTitle(filePath);
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                openFileDialog.Title = "Open Transactions File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    LoadTransactions(filePath);
                    RefreshDataGrid();
                    UpdateSummary();
                }
            }
        }

        private void btnSetBudget_Click(object sender, EventArgs e)
        {
            frmSetBudget frmSetBudget = new frmSetBudget(userBudget.MonthlyBudget);
            if (frmSetBudget.ShowDialog() == DialogResult.OK)
            {
                userBudget.MonthlyBudget = frmSetBudget.NewBudget;
                UpdateSummary();
            }
        }
    }
}
