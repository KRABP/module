using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TaskManagerOOP
{
    public partial class MainForm : Form
    {
        private TaskService taskService;
        private List<Task> currentTasks;
        private Task selectedTask;

        public MainForm()
        {
            try
            {
                InitializeComponent();

                // Инициализация зависимостей
                var repository = new TaskRepository();
                taskService = new TaskService(repository);

                currentTasks = new List<Task>();

                // Инициализируем фильтры БЕЗ вызова ApplyFilters
                SafeInitializeFilters();

                LoadTasks();
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in MainForm constructor: {ex.Message}", "Error");
                throw;
            }
        }

        private void SafeInitializeFilters()
        {
            try
            {
                // Временно отключаем обработчики событий
                cmbStatusFilter.SelectedIndexChanged -= cmbStatusFilter_SelectedIndexChanged;
                cmbPriorityFilter.SelectedIndexChanged -= cmbPriorityFilter_SelectedIndexChanged;
                cmbCategoryFilter.SelectedIndexChanged -= cmbCategoryFilter_SelectedIndexChanged;
                cmbSortBy.SelectedIndexChanged -= cmbSortBy_SelectedIndexChanged;
                chkDescending.CheckedChanged -= chkDescending_CheckedChanged;

                // Заполняем комбобоксы
                cmbStatusFilter.Items.Clear();
                cmbStatusFilter.Items.AddRange(new object[] { "All", "Pending", "In Progress", "Completed" });

                cmbPriorityFilter.Items.Clear();
                cmbPriorityFilter.Items.AddRange(new object[] { "All", "Low", "Medium", "High" });

                cmbCategoryFilter.Items.Clear();
                cmbCategoryFilter.Items.Add("All");

                // Заполняем категории
                var categories = taskService.GetAllCategories();
                foreach (var category in categories)
                {
                    cmbCategoryFilter.Items.Add(category);
                }

                cmbSortBy.Items.Clear();
                cmbSortBy.Items.AddRange(new object[] { "Title", "Priority", "Due Date", "Status", "Category" });

                // Устанавливаем значения по умолчанию
                cmbStatusFilter.SelectedIndex = 0;
                cmbPriorityFilter.SelectedIndex = 0;
                cmbCategoryFilter.SelectedIndex = 0;
                cmbSortBy.SelectedIndex = 0;
                chkDescending.Checked = false;

                // Включаем обработчики событий обратно
                cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
                cmbPriorityFilter.SelectedIndexChanged += cmbPriorityFilter_SelectedIndexChanged;
                cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
                cmbSortBy.SelectedIndexChanged += cmbSortBy_SelectedIndexChanged;
                chkDescending.CheckedChanged += chkDescending_CheckedChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in SafeInitializeFilters: {ex.Message}", "Error");
            }
        }

        private void LoadTasks()
        {
            try
            {
                currentTasks = taskService.GetAllTasks();
                ApplySorting();
                RefreshTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tasks: {ex.Message}", "Error");
                currentTasks = new List<Task>();
            }
        }

        private void ApplySorting()
        {
            try
            {
                if (cmbSortBy.SelectedItem != null && currentTasks != null)
                {
                    string sortBy = cmbSortBy.SelectedItem.ToString();
                    bool ascending = !chkDescending.Checked;
                    currentTasks = taskService.SortTasks(currentTasks, sortBy, ascending);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying sorting: {ex.Message}", "Error");
            }
        }

        private void RefreshTaskList()
        {
            try
            {
                listBoxTasks.Items.Clear();
                if (currentTasks != null)
                {
                    foreach (var task in currentTasks)
                    {
                        listBoxTasks.Items.Add(task);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing task list: {ex.Message}", "Error");
            }
        }

        private void UpdateStatistics()
        {
            try
            {
                if (currentTasks == null) return;

                var statusStats = taskService.GetStatusStatistics();
                var priorityStats = taskService.GetPriorityStatistics();
                var overdueTasks = taskService.GetOverdueTasks();
                var dueToday = taskService.GetTasksDueToday();

                int pendingCount = statusStats.ContainsKey(Status.Pending) ? statusStats[Status.Pending] : 0;
                int inProgressCount = statusStats.ContainsKey(Status.InProgress) ? statusStats[Status.InProgress] : 0;
                int completedCount = statusStats.ContainsKey(Status.Completed) ? statusStats[Status.Completed] : 0;

                lblStats.Text = $"Total: {currentTasks.Count} | " +
                              $"Pending: {pendingCount} | " +
                              $"In Progress: {inProgressCount} | " +
                              $"Completed: {completedCount} | " +
                              $"Overdue: {overdueTasks.Count} | " +
                              $"Due Today: {dueToday.Count}";
            }
            catch (Exception ex)
            {
                lblStats.Text = "Error loading statistics";
            }
        }

        // ОБРАБОТЧИКИ СОБЫТИЙ
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new TaskForm())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        taskService.CreateTask(
                            form.TaskTitle,
                            form.TaskDescription,
                            form.TaskPriority,
                            form.TaskCategory,
                            form.TaskDueDate
                        );
                        LoadTasks();
                        UpdateStatistics();
                        SafeInitializeFilters();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding task: {ex.Message}", "Error");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTask == null)
                {
                    MessageBox.Show("Please select a task to edit.");
                    return;
                }

                using (var form = new TaskForm(selectedTask))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        selectedTask.Title = form.TaskTitle;
                        selectedTask.Description = form.TaskDescription;
                        selectedTask.Priority = form.TaskPriority;
                        selectedTask.Category = form.TaskCategory;
                        selectedTask.DueDate = form.TaskDueDate;

                        var repository = new TaskRepository();
                        repository.UpdateTask(selectedTask);

                        LoadTasks();
                        UpdateStatistics();
                        SafeInitializeFilters();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing task: {ex.Message}", "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTask == null)
                {
                    MessageBox.Show("Please select a task to delete.");
                    return;
                }

                var result = MessageBox.Show($"Delete task '{selectedTask.Title}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var repository = new TaskRepository();
                    repository.DeleteTask(selectedTask.Id);
                    LoadTasks();
                    UpdateStatistics();
                    SafeInitializeFilters();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting task: {ex.Message}", "Error");
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTask == null)
                {
                    MessageBox.Show("Please select a task to complete.");
                    return;
                }

                taskService.CompleteTask(selectedTask.Id);
                LoadTasks();
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing task: {ex.Message}", "Error");
            }
        }

        private void btnInProgress_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTask == null)
                {
                    MessageBox.Show("Please select a task to mark as in progress.");
                    return;
                }

                selectedTask.MarkInProgress();
                var repository = new TaskRepository();
                repository.UpdateTask(selectedTask);
                LoadTasks();
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating task status: {ex.Message}", "Error");
            }
        }

        private void listBoxTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxTasks.SelectedIndex >= 0 && listBoxTasks.SelectedIndex < currentTasks.Count)
                {
                    selectedTask = currentTasks[listBoxTasks.SelectedIndex];
                    ShowTaskDetails(selectedTask);
                }
                else
                {
                    ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting task: {ex.Message}", "Error");
            }
        }

        private void ShowTaskDetails(Task task)
        {
            try
            {
                txtDetails.Text = $"Title: {task.Title}\r\n" +
                                $"Description: {task.Description}\r\n" +
                                $"Category: {task.Category}\r\n" +
                                $"Priority: {task.Priority}\r\n" +
                                $"Status: {task.Status}\r\n" +
                                $"Due Date: {task.DueDate:dd.MM.yyyy}\r\n" +
                                $"Created: {task.CreatedDate:dd.MM.yyyy HH:mm}\r\n" +
                                $"{(task.IsOverdue() ? " OVERDUE" : "")}";
            }
            catch (Exception ex)
            {
                txtDetails.Text = "Error loading task details";
            }
        }

        private void ClearSelection()
        {
            selectedTask = null;
            txtDetails.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            try
            {
                if (taskService == null || currentTasks == null) return;

                Status? statusFilter = GetStatusFilter();
                Priority? priorityFilter = GetPriorityFilter();
                string categoryFilter = GetCategoryFilter();

                currentTasks = taskService.FilterTasks(statusFilter, priorityFilter, categoryFilter);

                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    var repository = new TaskRepository();
                    var searchResults = repository.SearchTasks(txtSearch.Text);
                    currentTasks = currentTasks
                        .Where(t => searchResults.Any(sr => sr.Id == t.Id))
                        .ToList();
                }

                ApplySorting();
                RefreshTaskList();
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying filters: {ex.Message}", "Error");
            }
        }

        private Status? GetStatusFilter()
        {
            try
            {
                if (cmbStatusFilter.SelectedItem == null) return null;

                switch (cmbStatusFilter.SelectedIndex)
                {
                    case 1: return Status.Pending;
                    case 2: return Status.InProgress;
                    case 3: return Status.Completed;
                    default: return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private Priority? GetPriorityFilter()
        {
            try
            {
                if (cmbPriorityFilter.SelectedItem == null) return null;

                switch (cmbPriorityFilter.SelectedIndex)
                {
                    case 1: return Priority.Low;
                    case 2: return Priority.Medium;
                    case 3: return Priority.High;
                    default: return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private string GetCategoryFilter()
        {
            try
            {
                if (cmbCategoryFilter.SelectedItem == null || cmbCategoryFilter.SelectedIndex == 0)
                    return null;

                return cmbCategoryFilter.SelectedItem.ToString();
            }
            catch
            {
                return null;
            }
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbPriorityFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void chkDescending_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void listBoxTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if (e.Index < 0) return;

                e.DrawBackground();

                if (listBoxTasks.Items[e.Index] is Task task)
                {
                    Color textColor = e.ForeColor;

                    if (task.IsOverdue() && task.Status != Status.Completed)
                    {
                        textColor = Color.Red;
                    }
                    else if (task.Status == Status.Completed)
                    {
                        textColor = Color.Gray;
                    }
                    else
                    {
                        switch (task.Priority)
                        {
                            case Priority.High:
                                textColor = Color.DarkRed;
                                break;
                            case Priority.Medium:
                                textColor = Color.DarkBlue;
                                break;
                            case Priority.Low:
                                textColor = Color.DarkGreen;
                                break;
                            default:
                                textColor = e.ForeColor;
                                break;
                        }
                    }

                    using (Brush brush = new SolidBrush(textColor))
                    {
                        e.Graphics.DrawString(listBoxTasks.Items[e.Index].ToString(),
                                             e.Font, brush, e.Bounds);
                    }
                }

                e.DrawFocusRectangle();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}