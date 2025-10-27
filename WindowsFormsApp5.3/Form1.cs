using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TaskManagerApp
{
    public partial class Form1 : Form
    {
        private List<TaskItem> tasks;
        private int nextId = 1;

        public Form1()
        {
            InitializeComponent();
            InitializeTasks();
            RefreshTaskList();
            UpdateStatistics();
        }

        private void InitializeTasks()
        {
            tasks = new List<TaskItem>();

            // Добавляем несколько примеров задач
            AddTask("Изучить C#", "Освоить Windows Forms программирование", DateTime.Now.AddDays(7), Priority.High);
            AddTask("Купить продукты", "Молоко, хлеб, яйца", DateTime.Now.AddDays(1), Priority.Medium);
            AddTask("Сделать зарядку", "Утренняя гимнастика", DateTime.Now, Priority.Low);
        }

        private void AddTask(string title, string description, DateTime dueDate, Priority priority)
        {
            var task = new TaskItem
            {
                Id = nextId++,
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = priority
            };
            tasks.Add(task);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название задачи!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var task = new TaskItem
            {
                Id = nextId++,
                Title = txtTitle.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                DueDate = dtpDueDate.Value,
                Priority = (Priority)cmbPriority.SelectedIndex
            };

            tasks.Add(task);
            ClearInputs();
            RefreshTaskList();
            UpdateStatistics();

            txtTitle.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null && lstTasks.SelectedItem is TaskItem selectedTask)
            {
                var result = MessageBox.Show(
                    $"Удалить задачу \"{selectedTask.Title}\"?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    tasks.Remove(selectedTask);
                    RefreshTaskList();
                    UpdateStatistics();
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null && lstTasks.SelectedItem is TaskItem selectedTask)
            {
                selectedTask.IsCompleted = !selectedTask.IsCompleted;
                selectedTask.CompletedAt = selectedTask.IsCompleted ? DateTime.Now : (DateTime?)null;

                RefreshTaskList();
                UpdateStatistics();
            }
            else
            {
                MessageBox.Show("Выберите задачу!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearCompleted_Click(object sender, EventArgs e)
        {
            var completedTasks = tasks.Where(t => t.IsCompleted).ToList();

            if (completedTasks.Count == 0)
            {
                MessageBox.Show("Нет выполненных задач для удаления!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Удалить все выполненные задачи ({completedTasks.Count})?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                tasks.RemoveAll(t => t.IsCompleted);
                RefreshTaskList();
                UpdateStatistics();
            }
        }

        private void RefreshTaskList()
        {
            lstTasks.Items.Clear();

            // Сортируем задачи: сначала невыполненные, затем выполненные
            var sortedTasks = tasks.OrderBy(t => t.IsCompleted)
                                  .ThenByDescending(t => t.Priority)
                                  .ThenBy(t => t.DueDate);

            foreach (var task in sortedTasks)
            {
                lstTasks.Items.Add(task);
            }

            // Обновляем цвета элементов
            UpdateListColors();
        }

        private void UpdateListColors()
        {
            for (int i = 0; i < lstTasks.Items.Count; i++)
            {
                if (lstTasks.Items[i] is TaskItem task)
                {
                    if (task.IsCompleted)
                    {
                        // Для выполненных задач - серый текст
                        lstTasks.SetItemColor(i, Color.Gray, SystemColors.Window);
                    }
                    else
                    {
                        Color foreColor = GetPriorityColor(task.Priority);
                        Color backColor = IsOverdue(task) ? Color.LightPink : SystemColors.Window;

                        lstTasks.SetItemColor(i, foreColor, backColor);
                    }
                }
            }
        }

        private bool IsOverdue(TaskItem task)
        {
            return !task.IsCompleted && task.DueDate.Date < DateTime.Today;
        }

        private Color GetPriorityColor(Priority priority)
        {
            switch (priority)
            {
                case Priority.Low:
                    return Color.Green;
                case Priority.Medium:
                    return Color.Blue;
                case Priority.High:
                    return Color.Red;
                default:
                    return Color.Black;
            }
        }

        private void UpdateStatistics()
        {
            int total = tasks.Count;
            int completed = tasks.Count(t => t.IsCompleted);
            int pending = total - completed;
            int overdue = tasks.Count(t => IsOverdue(t));

            lblStatistics.Text = $"Всего: {total} | Выполнено: {completed} | Ожидает: {pending} | Просрочено: {overdue}";
        }

        private void ClearInputs()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            dtpDueDate.Value = DateTime.Now.AddDays(1);
            cmbPriority.SelectedIndex = 1; // Medium
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null && lstTasks.SelectedItem is TaskItem selectedTask)
            {
                ShowTaskDetails(selectedTask);
            }
            else
            {
                ClearDetails();
            }
        }

        private void ShowTaskDetails(TaskItem task)
        {
            lblDetailTitle.Text = task.Title;
            lblDetailDescription.Text = string.IsNullOrEmpty(task.Description) ?
                "(без описания)" : task.Description;
            lblDetailDueDate.Text = task.DueDate.ToString("dd.MM.yyyy HH:mm");

            if (task.IsCompleted && task.CompletedAt.HasValue)
            {
                lblDetailStatus.Text = $"Выполнено: {task.CompletedAt.Value:dd.MM.yyyy HH:mm}";
            }
            else
            {
                lblDetailStatus.Text = "В процессе";
            }

            lblDetailPriority.Text = GetPriorityText(task.Priority);
            lblDetailCreated.Text = task.CreatedAt.ToString("dd.MM.yyyy HH:mm");

            // Устанавливаем цвет статуса
            lblDetailStatus.ForeColor = task.IsCompleted ? Color.Green : Color.Blue;
            lblDetailPriority.ForeColor = GetPriorityColor(task.Priority);
        }

        private string GetPriorityText(Priority priority)
        {
            switch (priority)
            {
                case Priority.Low:
                    return "Низкий";
                case Priority.Medium:
                    return "Средний";
                case Priority.High:
                    return "Высокий";
                default:
                    return "Средний";
            }
        }

        private void ClearDetails()
        {
            lblDetailTitle.Text = "Выберите задачу";
            lblDetailDescription.Text = "";
            lblDetailDueDate.Text = "";
            lblDetailStatus.Text = "";
            lblDetailPriority.Text = "";
            lblDetailCreated.Text = "";
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAdd_Click(sender, e);
                e.Handled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cmbPriority.SelectedIndex = 1; // Medium по умолчанию
        }

        private void lstTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            if (lstTasks.Items[e.Index] is TaskItem task)
            {
                Color foreColor = e.ForeColor;
                Color backColor = e.BackColor;

                if (task.IsCompleted)
                {
                    foreColor = Color.Gray;
                }
                else
                {
                    foreColor = GetPriorityColor(task.Priority);
                    if (IsOverdue(task))
                    {
                        backColor = Color.LightPink;
                    }
                }

                using (Brush brush = new SolidBrush(foreColor))
                using (Brush backBrush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(backBrush, e.Bounds);
                    e.Graphics.DrawString(lstTasks.Items[e.Index].ToString(),
                                         e.Font, brush, e.Bounds);
                }
            }
            else
            {
                using (Brush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(lstTasks.Items[e.Index].ToString(),
                                         e.Font, brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }
    }

    // Класс задачи (внутри того же файла)
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public Priority Priority { get; set; }

        public TaskItem()
        {
            CreatedAt = DateTime.Now;
            DueDate = DateTime.Now.AddDays(1);
            Priority = Priority.Medium;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "✓" : "○";
            string priority = GetPrioritySymbol();
            return $"{status} {priority} {Title} (до {DueDate:dd.MM.yyyy})";
        }

        private string GetPrioritySymbol()
        {
            switch (Priority)
            {
                case Priority.Low:
                    return "↓";
                case Priority.Medium:
                    return "→";
                case Priority.High:
                    return "↑";
                default:
                    return "→";
            }
        }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }

    // Расширение для ListBox для установки цвета элементов
    public static class ListBoxExtensions
    {
        public static void SetItemColor(this ListBox listBox, int index, Color foreColor, Color backColor)
        {
            // В C# 7.3 используем стандартный подход с событием DrawItem
            // Цвет устанавливается в обработчике события DrawItem
        }
    }
}