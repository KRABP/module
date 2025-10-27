namespace TaskManagerApp
{
    partial class Form1
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
            this.panelInput = new System.Windows.Forms.Panel();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.panelTasks = new System.Windows.Forms.Panel();
            this.lblStatistics = new System.Windows.Forms.Label();
            this.btnClearCompleted = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.lblDetailCreated = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDetailPriority = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDetailStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDetailDueDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDetailDescription = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();

            this.panelInput.SuspendLayout();
            this.panelTasks.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.SuspendLayout();

            // panelInput
            this.panelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInput.Controls.Add(this.lblPriority);
            this.panelInput.Controls.Add(this.cmbPriority);
            this.panelInput.Controls.Add(this.lblDueDate);
            this.panelInput.Controls.Add(this.dtpDueDate);
            this.panelInput.Controls.Add(this.lblDescription);
            this.panelInput.Controls.Add(this.txtDescription);
            this.panelInput.Controls.Add(this.btnAdd);
            this.panelInput.Controls.Add(this.lblTitle);
            this.panelInput.Controls.Add(this.txtTitle);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInput.Location = new System.Drawing.Point(0, 0);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(800, 150);
            this.panelInput.TabIndex = 0;

            // lblPriority
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(400, 80);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(61, 13);
            this.lblPriority.TabIndex = 8;
            this.lblPriority.Text = "Приоритет";

            // cmbPriority
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "Низкий",
            "Средний",
            "Высокий"});
            this.cmbPriority.Location = new System.Drawing.Point(400, 100);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(150, 21);
            this.cmbPriority.TabIndex = 7;

            // lblDueDate
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(400, 35);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(72, 13);
            this.lblDueDate.TabIndex = 6;
            this.lblDueDate.Text = "Срок выполнения";

            // dtpDueDate
            this.dtpDueDate.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(400, 55);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(150, 20);
            this.dtpDueDate.TabIndex = 5;

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 80);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(57, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Описание";

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(15, 100);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(350, 20);
            this.txtDescription.TabIndex = 3;

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(570, 55);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 65);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Добавить задачу";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(61, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Название *";

            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(15, 35);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(350, 20);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTitle_KeyPress);

            // panelTasks
            this.panelTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTasks.Controls.Add(this.lblStatistics);
            this.panelTasks.Controls.Add(this.btnClearCompleted);
            this.panelTasks.Controls.Add(this.btnComplete);
            this.panelTasks.Controls.Add(this.btnDelete);
            this.panelTasks.Controls.Add(this.lstTasks);
            this.panelTasks.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTasks.Location = new System.Drawing.Point(0, 150);
            this.panelTasks.Name = "panelTasks";
            this.panelTasks.Size = new System.Drawing.Size(400, 300);
            this.panelTasks.TabIndex = 1;

            // lblStatistics
            this.lblStatistics.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatistics.Location = new System.Drawing.Point(0, 275);
            this.lblStatistics.Name = "lblStatistics";
            this.lblStatistics.Size = new System.Drawing.Size(398, 23);
            this.lblStatistics.TabIndex = 4;
            this.lblStatistics.Text = "Всего: 0 | Выполнено: 0 | Ожидает: 0 | Просрочено: 0";
            this.lblStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnClearCompleted
            this.btnClearCompleted.Location = new System.Drawing.Point(270, 235);
            this.btnClearCompleted.Name = "btnClearCompleted";
            this.btnClearCompleted.Size = new System.Drawing.Size(120, 30);
            this.btnClearCompleted.TabIndex = 3;
            this.btnClearCompleted.Text = "Очистить выполненные";
            this.btnClearCompleted.UseVisualStyleBackColor = true;
            this.btnClearCompleted.Click += new System.EventHandler(this.btnClearCompleted_Click);

            // btnComplete
            this.btnComplete.Location = new System.Drawing.Point(140, 235);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(120, 30);
            this.btnComplete.TabIndex = 2;
            this.btnComplete.Text = "Выполнить/Отменить";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(10, 235);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 30);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // lstTasks
            this.lstTasks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new System.Drawing.Point(10, 10);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(380, 212);
            this.lstTasks.TabIndex = 0;
            this.lstTasks.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstTasks_DrawItem);
            this.lstTasks.SelectedIndexChanged += new System.EventHandler(this.lstTasks_SelectedIndexChanged);

            // panelDetails
            this.panelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetails.Controls.Add(this.lblDetailCreated);
            this.panelDetails.Controls.Add(this.label7);
            this.panelDetails.Controls.Add(this.lblDetailPriority);
            this.panelDetails.Controls.Add(this.label5);
            this.panelDetails.Controls.Add(this.lblDetailStatus);
            this.panelDetails.Controls.Add(this.label4);
            this.panelDetails.Controls.Add(this.lblDetailDueDate);
            this.panelDetails.Controls.Add(this.label3);
            this.panelDetails.Controls.Add(this.lblDetailDescription);
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.lblDetailTitle);
            this.panelDetails.Controls.Add(this.label1);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(400, 150);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(400, 300);
            this.panelDetails.TabIndex = 2;

            // lblDetailCreated
            this.lblDetailCreated.AutoSize = true;
            this.lblDetailCreated.Location = new System.Drawing.Point(120, 180);
            this.lblDetailCreated.Name = "lblDetailCreated";
            this.lblDetailCreated.Size = new System.Drawing.Size(0, 13);
            this.lblDetailCreated.TabIndex = 11;

            // label7
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(20, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Создана:";

            // lblDetailPriority
            this.lblDetailPriority.AutoSize = true;
            this.lblDetailPriority.Location = new System.Drawing.Point(120, 150);
            this.lblDetailPriority.Name = "lblDetailPriority";
            this.lblDetailPriority.Size = new System.Drawing.Size(0, 13);
            this.lblDetailPriority.TabIndex = 9;

            // label5
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(20, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Приоритет:";

            // lblDetailStatus
            this.lblDetailStatus.AutoSize = true;
            this.lblDetailStatus.Location = new System.Drawing.Point(120, 120);
            this.lblDetailStatus.Name = "lblDetailStatus";
            this.lblDetailStatus.Size = new System.Drawing.Size(0, 13);
            this.lblDetailStatus.TabIndex = 7;

            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(20, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Статус:";

            // lblDetailDueDate
            this.lblDetailDueDate.AutoSize = true;
            this.lblDetailDueDate.Location = new System.Drawing.Point(120, 90);
            this.lblDetailDueDate.Name = "lblDetailDueDate";
            this.lblDetailDueDate.Size = new System.Drawing.Size(0, 13);
            this.lblDetailDueDate.TabIndex = 5;

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(20, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Срок:";

            // lblDetailDescription
            this.lblDetailDescription.AutoSize = true;
            this.lblDetailDescription.Location = new System.Drawing.Point(120, 60);
            this.lblDetailDescription.Name = "lblDetailDescription";
            this.lblDetailDescription.Size = new System.Drawing.Size(0, 13);
            this.lblDetailDescription.TabIndex = 3;

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Описание:";

            // lblDetailTitle
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDetailTitle.Location = new System.Drawing.Point(120, 30);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(112, 15);
            this.lblDetailTitle.TabIndex = 1;
            this.lblDetailTitle.Text = "Выберите задачу";

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelTasks);
            this.Controls.Add(this.panelInput);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер задач";
            this.Load += new System.EventHandler(this.MainForm_Load);

            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelTasks.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Panel panelTasks;
        private System.Windows.Forms.Label lblStatistics;
        private System.Windows.Forms.Button btnClearCompleted;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblDetailCreated;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDetailPriority;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDetailStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDetailDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDetailDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label label1;
    }
}

