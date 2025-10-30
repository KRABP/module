using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleTaskManager
{
    public partial class MainForm : Form
    {
        private DatabaseHelper database;
        private List<Task> tasks;
        private Task selectedTask;

        public MainForm()
        {
            InitializeComponent();
            database = new DatabaseHelper();
            LoadTasks();
            UpdateStatistics();
        }

        private void LoadTasks()
        {
            tasks = database.GetAllTasks();
            listBoxTasks.Items.Clear();
            foreach (var task in tasks)
            {
                listBoxTasks.Items.Add(task);
            }
        }

        private void UpdateStatistics()
        {
            int total = tasks.Count;
            int completed = tasks.FindAll(t => t.IsCompleted).Count;
            int pending = total - completed;

            lblStats.Text = $"Всего: {total} | Выполнено: {completed} | Ожидает: {pending}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Введите название задачи!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var task = new Task
            {
                Title = title,
                Description = txtDescription.Text.Trim(),
                DueDate = dtpDueDate.Value,
                Priority = cmbPriority.Text
            };

            if (database.AddTask(task))
            {
                LoadTasks();
                UpdateStatistics();
                ClearInputs();
                MessageBox.Show("Задача добавлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении задачи!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTask == null)
            {
                MessageBox.Show("Выберите задачу для редактирования!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedTask.Title = txtTitle.Text.Trim();
            selectedTask.Description = txtDescription.Text.Trim();
            selectedTask.DueDate = dtpDueDate.Value;
            selectedTask.Priority = cmbPriority.Text;

            if (database.UpdateTask(selectedTask))
            {
                LoadTasks();
                UpdateStatistics();
                ClearSelection();
                MessageBox.Show("Задача обновлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении задачи!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTask == null)
            {
                MessageBox.Show("Выберите задачу для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Удалить задачу '{selectedTask.Title}'?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (database.DeleteTask(selectedTask.Id))
                {
                    LoadTasks();
                    UpdateStatistics();
                    ClearSelection();
                    MessageBox.Show("Задача удалена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении задачи!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnToggleComplete_Click(object sender, EventArgs e)
        {
            if (selectedTask == null)
            {
                MessageBox.Show("Выберите задачу!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedTask.IsCompleted = !selectedTask.IsCompleted;

            if (database.UpdateTask(selectedTask))
            {
                LoadTasks();
                UpdateStatistics();
                ShowTaskDetails(selectedTask);
            }
        }

        private void listBoxTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedIndex >= 0)
            {
                selectedTask = tasks[listBoxTasks.SelectedIndex];
                ShowTaskDetails(selectedTask);
            }
            else
            {
                ClearSelection();
            }
        }

        private void ShowTaskDetails(Task task)
        {
            txtTitle.Text = task.Title;
            txtDescription.Text = task.Description;
            dtpDueDate.Value = task.DueDate;
            cmbPriority.Text = task.Priority;

            lblDetails.Text = $"Создана: {task.CreatedAt:dd.MM.yyyy HH:mm} | " +
                            $"Статус: {(task.IsCompleted ? "Выполнена" : "В работе")}";

            btnToggleComplete.Text = task.IsCompleted ? "Отменить выполнение" : "Отметить выполненной";
        }

        private void ClearSelection()
        {
            selectedTask = null;
            ClearInputs();
            lblDetails.Text = "Выберите задачу для просмотра деталей";
            btnToggleComplete.Text = "Отметить выполненной";
        }

        private void ClearInputs()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            dtpDueDate.Value = DateTime.Now.AddDays(1);
            cmbPriority.SelectedIndex = 1; // Medium
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSelection();
        }
    }
}