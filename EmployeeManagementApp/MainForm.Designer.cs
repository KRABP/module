namespace EmployeeManagementApp
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.lblDetailAddress = new System.Windows.Forms.Label();
            this.lblDetailPhone = new System.Windows.Forms.Label();
            this.lblDetailEmail = new System.Windows.Forms.Label();
            this.lblDetailHireDate = new System.Windows.Forms.Label();
            this.lblDetailSalary = new System.Windows.Forms.Label();
            this.lblDetailDepartment = new System.Windows.Forms.Label();
            this.lblDetailPosition = new System.Windows.Forms.Label();
            this.lblDetailName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelList = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblDeptStats = new System.Windows.Forms.Label();
            this.lblSalaryRange = new System.Windows.Forms.Label();
            this.lblAvgSalary = new System.Windows.Forms.Label();
            this.lblTotalEmployees = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelControls.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();

            // menuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(984, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";

            // helpToolStripMenuItem
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "&Справка";

            // aboutToolStripMenuItem
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "&О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);

            // panelMain
            this.panelMain.Controls.Add(this.splitContainer);
            this.panelMain.Controls.Add(this.panelStats);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(984, 537);
            this.panelMain.TabIndex = 1;

            // splitContainer
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 80);
            this.splitContainer.Name = "splitContainer";

            // splitContainer.Panel1
            this.splitContainer.Panel1.Controls.Add(this.panelDetails);
            this.splitContainer.Panel1.Controls.Add(this.panelList);
            this.splitContainer.Panel1.Controls.Add(this.panelControls);

            // splitContainer.Panel2
            this.splitContainer.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer.Size = new System.Drawing.Size(984, 457);
            this.splitContainer.SplitterDistance = 400;
            this.splitContainer.TabIndex = 1;

            // panelDetails
            this.panelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetails.Controls.Add(this.lblDetailAddress);
            this.panelDetails.Controls.Add(this.lblDetailPhone);
            this.panelDetails.Controls.Add(this.lblDetailEmail);
            this.panelDetails.Controls.Add(this.lblDetailHireDate);
            this.panelDetails.Controls.Add(this.lblDetailSalary);
            this.panelDetails.Controls.Add(this.lblDetailDepartment);
            this.panelDetails.Controls.Add(this.lblDetailPosition);
            this.panelDetails.Controls.Add(this.lblDetailName);
            this.panelDetails.Controls.Add(this.label8);
            this.panelDetails.Controls.Add(this.label7);
            this.panelDetails.Controls.Add(this.label6);
            this.panelDetails.Controls.Add(this.label5);
            this.panelDetails.Controls.Add(this.label4);
            this.panelDetails.Controls.Add(this.label3);
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.label1);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 200);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(400, 257);
            this.panelDetails.TabIndex = 2;

            // lblDetailAddress
            this.lblDetailAddress.AutoSize = true;
            this.lblDetailAddress.Location = new System.Drawing.Point(120, 210);
            this.lblDetailAddress.Name = "lblDetailAddress";
            this.lblDetailAddress.Size = new System.Drawing.Size(0, 13);
            this.lblDetailAddress.TabIndex = 15;

            // lblDetailPhone
            this.lblDetailPhone.AutoSize = true;
            this.lblDetailPhone.Location = new System.Drawing.Point(120, 180);
            this.lblDetailPhone.Name = "lblDetailPhone";
            this.lblDetailPhone.Size = new System.Drawing.Size(0, 13);
            this.lblDetailPhone.TabIndex = 14;

            // lblDetailEmail
            this.lblDetailEmail.AutoSize = true;
            this.lblDetailEmail.Location = new System.Drawing.Point(120, 150);
            this.lblDetailEmail.Name = "lblDetailEmail";
            this.lblDetailEmail.Size = new System.Drawing.Size(0, 13);
            this.lblDetailEmail.TabIndex = 13;

            // lblDetailHireDate
            this.lblDetailHireDate.AutoSize = true;
            this.lblDetailHireDate.Location = new System.Drawing.Point(120, 120);
            this.lblDetailHireDate.Name = "lblDetailHireDate";
            this.lblDetailHireDate.Size = new System.Drawing.Size(0, 13);
            this.lblDetailHireDate.TabIndex = 12;

            // lblDetailSalary
            this.lblDetailSalary.AutoSize = true;
            this.lblDetailSalary.Location = new System.Drawing.Point(120, 90);
            this.lblDetailSalary.Name = "lblDetailSalary";
            this.lblDetailSalary.Size = new System.Drawing.Size(0, 13);
            this.lblDetailSalary.TabIndex = 11;

            // lblDetailDepartment
            this.lblDetailDepartment.AutoSize = true;
            this.lblDetailDepartment.Location = new System.Drawing.Point(120, 60);
            this.lblDetailDepartment.Name = "lblDetailDepartment";
            this.lblDetailDepartment.Size = new System.Drawing.Size(0, 13);
            this.lblDetailDepartment.TabIndex = 10;

            // lblDetailPosition
            this.lblDetailPosition.AutoSize = true;
            this.lblDetailPosition.Location = new System.Drawing.Point(120, 30);
            this.lblDetailPosition.Name = "lblDetailPosition";
            this.lblDetailPosition.Size = new System.Drawing.Size(0, 13);
            this.lblDetailPosition.TabIndex = 9;

            // lblDetailName
            this.lblDetailName.AutoSize = true;
            this.lblDetailName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDetailName.Location = new System.Drawing.Point(120, 10);
            this.lblDetailName.Name = "lblDetailName";
            this.lblDetailName.Size = new System.Drawing.Size(128, 15);
            this.lblDetailName.TabIndex = 8;
            this.lblDetailName.Text = "Выберите сотрудника";

            // label8
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(20, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Адрес:";

            // label7
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(20, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Телефон:";

            // label6
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(20, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Email:";

            // label5
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(20, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Дата приема:";

            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(20, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Зарплата:";

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(20, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отдел:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(20, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Должность:";

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сотрудник:";

            // panelList
            this.panelList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelList.Controls.Add(this.btnRefresh);
            this.panelList.Controls.Add(this.txtSearch);
            this.panelList.Controls.Add(this.lblSearch);
            this.panelList.Controls.Add(this.btnDelete);
            this.panelList.Controls.Add(this.btnEdit);
            this.panelList.Controls.Add(this.btnAdd);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelList.Location = new System.Drawing.Point(0, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(400, 200);
            this.panelList.TabIndex = 1;

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(300, 160);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(80, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 20);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(20, 23);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Поиск:";

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(200, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(100, 160);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(20, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // panelControls
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(0, 457);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(400, 0);
            this.panelControls.TabIndex = 0;

            // dataGridView
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(580, 457);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);

            // panelStats
            this.panelStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStats.Controls.Add(this.lblDeptStats);
            this.panelStats.Controls.Add(this.lblSalaryRange);
            this.panelStats.Controls.Add(this.lblAvgSalary);
            this.panelStats.Controls.Add(this.lblTotalEmployees);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 0);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(984, 80);
            this.panelStats.TabIndex = 0;

            // lblDeptStats
            this.lblDeptStats.AutoSize = true;
            this.lblDeptStats.Location = new System.Drawing.Point(20, 55);
            this.lblDeptStats.Name = "lblDeptStats";
            this.lblDeptStats.Size = new System.Drawing.Size(54, 13);
            this.lblDeptStats.TabIndex = 3;
            this.lblDeptStats.Text = "Отделы: -";

            // lblSalaryRange
            this.lblSalaryRange.AutoSize = true;
            this.lblSalaryRange.Location = new System.Drawing.Point(300, 25);
            this.lblSalaryRange.Name = "lblSalaryRange";
            this.lblSalaryRange.Size = new System.Drawing.Size(105, 13);
            this.lblSalaryRange.TabIndex = 2;
            this.lblSalaryRange.Text = "Диапазон зарплат: -";

            // lblAvgSalary
            this.lblAvgSalary.AutoSize = true;
            this.lblAvgSalary.Location = new System.Drawing.Point(150, 25);
            this.lblAvgSalary.Name = "lblAvgSalary";
            this.lblAvgSalary.Size = new System.Drawing.Size(97, 13);
            this.lblAvgSalary.TabIndex = 1;
            this.lblAvgSalary.Text = "Средняя зарплата: -";

            // lblTotalEmployees
            this.lblTotalEmployees.AutoSize = true;
            this.lblTotalEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalEmployees.Location = new System.Drawing.Point(20, 25);
            this.lblTotalEmployees.Name = "lblTotalEmployees";
            this.lblTotalEmployees.Size = new System.Drawing.Size(124, 15);
            this.lblTotalEmployees.TabIndex = 0;
            this.lblTotalEmployees.Text = "Всего сотрудников: 0";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учет сотрудников";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panelList.ResumeLayout(false);
            this.panelList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblDetailAddress;
        private System.Windows.Forms.Label lblDetailPhone;
        private System.Windows.Forms.Label lblDetailEmail;
        private System.Windows.Forms.Label lblDetailHireDate;
        private System.Windows.Forms.Label lblDetailSalary;
        private System.Windows.Forms.Label lblDetailDepartment;
        private System.Windows.Forms.Label lblDetailPosition;
        private System.Windows.Forms.Label lblDetailName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblDeptStats;
        private System.Windows.Forms.Label lblSalaryRange;
        private System.Windows.Forms.Label lblAvgSalary;
        private System.Windows.Forms.Label lblTotalEmployees;
    }
}