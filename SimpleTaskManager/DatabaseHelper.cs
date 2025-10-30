using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace SimpleTaskManager
{
    public class DatabaseHelper
    {
        private string databaseFile = "tasks.db";
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = $"Data Source={databaseFile};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(databaseFile))
            {
                SQLiteConnection.CreateFile(databaseFile);
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
                        IsCompleted INTEGER DEFAULT 0,
                        Priority TEXT DEFAULT 'Medium',
                        CreatedAt TEXT NOT NULL
                    )";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Task> GetAllTasks()
        {
            var tasks = new List<Task>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Tasks ORDER BY IsCompleted, DueDate";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new Task
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            DueDate = DateTime.Parse(reader.GetString(3)),
                            IsCompleted = reader.GetInt32(4) == 1,
                            Priority = reader.GetString(5),
                            CreatedAt = DateTime.Parse(reader.GetString(6))
                        });
                    }
                }
            }

            return tasks;
        }

        public bool AddTask(Task task)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    INSERT INTO Tasks (Title, Description, DueDate, IsCompleted, Priority, CreatedAt)
                    VALUES (@Title, @Description, @DueDate, @IsCompleted, @Priority, @CreatedAt)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", task.Title);
                    command.Parameters.AddWithValue("@Description", task.Description ?? "");
                    command.Parameters.AddWithValue("@DueDate", task.DueDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted ? 1 : 0);
                    command.Parameters.AddWithValue("@Priority", task.Priority);
                    command.Parameters.AddWithValue("@CreatedAt", task.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateTask(Task task)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    UPDATE Tasks 
                    SET Title = @Title, 
                        Description = @Description, 
                        DueDate = @DueDate, 
                        IsCompleted = @IsCompleted,
                        Priority = @Priority
                    WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", task.Id);
                    command.Parameters.AddWithValue("@Title", task.Title);
                    command.Parameters.AddWithValue("@Description", task.Description ?? "");
                    command.Parameters.AddWithValue("@DueDate", task.DueDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted ? 1 : 0);
                    command.Parameters.AddWithValue("@Priority", task.Priority);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteTask(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Tasks WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}