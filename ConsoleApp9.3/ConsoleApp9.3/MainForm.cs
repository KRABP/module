using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Timers;

namespace ConsoleApp9._3
{
    public partial class MainForm : Form
    {
        private BindingList<Task> tasks;
        private System.Timers.Timer notificationTimer;

        public MainForm()
        {
            InitializeComponent();
            InitializeData();
            InitializeTimer();
        }

        private void InitializeData()
        {
            tasks = new BindingList<Task>();
            tasksListBox.DataSource = tasks;
            tasksListBox.DisplayMember = "DisplayInfo";

            // Заполняем комбобоксы
            priorityComboBox.DataSource = Enum.GetValues(typeof(Priority));
            statusComboBox.DataSource = Enum.GetValues(typeof(TaskStatus));

            // Устанавливаем начальные значения фильтров
            filterComboBox.SelectedIndex = 0;
        }

        private void InitializeTimer()
        {
            notificationTimer = new System.Timers.Timer(30000); // Проверка каждые 30 секунд
            notificationTimer.Elapsed += CheckDueDates;
            notificationTimer.AutoReset = true;
            notificationTimer.Enabled = true;
        }

        private void CheckDueDates(object sender, ElapsedEventArgs e)
        {
            try
            {
                var upcomingTasks = tasks.Where(t =>
                    t.DueDate.HasValue &&
                    t.DueDate.Value <= DateTime.Now.AddHours(24) &&
                    t.DueDate.Value > DateTime.Now &&
                    t.Status != TaskStatus.Completed).ToList();

                if (upcomingTasks.Any() && this.IsHandleCreated)
                {
                    this.Invoke(new Action(() =>
                    {
                        foreach (var task in upcomingTasks)
                        {
                            ShowNotification($"Скоро истекает срок: {task.Title}",
                                $"Дата выполнения: {task.DueDate:dd.MM.yyyy HH:mm}\n" +
                                $"Приоритет: {task.Priority}");
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                System.Diagnostics.Debug.WriteLine($"Ошибка в таймере: {ex.Message}");
            }
        }

        private void ShowNotification(string title, string message)
        {
            try
            {
                notifyIcon1.BalloonTipTitle = title;
                notifyIcon1.BalloonTipText = message;
                notifyIcon1.ShowBalloonTip(3000);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка уведомления: {ex.Message}");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                MessageBox.Show("Введите название задачи!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                titleTextBox.Focus();
                return;
            }

            try
            {
                var task = new Task
                {
                    Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1,
                    Title = titleTextBox.Text.Trim(),
                    Description = descriptionTextBox.Text.Trim(),
                    Priority = (Priority)priorityComboBox.SelectedItem,
                    DueDate = dueDateCheckBox.Checked ? dueDatePicker.Value : (DateTime?)null,
                    Status = TaskStatus.Pending,
                    CreatedDate = DateTime.Now
                };

                tasks.Add(task);
                ClearInputs();
                UpdateStatistics();
                ApplyFilter(); // Обновляем фильтр после добавления

                MessageBox.Show("Задача успешно добавлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении задачи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (tasksListBox.SelectedItem is Task selectedTask)
            {
                try
                {
                    // Создаем копию для редактирования
                    var editedTask = new Task
                    {
                        Id = selectedTask.Id,
                        Title = titleTextBox.Text.Trim(),
                        Description = descriptionTextBox.Text.Trim(),
                        Priority = (Priority)priorityComboBox.SelectedItem,
                        Status = (TaskStatus)statusComboBox.SelectedItem,
                        DueDate = dueDateCheckBox.Checked ? dueDatePicker.Value : (DateTime?)null,
                        CreatedDate = selectedTask.CreatedDate
                    };

                    // Удаляем старую и добавляем новую
                    tasks.Remove(selectedTask);
                    tasks.Add(editedTask);

                    UpdateStatistics();
                    ApplyFilter();
                    ClearInputs();

                    MessageBox.Show("Задача успешно обновлена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при редактировании задачи: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (tasksListBox.SelectedItem is Task selectedTask)
            {
                var result = MessageBox.Show($"Удалить задачу '{selectedTask.Title}'?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    tasks.Remove(selectedTask);
                    UpdateStatistics();
                    ApplyFilter();
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            titleTextBox.Clear();
            descriptionTextBox.Clear();
            priorityComboBox.SelectedIndex = 0;
            statusComboBox.SelectedIndex = 0;
            dueDateCheckBox.Checked = false;
            dueDatePicker.Value = DateTime.Now;
            dueDatePicker.Enabled = false;

            titleTextBox.Focus();
        }

        private void dueDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dueDatePicker.Enabled = dueDateCheckBox.Checked;
            if (dueDateCheckBox.Checked)
            {
                dueDatePicker.MinDate = DateTime.Now;
            }
        }

        private void tasksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tasksListBox.SelectedItem is Task selectedTask)
            {
                titleTextBox.Text = selectedTask.Title;
                descriptionTextBox.Text = selectedTask.Description;
                priorityComboBox.SelectedItem = selectedTask.Priority;
                statusComboBox.SelectedItem = selectedTask.Status;

                if (selectedTask.DueDate.HasValue)
                {
                    dueDateCheckBox.Checked = true;
                    dueDatePicker.Value = selectedTask.DueDate.Value;
                }
                else
                {
                    dueDateCheckBox.Checked = false;
                }
            }
        }

        private void UpdateStatistics()
        {
            try
            {
                totalTasksLabel.Text = $"Всего задач: {tasks.Count}";
                completedTasksLabel.Text = $"Выполнено: {tasks.Count(t => t.Status == TaskStatus.Completed)}";
                pendingTasksLabel.Text = $"В ожидании: {tasks.Count(t => t.Status == TaskStatus.Pending)}";
                inProgressTasksLabel.Text = $"В процессе: {tasks.Count(t => t.Status == TaskStatus.InProgress)}";

                var highPriorityCount = tasks.Count(t => t.Priority == Priority.High && t.Status != TaskStatus.Completed);
                highPriorityLabel.Text = $"Высокий приоритет: {highPriorityCount}";
                highPriorityLabel.ForeColor = highPriorityCount > 0 ? Color.Red : Color.Black;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка обновления статистики: {ex.Message}");
            }
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            try
            {
                var filteredTasks = tasks.AsEnumerable();

                // Фильтр по статусу
                if (filterComboBox.SelectedIndex > 0)
                {
                    var selectedStatus = (TaskStatus)(filterComboBox.SelectedIndex - 1);
                    filteredTasks = filteredTasks.Where(t => t.Status == selectedStatus);
                }

                // Поиск по названию
                if (!string.IsNullOrWhiteSpace(searchTextBox.Text))
                {
                    filteredTasks = filteredTasks.Where(t =>
                        t.Title.ToLower().Contains(searchTextBox.Text.ToLower()) ||
                        t.Description.ToLower().Contains(searchTextBox.Text.ToLower()));
                }

                var filteredList = new BindingList<Task>(filteredTasks.ToList());
                tasksListBox.DataSource = filteredList;
                tasksListBox.DisplayMember = "DisplayInfo";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка фильтрации: {ex.Message}");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateStatistics();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notificationTimer?.Stop();
            notificationTimer?.Dispose();
        }

        private void titleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                addButton_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}