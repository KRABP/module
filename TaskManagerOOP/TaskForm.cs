using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManagerOOP
{
    public partial class TaskForm : Form
    {
        public string TaskTitle { get; private set; }
        public string TaskDescription { get; private set; }
        public Priority TaskPriority { get; private set; }
        public string TaskCategory { get; private set; }
        public DateTime TaskDueDate { get; private set; }

        public TaskForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        public TaskForm(Task task) : this()
        {
            txtTitle.Text = task.Title;
            txtDescription.Text = task.Description;
            cmbPriority.SelectedIndex = (int)task.Priority;
            txtCategory.Text = task.Category;
            dtpDueDate.Value = task.DueDate;
        }

        private void InitializeForm()
        {
            cmbPriority.Items.AddRange(new object[] { "Low", "Medium", "High" });
            cmbPriority.SelectedIndex = 1; // Medium
            dtpDueDate.Value = DateTime.Now.AddDays(7);

            // Добавляем обработчики для Placeholder эффекта
            txtTitle.Enter += RemovePlaceholderText;
            txtTitle.Leave += AddPlaceholderText;
            txtDescription.Enter += RemovePlaceholderText;
            txtDescription.Leave += AddPlaceholderText;
            txtCategory.Enter += RemovePlaceholderText;
            txtCategory.Leave += AddPlaceholderText;

            AddPlaceholderText(null, null);
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox == txtTitle && textBox.Text == "Enter task title...")
                {
                    textBox.Text = "";
                    textBox.ForeColor = SystemColors.WindowText;
                }
                else if (textBox == txtDescription && textBox.Text == "Enter task description (optional)...")
                {
                    textBox.Text = "";
                    textBox.ForeColor = SystemColors.WindowText;
                }
                else if (textBox == txtCategory && textBox.Text == "Enter category...")
                {
                    textBox.Text = "";
                    textBox.ForeColor = SystemColors.WindowText;
                }
            }
        }

        private void AddPlaceholderText(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                txtTitle.Text = "Enter task title...";
                txtTitle.ForeColor = SystemColors.GrayText;
            }

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                txtDescription.Text = "Enter task description (optional)...";
                txtDescription.ForeColor = SystemColors.GrayText;
            }

            if (string.IsNullOrEmpty(txtCategory.Text))
            {
                txtCategory.Text = "Enter category...";
                txtCategory.ForeColor = SystemColors.GrayText;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                TaskTitle = txtTitle.Text.Trim();
                TaskDescription = (txtDescription.Text == "Enter task description (optional)...") ? "" : txtDescription.Text.Trim();
                TaskPriority = (Priority)cmbPriority.SelectedIndex;
                TaskCategory = txtCategory.Text.Trim();
                TaskDueDate = dtpDueDate.Value;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool ValidateForm()
        {
            string title = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(title) || title == "Enter task title...")
            {
                MessageBox.Show("Please enter a task title.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            string category = txtCategory.Text.Trim();
            if (string.IsNullOrEmpty(category) || category == "Enter category...")
            {
                MessageBox.Show("Please enter a category.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategory.Focus();
                return false;
            }

            return true;
        }
    }
}