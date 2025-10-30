namespace TaskManagerOOP
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxTasks;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnInProgress;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.ComboBox cmbPriorityFilter;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private System.Windows.Forms.ComboBox cmbSortBy;
        private System.Windows.Forms.CheckBox chkDescending;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;

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
            this.listBoxTasks = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnInProgress = new System.Windows.Forms.Button();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.cmbPriorityFilter = new System.Windows.Forms.ComboBox();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.chkDescending = new System.Windows.Forms.CheckBox();
            this.lblStats = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxTasks
            // 
            this.listBoxTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxTasks.FormattingEnabled = true;
            this.listBoxTasks.Location = new System.Drawing.Point(9, 130);
            this.listBoxTasks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxTasks.Name = "listBoxTasks";
            this.listBoxTasks.Size = new System.Drawing.Size(264, 342);
            this.listBoxTasks.TabIndex = 0;
            this.listBoxTasks.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxTasks_DrawItem);
            this.listBoxTasks.SelectedIndexChanged += new System.EventHandler(this.listBoxTasks_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(9, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(583, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(277, 155);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Добавить задачу";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.Goldenrod;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(278, 187);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 28);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Редактировать задачу";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(278, 219);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 28);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComplete.BackColor = System.Drawing.Color.SeaGreen;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(278, 251);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(90, 28);
            this.btnComplete.TabIndex = 5;
            this.btnComplete.Text = "Завершенный";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnInProgress
            // 
            this.btnInProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInProgress.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnInProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInProgress.ForeColor = System.Drawing.Color.White;
            this.btnInProgress.Location = new System.Drawing.Point(278, 283);
            this.btnInProgress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInProgress.Name = "btnInProgress";
            this.btnInProgress.Size = new System.Drawing.Size(90, 28);
            this.btnInProgress.TabIndex = 6;
            this.btnInProgress.Text = "В процессе";
            this.btnInProgress.UseVisualStyleBackColor = false;
            this.btnInProgress.Click += new System.EventHandler(this.btnInProgress_Click);
            // 
            // txtDetails
            // 
            this.txtDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetails.BackColor = System.Drawing.Color.White;
            this.txtDetails.Location = new System.Drawing.Point(370, 130);
            this.txtDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(222, 342);
            this.txtDetails.TabIndex = 7;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(2, 2);
            this.cmbStatusFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(84, 21);
            this.cmbStatusFilter.TabIndex = 8;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);
            // 
            // cmbPriorityFilter
            // 
            this.cmbPriorityFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriorityFilter.FormattingEnabled = true;
            this.cmbPriorityFilter.Location = new System.Drawing.Point(89, 2);
            this.cmbPriorityFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPriorityFilter.Name = "cmbPriorityFilter";
            this.cmbPriorityFilter.Size = new System.Drawing.Size(84, 21);
            this.cmbPriorityFilter.TabIndex = 9;
            this.cmbPriorityFilter.SelectedIndexChanged += new System.EventHandler(this.cmbPriorityFilter_SelectedIndexChanged);
            // 
            // cmbCategoryFilter
            // 
            this.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.FormattingEnabled = true;
            this.cmbCategoryFilter.Location = new System.Drawing.Point(176, 2);
            this.cmbCategoryFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCategoryFilter.Name = "cmbCategoryFilter";
            this.cmbCategoryFilter.Size = new System.Drawing.Size(84, 21);
            this.cmbCategoryFilter.TabIndex = 10;
            this.cmbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cmbCategoryFilter_SelectedIndexChanged);
            // 
            // cmbSortBy
            // 
            this.cmbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortBy.FormattingEnabled = true;
            this.cmbSortBy.Items.AddRange(new object[] {
            "Title",
            "Priority",
            "Due Date",
            "Status",
            "Category"});
            this.cmbSortBy.Location = new System.Drawing.Point(2, 2);
            this.cmbSortBy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbSortBy.Name = "cmbSortBy";
            this.cmbSortBy.Size = new System.Drawing.Size(84, 21);
            this.cmbSortBy.TabIndex = 11;
            this.cmbSortBy.SelectedIndexChanged += new System.EventHandler(this.cmbSortBy_SelectedIndexChanged);
            // 
            // chkDescending
            // 
            this.chkDescending.AutoSize = true;
            this.chkDescending.Location = new System.Drawing.Point(89, 4);
            this.chkDescending.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkDescending.Name = "chkDescending";
            this.chkDescending.Size = new System.Drawing.Size(83, 17);
            this.chkDescending.TabIndex = 12;
            this.chkDescending.Text = "Descending";
            this.chkDescending.UseVisualStyleBackColor = true;
            this.chkDescending.CheckedChanged += new System.EventHandler(this.chkDescending_CheckedChanged);
            // 
            // lblStats
            // 
            this.lblStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStats.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStats.Location = new System.Drawing.Point(9, 479);
            this.lblStats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStats.Name = "lblStats";
            this.lblStats.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblStats.Size = new System.Drawing.Size(582, 33);
            this.lblStats.TabIndex = 13;
            this.lblStats.Text = "Здесь появится статистика...";
            this.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Filters:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Priority";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Category";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Sorting:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Sort By";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbStatusFilter);
            this.panel1.Controls.Add(this.cmbPriorityFilter);
            this.panel1.Controls.Add(this.cmbCategoryFilter);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(9, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 49);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbSortBy);
            this.panel2.Controls.Add(this.chkDescending);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(276, 32);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(172, 49);
            this.panel2.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 81);
            this.panel3.TabIndex = 22;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 526);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.btnInProgress);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.listBoxTasks);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(618, 565);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Manager - OOP Demo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}