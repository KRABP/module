namespace SimpleFinanceApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxTransactions = new System.Windows.Forms.ListBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblTotalIncome = new System.Windows.Forms.Label();
            this.lblTotalExpenses = new System.Windows.Forms.Label();
            this.lblCategoryStats = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSelectedDetails = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxTransactions
            // 
            this.listBoxTransactions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxTransactions.FormattingEnabled = true;
            this.listBoxTransactions.Location = new System.Drawing.Point(12, 73);
            this.listBoxTransactions.Name = "listBoxTransactions";
            this.listBoxTransactions.Size = new System.Drawing.Size(400, 160);
            this.listBoxTransactions.TabIndex = 0;
            this.listBoxTransactions.SelectedIndexChanged += new System.EventHandler(this.listBoxTransactions_SelectedIndexChanged);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBalance.Location = new System.Drawing.Point(12, 15);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(91, 20);
            this.lblBalance.TabIndex = 1;
            this.lblBalance.Text = "Баланс: 0";
            // 
            // lblTotalIncome
            // 
            this.lblTotalIncome.AutoSize = true;
            this.lblTotalIncome.ForeColor = System.Drawing.Color.Green;
            this.lblTotalIncome.Location = new System.Drawing.Point(12, 40);
            this.lblTotalIncome.Name = "lblTotalIncome";
            this.lblTotalIncome.Size = new System.Drawing.Size(59, 13);
            this.lblTotalIncome.TabIndex = 2;
            this.lblTotalIncome.Text = "Доходы: 0";
            // 
            // lblTotalExpenses
            // 
            this.lblTotalExpenses.AutoSize = true;
            this.lblTotalExpenses.ForeColor = System.Drawing.Color.Red;
            this.lblTotalExpenses.Location = new System.Drawing.Point(12, 55);
            this.lblTotalExpenses.Name = "lblTotalExpenses";
            this.lblTotalExpenses.Size = new System.Drawing.Size(63, 13);
            this.lblTotalExpenses.TabIndex = 3;
            this.lblTotalExpenses.Text = "Расходы: 0";
            // 
            // lblCategoryStats
            // 
            this.lblCategoryStats.AutoSize = true;
            this.lblCategoryStats.Location = new System.Drawing.Point(150, 40);
            this.lblCategoryStats.Name = "lblCategoryStats";
            this.lblCategoryStats.Size = new System.Drawing.Size(81, 13);
            this.lblCategoryStats.TabIndex = 4;
            this.lblCategoryStats.Text = "Топ расходы: -";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.numAmount);
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Location = new System.Drawing.Point(420, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 300);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление записями";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(100, 162);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(150, 20);
            this.dtpDate.TabIndex = 13;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 162);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "Дата:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Еда",
            "Транспорт",
            "Жилье",
            "Развлечения",
            "Здоровье",
            "Одежда",
            "Образование",
            "Зарплата",
            "Инвестиции",
            "Подарки",
            "Другое"});
            this.cmbCategory.Location = new System.Drawing.Point(100, 135);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(150, 21);
            this.cmbCategory.TabIndex = 11;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(6, 135);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 13);
            this.lblCategory.TabIndex = 10;
            this.lblCategory.Text = "Категория:";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Income",
            "Expense"});
            this.cmbType.Location = new System.Drawing.Point(100, 108);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(150, 21);
            this.cmbType.TabIndex = 9;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 108);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(29, 13);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Тип:";
            // 
            // numAmount
            // 
            this.numAmount.DecimalPlaces = 2;
            this.numAmount.Location = new System.Drawing.Point(100, 82);
            this.numAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(120, 20);
            this.numAmount.TabIndex = 7;
            this.numAmount.ThousandsSeparator = true;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(6, 82);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(44, 13);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Сумма:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(100, 56);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(230, 20);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 56);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Описание:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 260);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(105, 260);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(190, 260);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(275, 260);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 30);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblSelectedDetails
            // 
            this.lblSelectedDetails.AutoSize = true;
            this.lblSelectedDetails.Location = new System.Drawing.Point(12, 250);
            this.lblSelectedDetails.Name = "lblSelectedDetails";
            this.lblSelectedDetails.Size = new System.Drawing.Size(219, 13);
            this.lblSelectedDetails.TabIndex = 6;
            this.lblSelectedDetails.Text = "Выберите запись для просмотра деталей";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.lblSelectedDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCategoryStats);
            this.Controls.Add(this.lblTotalExpenses);
            this.Controls.Add(this.lblTotalIncome);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.listBoxTransactions);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учет финансов";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox listBoxTransactions;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblTotalIncome;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.Label lblCategoryStats;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSelectedDetails;
    }
}