using System;
using System.Windows.Forms;

namespace Personal_Finance_Tracker.Forms
{
    public partial class frmSetBudget : Form
    {
        public double NewBudget { get; private set; }

        public frmSetBudget(double currentBudget)
        {
            InitializeComponent();
            nudBudget.Value = (decimal)currentBudget;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NewBudget = (double)nudBudget.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
