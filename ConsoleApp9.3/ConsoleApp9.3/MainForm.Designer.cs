namespace ConsoleApp9._3
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tasksListBox = new System.Windows.Forms.ListBox();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.dueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.dueDateCheckBox = new System.Windows.Forms.CheckBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.priorityComboBox = new System.Windows.Forms.ComboBox();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.highPriorityLabel = new System.Windows.Forms.Label();
            this.inProgressTasksLabel = new System.Windows.Forms.Label();
            this.pendingTasksLabel = new System.Windows.Forms.Label();
            this.completedTasksLabel = new System.Windows.Forms.Label();
            this.totalTasksLabel = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components); 
            this.mainPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.inputPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.statsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tasksListBox);
            this.mainPanel.Controls.Add(this.controlPanel);
            this.mainPanel.Controls.Add(this.inputPanel);
            this.mainPanel.Controls.Add(this.filterPanel);
            this.mainPanel.Controls.Add(this.statsPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(884, 561);
            this.mainPanel.TabIndex = 0;
            // 
            // tasksListBox
            // 
            this.tasksListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tasksListBox.FormattingEnabled = true;
            this.tasksListBox.ItemHeight = 16;
            this.tasksListBox.Location = new System.Drawing.Point(12, 41);
            this.tasksListBox.Name = "tasksListBox";
            this.tasksListBox.Size = new System.Drawing.Size(860, 212);
            this.tasksListBox.TabIndex = 4;
            this.tasksListBox.SelectedIndexChanged += new System.EventHandler(this.tasksListBox_SelectedIndexChanged);
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.Controls.Add(this.clearButton);
            this.controlPanel.Controls.Add(this.deleteButton);
            this.controlPanel.Controls.Add(this.editButton);
            this.controlPanel.Controls.Add(this.addButton);
            this.controlPanel.Location = new System.Drawing.Point(12, 486);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(860, 63);
            this.controlPanel.TabIndex = 3;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(678, 19);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(110, 30);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.deleteButton.BackColor = System.Drawing.Color.LightCoral;
            this.deleteButton.Location = new System.Drawing.Point(375, 19);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(110, 30);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.editButton.BackColor = System.Drawing.Color.Khaki;
            this.editButton.Location = new System.Drawing.Point(259, 19);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(110, 30);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Редактировать";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addButton.BackColor = System.Drawing.Color.LightGreen;
            this.addButton.Location = new System.Drawing.Point(143, 19);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(110, 30);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // inputPanel
            // 
            this.inputPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputPanel.Controls.Add(this.dueDatePicker);
            this.inputPanel.Controls.Add(this.dueDateCheckBox);
            this.inputPanel.Controls.Add(this.statusComboBox);
            this.inputPanel.Controls.Add(this.statusLabel);
            this.inputPanel.Controls.Add(this.priorityComboBox);
            this.inputPanel.Controls.Add(this.priorityLabel);
            this.inputPanel.Controls.Add(this.descriptionTextBox);
            this.inputPanel.Controls.Add(this.descriptionLabel);
            this.inputPanel.Controls.Add(this.titleTextBox);
            this.inputPanel.Controls.Add(this.titleLabel);
            this.inputPanel.Location = new System.Drawing.Point(12, 259);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(860, 161);
            this.inputPanel.TabIndex = 2;
            // 
            // dueDatePicker
            // 
            this.dueDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dueDatePicker.Enabled = false;
            this.dueDatePicker.Location = new System.Drawing.Point(628, 108);
            this.dueDatePicker.Name = "dueDatePicker";
            this.dueDatePicker.Size = new System.Drawing.Size(200, 22);
            this.dueDatePicker.TabIndex = 9;
            // 
            // dueDateCheckBox
            // 
            this.dueDateCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dueDateCheckBox.AutoSize = true;
            this.dueDateCheckBox.Location = new System.Drawing.Point(528, 110);
            this.dueDateCheckBox.Name = "dueDateCheckBox";
            this.dueDateCheckBox.Size = new System.Drawing.Size(94, 21);
            this.dueDateCheckBox.TabIndex = 8;
            this.dueDateCheckBox.Text = "Дата срока";
            this.dueDateCheckBox.UseVisualStyleBackColor = true;
            this.dueDateCheckBox.CheckedChanged += new System.EventHandler(this.dueDateCheckBox_CheckedChanged);
            // 
            // statusComboBox
            // 
            this.statusComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(628, 65);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(200, 24);
            this.statusComboBox.TabIndex = 7;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(525, 68);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(53, 17);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Статус:";
            // 
            // priorityComboBox
            // 
            this.priorityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityComboBox.FormattingEnabled = true;
            this.priorityComboBox.Location = new System.Drawing.Point(628, 22);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new System.Drawing.Size(200, 24);
            this.priorityComboBox.TabIndex = 5;
            // 
            // priorityLabel
            // 
            this.priorityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new System.Drawing.Point(525, 25);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(75, 17);
            this.priorityLabel.TabIndex = 4;
            this.priorityLabel.Text = "Приоритет:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Location = new System.Drawing.Point(143, 65);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(350, 80);
            this.descriptionTextBox.TabIndex = 3;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(20, 68);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(78, 17);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "Описание:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(143, 22);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(350, 22);
            this.titleTextBox.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(20, 25);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(117, 17);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Название задачи:";
            // 
            // filterPanel
            // 
            this.filterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterPanel.Controls.Add(this.searchTextBox);
            this.filterPanel.Controls.Add(this.searchLabel);
            this.filterPanel.Controls.Add(this.filterComboBox);
            this.filterPanel.Controls.Add(this.filterLabel);
            this.filterPanel.Location = new System.Drawing.Point(12, 12);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(860, 32);
            this.filterPanel.TabIndex = 1;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(628, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 22);
            this.searchTextBox.TabIndex = 3;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // searchLabel
            // 
            this.searchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(565, 6);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(52, 17);
            this.searchLabel.TabIndex = 2;
            this.searchLabel.Text = "Поиск:";
            // 
            // filterComboBox
            // 
            // filterComboBox
            this.filterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Items.AddRange(new object[] {
    "Все задачи",
    "В ожидании",
    "В процессе",
    "Выполнено"});
            this.filterComboBox.Location = new System.Drawing.Point(143, 3);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(200, 24);
            this.filterComboBox.TabIndex = 1;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);            // 
                                                                                                                                      // filterLabel
                                                                                                                                      // 
                                                                                                                                      // filterLabel
                                                                                                                                      // 
            this.filterLabel = new System.Windows.Forms.Label();
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(20, 6);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(62, 17);
            this.filterLabel.TabIndex = 0;
            this.filterLabel.Text = "Фильтр:";
            // 
            // statsPanel
            // 
            this.statsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statsPanel.Controls.Add(this.highPriorityLabel);
            this.statsPanel.Controls.Add(this.inProgressTasksLabel);
            this.statsPanel.Controls.Add(this.pendingTasksLabel);
            this.statsPanel.Controls.Add(this.completedTasksLabel);
            this.statsPanel.Controls.Add(this.totalTasksLabel);
            this.statsPanel.Location = new System.Drawing.Point(12, 426);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(860, 54);
            this.statsPanel.TabIndex = 0;
            // 
            // highPriorityLabel
            // 
            this.highPriorityLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.highPriorityLabel.AutoSize = true;
            this.highPriorityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.highPriorityLabel.Location = new System.Drawing.Point(678, 18);
            this.highPriorityLabel.Name = "highPriorityLabel";
            this.highPriorityLabel.Size = new System.Drawing.Size(138, 17);
            this.highPriorityLabel.TabIndex = 4;
            this.highPriorityLabel.Text = "Высокий приоритет: 0";
            // 
            // inProgressTasksLabel
            // 
            this.inProgressTasksLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inProgressTasksLabel.AutoSize = true;
            this.inProgressTasksLabel.Location = new System.Drawing.Point(525, 18);
            this.inProgressTasksLabel.Name = "inProgressTasksLabel";
            this.inProgressTasksLabel.Size = new System.Drawing.Size(97, 17);
            this.inProgressTasksLabel.TabIndex = 3;
            this.inProgressTasksLabel.Text = "В процессе: 0";
            // 
            // pendingTasksLabel
            // 
            this.pendingTasksLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pendingTasksLabel.AutoSize = true;
            this.pendingTasksLabel.Location = new System.Drawing.Point(375, 18);
            this.pendingTasksLabel.Name = "pendingTasksLabel";
            this.pendingTasksLabel.Size = new System.Drawing.Size(89, 17);
            this.pendingTasksLabel.TabIndex = 2;
            this.pendingTasksLabel.Text = "В ожидании: 0";
            // 
            // completedTasksLabel
            // 
            this.completedTasksLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.completedTasksLabel.AutoSize = true;
            this.completedTasksLabel.Location = new System.Drawing.Point(259, 18);
            this.completedTasksLabel.Name = "completedTasksLabel";
            this.completedTasksLabel.Size = new System.Drawing.Size(80, 17);
            this.completedTasksLabel.TabIndex = 1;
            this.completedTasksLabel.Text = "Выполнено: 0";
            // 
            // totalTasksLabel
            // 
            this.totalTasksLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.totalTasksLabel.AutoSize = true;
            this.totalTasksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalTasksLabel.Location = new System.Drawing.Point(143, 18);
            this.totalTasksLabel.Name = "totalTasksLabel";
            this.totalTasksLabel.Size = new System.Drawing.Size(97, 17);
            this.totalTasksLabel.TabIndex = 0;
            this.totalTasksLabel.Text = "Всего задач: 0";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Менеджер задач";
            this.notifyIcon1.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.Text = "ConsoleApp9._3 - Менеджер задач";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mainPanel.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            this.statsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.ListBox tasksListBox;
        private System.Windows.Forms.Label totalTasksLabel;
        private System.Windows.Forms.Label completedTasksLabel;
        private System.Windows.Forms.Label pendingTasksLabel;
        private System.Windows.Forms.Label inProgressTasksLabel;
        private System.Windows.Forms.Label highPriorityLabel;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ComboBox priorityComboBox;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DateTimePicker dueDatePicker;
        private System.Windows.Forms.CheckBox dueDateCheckBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}