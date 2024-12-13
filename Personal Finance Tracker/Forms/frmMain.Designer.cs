namespace Personal_Finance_Tracker
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.lblTotalIncome = new System.Windows.Forms.Label();
            this.lblTotalExpenses = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbShowExpensesOnly = new System.Windows.Forms.CheckBox();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.chbShowIncomeOnly = new System.Windows.Forms.CheckBox();
            this.cbxFilterCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxSortBy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkSortAscending = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSetBudget = new System.Windows.Forms.Button();
            this.lblBudgetStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(12, 12);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.Size = new System.Drawing.Size(542, 426);
            this.dgvTransactions.TabIndex = 0;
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.Location = new System.Drawing.Point(12, 444);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(99, 23);
            this.btnAddTransaction.TabIndex = 1;
            this.btnAddTransaction.Text = "Add Transaction";
            this.btnAddTransaction.UseVisualStyleBackColor = true;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(12, 473);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(99, 23);
            this.btnSaveAs.TabIndex = 2;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 502);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(99, 23);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // lblTotalIncome
            // 
            this.lblTotalIncome.AutoSize = true;
            this.lblTotalIncome.Location = new System.Drawing.Point(6, 16);
            this.lblTotalIncome.Name = "lblTotalIncome";
            this.lblTotalIncome.Size = new System.Drawing.Size(60, 13);
            this.lblTotalIncome.TabIndex = 4;
            this.lblTotalIncome.Text = "Income: $0";
            // 
            // lblTotalExpenses
            // 
            this.lblTotalExpenses.AutoSize = true;
            this.lblTotalExpenses.Location = new System.Drawing.Point(6, 35);
            this.lblTotalExpenses.Name = "lblTotalExpenses";
            this.lblTotalExpenses.Size = new System.Drawing.Size(71, 13);
            this.lblTotalExpenses.TabIndex = 5;
            this.lblTotalExpenses.Text = "Expenses: $0";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(6, 96);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(64, 13);
            this.lblBalance.TabIndex = 6;
            this.lblBalance.Text = "Balance: $0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chbShowExpensesOnly);
            this.groupBox1.Controls.Add(this.btnResetFilters);
            this.groupBox1.Controls.Add(this.chbShowIncomeOnly);
            this.groupBox1.Controls.Add(this.cbxFilterCategory);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Location = new System.Drawing.Point(117, 444);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 212);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Category";
            // 
            // chbShowExpensesOnly
            // 
            this.chbShowExpensesOnly.AutoSize = true;
            this.chbShowExpensesOnly.Location = new System.Drawing.Point(121, 118);
            this.chbShowExpensesOnly.Name = "chbShowExpensesOnly";
            this.chbShowExpensesOnly.Size = new System.Drawing.Size(96, 17);
            this.chbShowExpensesOnly.TabIndex = 7;
            this.chbShowExpensesOnly.Text = "Expenses Only";
            this.chbShowExpensesOnly.UseVisualStyleBackColor = true;
            this.chbShowExpensesOnly.CheckedChanged += new System.EventHandler(this.chbShowExpensesOnly_CheckedChanged);
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Location = new System.Drawing.Point(63, 183);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(121, 23);
            this.btnResetFilters.TabIndex = 6;
            this.btnResetFilters.Text = "Reset";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // chbShowIncomeOnly
            // 
            this.chbShowIncomeOnly.AutoSize = true;
            this.chbShowIncomeOnly.Location = new System.Drawing.Point(9, 118);
            this.chbShowIncomeOnly.Name = "chbShowIncomeOnly";
            this.chbShowIncomeOnly.Size = new System.Drawing.Size(85, 17);
            this.chbShowIncomeOnly.TabIndex = 5;
            this.chbShowIncomeOnly.Text = "Income Only";
            this.chbShowIncomeOnly.UseVisualStyleBackColor = true;
            this.chbShowIncomeOnly.CheckedChanged += new System.EventHandler(this.chbShowIncomeOnly_CheckedChanged);
            // 
            // cbxFilterCategory
            // 
            this.cbxFilterCategory.FormattingEnabled = true;
            this.cbxFilterCategory.Items.AddRange(new object[] {
            "All",
            "Income",
            "Housing",
            "Food",
            "Utilities",
            "Fitness",
            "Investment",
            "Transportation",
            "Educations",
            "Savings",
            "Entertainment"});
            this.cbxFilterCategory.Location = new System.Drawing.Point(121, 74);
            this.cbxFilterCategory.Name = "cbxFilterCategory";
            this.cbxFilterCategory.Size = new System.Drawing.Size(121, 21);
            this.cbxFilterCategory.TabIndex = 4;
            this.cbxFilterCategory.Text = "All";
            this.cbxFilterCategory.SelectedIndexChanged += new System.EventHandler(this.cbxFilterCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(42, 48);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 20);
            this.dtpToDate.TabIndex = 1;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(42, 22);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 20);
            this.dtpFromDate.TabIndex = 0;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblBalance);
            this.groupBox3.Controls.Add(this.lblTotalExpenses);
            this.groupBox3.Controls.Add(this.lblTotalIncome);
            this.groupBox3.Location = new System.Drawing.Point(12, 531);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(99, 119);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total";
            // 
            // cbxSortBy
            // 
            this.cbxSortBy.FormattingEnabled = true;
            this.cbxSortBy.Items.AddRange(new object[] {
            "None",
            "Amount",
            "Category",
            "Date"});
            this.cbxSortBy.Location = new System.Drawing.Point(375, 475);
            this.cbxSortBy.Name = "cbxSortBy";
            this.cbxSortBy.Size = new System.Drawing.Size(167, 21);
            this.cbxSortBy.TabIndex = 0;
            this.cbxSortBy.Text = "None";
            this.cbxSortBy.SelectedIndexChanged += new System.EventHandler(this.cbxSortBy_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sort by";
            // 
            // chkSortAscending
            // 
            this.chkSortAscending.AutoSize = true;
            this.chkSortAscending.Location = new System.Drawing.Point(375, 502);
            this.chkSortAscending.Name = "chkSortAscending";
            this.chkSortAscending.Size = new System.Drawing.Size(76, 17);
            this.chkSortAscending.TabIndex = 9;
            this.chkSortAscending.Text = "Ascending";
            this.chkSortAscending.UseVisualStyleBackColor = true;
            this.chkSortAscending.CheckedChanged += new System.EventHandler(this.chkSortAscending_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSetBudget
            // 
            this.btnSetBudget.Location = new System.Drawing.Point(375, 627);
            this.btnSetBudget.Name = "btnSetBudget";
            this.btnSetBudget.Size = new System.Drawing.Size(167, 23);
            this.btnSetBudget.TabIndex = 9;
            this.btnSetBudget.Text = "Set Budget";
            this.btnSetBudget.UseVisualStyleBackColor = true;
            this.btnSetBudget.Click += new System.EventHandler(this.btnSetBudget_Click);
            // 
            // lblBudgetStatus
            // 
            this.lblBudgetStatus.AutoSize = true;
            this.lblBudgetStatus.Location = new System.Drawing.Point(372, 578);
            this.lblBudgetStatus.Name = "lblBudgetStatus";
            this.lblBudgetStatus.Size = new System.Drawing.Size(74, 13);
            this.lblBudgetStatus.TabIndex = 10;
            this.lblBudgetStatus.Text = "Budget Status";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 668);
            this.Controls.Add(this.lblBudgetStatus);
            this.Controls.Add(this.btnSetBudget);
            this.Controls.Add(this.chkSortAscending);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxSortBy);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnAddTransaction);
            this.Controls.Add(this.dgvTransactions);
            this.Name = "frmMain";
            this.Text = "Personal Finance Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label lblTotalIncome;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.ComboBox cbxFilterCategory;
        private System.Windows.Forms.CheckBox chbShowIncomeOnly;
        private System.Windows.Forms.CheckBox chbShowExpensesOnly;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbxSortBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkSortAscending;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSetBudget;
        private System.Windows.Forms.Label lblBudgetStatus;
    }
}

