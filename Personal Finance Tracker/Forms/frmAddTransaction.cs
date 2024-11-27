using System;
using System.Windows.Forms;
using Personal_Finance_Tracker.Models;

namespace Personal_Finance_Tracker.Forms
{
    public partial class frmAddTransaction : Form
    {
        public Transaction NewTransaction { get; private set; }

        public frmAddTransaction()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxDescription.Text)) 
            {
                MessageBox.Show("Description cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbxCategory.SelectedItem == null) 
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudAmount.Value == 0)
            {
                MessageBox.Show("Amount cannot be zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NewTransaction = new Transaction
            {
                Date = dtpDate.Value,
                Description = tbxDescription.Text.Trim(),
                Amount = (double)Math.Abs(nudAmount.Value),
                Category = cbxCategory.SelectedItem.ToString(),
                IsIncome = nudAmount.Value >= 0
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
