using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace TaskManagerOOP
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string connectionString;
        private int nextId = 1;
        private List<Task> tasks;

        public TaskRepository(string databaseFile = "tasks.db")
        {
            connectionString = $"Data Source={databaseFile};Version=3;";
            tasks = new List<Task>();
            InitializeDatabase();
            LoadTasksFromDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                if (!File.Exists("tasks.db"))
                {
                    SQLiteConnection.CreateFile("tasks.db");
                }

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Tasks (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Title TEXT NOT NULL,
                            Description TEXT,
                            DueDate TEXT NOT NULL,
                            Priority INTEGER NOT NULL,
                            Status INTEGER NOT NULL,
                            Category TEXT NOT NULL,
                            CreatedDate TEXT NOT NULL
                        )";

                    using (var command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing database: " + ex.Message, ex);
            }
        }

        private void LoadTasksFromDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Tasks ORDER BY Id";
                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var task = new Task(
                                reader.GetString(1),
                                reader.IsDBNull(2) ? "" : reader.GetString(2),
                                (Priority)reader.GetInt32(4),
                                reader.GetString(6),
                                DateTime.Parse(reader.GetString(3))
                            )
                            {
                                Id = reader.GetInt32(0),
                                Status = (Status)reader.GetInt32(5)
                            };

                            // Устанавливаем createdDate из базы данных
                            var createdDateField = typeof(Task).GetField("createdDate",
                                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                            if (createdDateField != null)
                            {
                                var createdDate = DateTime.Parse(reader.GetString(7));
                                createdDateField.SetValue(task, createdDate);
                            }

                            tasks.Add(task);
                            nextId = Math.Max(nextId, task.Id + 1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading tasks from database: " + ex.Message, ex);
            }
        }

        public void AddTask(Task task)
        {
            try
            {
                task.Id = nextId++;
                tasks.Add(task);

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO Tasks (Id, Title, Description, DueDate, Priority, Status, Category, CreatedDate)
                        VALUES (@Id, @Title, @Description, @DueDate, @Priority, @Status, @Category, @CreatedDate)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", task.Id);
                        command.Parameters.AddWithValue("@Title", task.Title);
                        command.Parameters.AddWithValue("@Description", task.Description);
                        command.Parameters.AddWithValue("@DueDate", task.DueDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Priority", (int)task.Priority);
                        command.Parameters.AddWithValue("@Status", (int)task.Status);
                        command.Parameters.AddWithValue("@Category", task.Category);
                        command.Parameters.AddWithValue("@CreatedDate", task.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"));

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding task: " + ex.Message, ex);
            }
        }

        public void UpdateTask(Task task)
        {
            try
            {
                var existingTask = tasks.FirstOrDefault(t => t.Id == task.Id);
                if (existingTask != null)
                {
                    existingTask.Title = task.Title;
                    existingTask.Description = task.Description;
                    existingTask.DueDate = task.DueDate;
                    existingTask.Priority = task.Priority;
                    existingTask.Status = task.Status;
                    existingTask.Category = task.Category;

                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                            UPDATE Tasks 
                            SET Title = @Title, Description = @Description, DueDate = @DueDate,
                                Priority = @Priority, Status = @Status, Category = @Category
                            WHERE Id = @Id";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", task.Id);
                            command.Parameters.AddWithValue("@Title", task.Title);
                            command.Parameters.AddWithValue("@Description", task.Description);
                            command.Parameters.AddWithValue("@DueDate", task.DueDate.ToString("yyyy-MM-dd"));
                            command.Parameters.AddWithValue("@Priority", (int)task.Priority);
                            command.Parameters.AddWithValue("@Status", (int)task.Status);
                            command.Parameters.AddWithValue("@Category", task.Category);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating task: " + ex.Message, ex);
            }
        }

        public void DeleteTask(int taskId)
        {
            try
            {
                var task = tasks.FirstOrDefault(t => t.Id == taskId);
                if (task != null)
                {
                    tasks.Remove(task);

                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        string query = "DELETE FROM Tasks WHERE Id = @Id";
                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", taskId);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting task: " + ex.Message, ex);
            }
        }

        public Task GetTaskById(int taskId)
        {
            return tasks.FirstOrDefault(t => t.Id == taskId);
        }

        public List<Task> GetAllTasks()
        {
            return new List<Task>(tasks);
        }

        public List<Task> GetTasksByStatus(Status status)
        {
            return tasks.Where(t => t.Status == status).ToList();
        }

        public List<Task> GetTasksByPriority(Priority priority)
        {
            return tasks.Where(t => t.Priority == priority).ToList();
        }

        public List<Task> GetTasksByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
                return new List<Task>();

            return tasks.Where(t =>
                t.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Task> SearchTasks(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Task>();

            var term = searchTerm.ToLower();
            return tasks.Where(t =>
                t.Title.ToLower().Contains(term) ||
                (t.Description != null && t.Description.ToLower().Contains(term)) ||
                t.Category.ToLower().Contains(term)
            ).ToList();
        }

        // Дополнительные методы для статистики
        public int GetTaskCount()
        {
            return tasks.Count;
        }

        public int GetTaskCountByStatus(Status status)
        {
            return tasks.Count(t => t.Status == status);
        }

        public int GetTaskCountByPriority(Priority priority)
        {
            return tasks.Count(t => t.Priority == priority);
        }

        public List<string> GetUniqueCategories()
        {
            return tasks.Select(t => t.Category)
                       .Distinct()
                       .OrderBy(c => c)
                       .ToList();
        }

        public List<Task> GetOverdueTasks()
        {
            return tasks.Where(t => t.IsOverdue()).ToList();
        }

        public List<Task> GetTasksDueToday()
        {
            var today = DateTime.Today;
            return tasks.Where(t => t.DueDate.Date == today && t.Status != Status.Completed).ToList();
        }
    }
}