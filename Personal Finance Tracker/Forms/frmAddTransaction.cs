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
            NewTransaction = new Transaction
            {
                Date = dtpDate.Value,
                Description = tbxDescription.Text,
                Amount = (double) nudAmount.Value,
                Category = cbxCategory.SelectedItem.ToString()
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
