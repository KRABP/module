using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace ConsoleApp9._2
{
    public class DatabaseManager
    {
        private string connectionString = "Data Source=project_tasks.db;Version=3;";

        public void InitializeDatabase()
        {
            if (!File.Exists("project_tasks.db"))
            {
                SQLiteConnection.CreateFile("project_tasks.db");
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Таблица проектов
                string createProjectsTable = @"
                    CREATE TABLE IF NOT EXISTS Projects (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Description TEXT,
                        StartDate DATE NOT NULL,
                        EndDate DATE NOT NULL,
                        CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP
                    )";

                // Таблица сотрудников
                string createEmployeesTable = @"
                    CREATE TABLE IF NOT EXISTS Employees (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        Position TEXT NOT NULL,
                        Email TEXT,
                        CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP
                    )";

                // Таблица задач
                string createTasksTable = @"
                    CREATE TABLE IF NOT EXISTS Tasks (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ProjectId INTEGER NOT NULL,
                        Title TEXT NOT NULL,
                        Description TEXT,
                        Priority INTEGER DEFAULT 1,
                        Status INTEGER DEFAULT 1,
                        Progress INTEGER DEFAULT 0,
                        DueDate DATE NOT NULL,
                        CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
                    )";

                // Таблица назначений задач
                string createTaskAssignmentsTable = @"
                    CREATE TABLE IF NOT EXISTS TaskAssignments (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        TaskId INTEGER NOT NULL,
                        EmployeeId INTEGER NOT NULL,
                        AssignedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (TaskId) REFERENCES Tasks(Id),
                        FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
                    )";

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = createProjectsTable;
                    command.ExecuteNonQuery();

                    command.CommandText = createEmployeesTable;
                    command.ExecuteNonQuery();

                    command.CommandText = createTasksTable;
                    command.ExecuteNonQuery();

                    command.CommandText = createTaskAssignmentsTable;
                    command.ExecuteNonQuery();
                }
            }
        }

        // Методы для работы с проектами
        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Projects ORDER BY CreatedDate DESC";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        projects.Add(new Project
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            StartDate = reader.GetDateTime(3),
                            EndDate = reader.GetDateTime(4),
                            CreatedDate = reader.GetDateTime(5)
                        });
                    }
                }
            }

            return projects;
        }

        public void AddProject(string name, string description, DateTime startDate, DateTime endDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Projects (Name, Description, StartDate, EndDate) VALUES (@name, @description, @startDate, @endDate)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProject(int id, string name, string description)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Projects SET Name = @name, Description = @description WHERE Id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@description", description);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProject(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Projects WHERE Id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Project GetProject(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Projects WHERE Id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Project
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                StartDate = reader.GetDateTime(3),
                                EndDate = reader.GetDateTime(4),
                                CreatedDate = reader.GetDateTime(5)
                            };
                        }
                    }
                }
            }

            return null;
        }

        // Методы для работы с сотрудниками
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees ORDER BY CreatedDate DESC";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Position = reader.GetString(3),
                            Email = reader.GetString(4),
                            CreatedDate = reader.GetDateTime(5)
                        });
                    }
                }
            }

            return employees;
        }

        public void AddEmployee(string firstName, string lastName, string position, string email)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Employees (FirstName, LastName, Position, Email) VALUES (@firstName, @lastName, @position, @email)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@position", position);
                    command.Parameters.AddWithValue("@email", email);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEmployee(int id, string firstName, string lastName, string position)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Employees SET FirstName = @firstName, LastName = @lastName, Position = @position WHERE Id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@position", position);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Employees WHERE Id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Employee GetEmployee(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees WHERE Id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Employee
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Position = reader.GetString(3),
                                Email = reader.GetString(4),
                                CreatedDate = reader.GetDateTime(5)
                            };
                        }
                    }
                }
            }

            return null;
        }

        // Методы для работы с задачами
        public List<Task> GetAllTasksWithDetails()
        {
            List<Task> tasks = new List<Task>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT t.*, p.Name as ProjectName, 
                           e.FirstName || ' ' || e.LastName as AssignedEmployee
                    FROM Tasks t
                    LEFT JOIN Projects p ON t.ProjectId = p.Id
                    LEFT JOIN TaskAssignments ta ON t.Id = ta.TaskId
                    LEFT JOIN Employees e ON ta.EmployeeId = e.Id
                    ORDER BY t.CreatedDate DESC";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new Task
                        {
                            Id = reader.GetInt32(0),
                            ProjectId = reader.GetInt32(1),
                            Title = reader.GetString(2),
                            Description = reader.GetString(3),
                            Priority = reader.GetInt32(4),
                            Status = reader.GetInt32(5),
                            Progress = reader.GetInt32(6),
                            DueDate = reader.GetDateTime(7),
                            CreatedDate = reader.GetDateTime(8),
                            ProjectName = reader.IsDBNull(9) ? "" : reader.GetString(9),
                            AssignedEmployee = reader.IsDBNull(10) ? "Не назначена" : reader.GetString(10)
                        });
                    }
                }
            }

            return tasks;
        }

        public void AddTask(int projectId, string title, string description, int priority, DateTime dueDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Tasks (ProjectId, Title, Description, Priority, DueDate) VALUES (@projectId, @title, @description, @priority, @dueDate)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@projectId", projectId);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@priority", priority);
                    command.Parameters.AddWithValue("@dueDate", dueDate);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTask(int id, string title, string description, int priority)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Tasks SET Title = @title, Description = @description, Priority = @priority WHERE Id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@priority", priority);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTask(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Сначала удаляем назначения
                string deleteAssignments = "DELETE FROM TaskAssignments WHERE TaskId = @id";
                using (SQLiteCommand command = new SQLiteCommand(deleteAssignments, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

                // Затем удаляем задачу
                string deleteTask = "DELETE FROM Tasks WHERE Id = @id";
                using (SQLiteCommand command = new SQLiteCommand(deleteTask, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Task GetTask(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Tasks WHERE Id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Task
                            {
                                Id = reader.GetInt32(0),
                                ProjectId = reader.GetInt32(1),
                                Title = reader.GetString(2),
                                Description = reader.GetString(3),
                                Priority = reader.GetInt32(4),
                                Status = reader.GetInt32(5),
                                Progress = reader.GetInt32(6),
                                DueDate = reader.GetDateTime(7),
                                CreatedDate = reader.GetDateTime(8)
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void AssignTaskToEmployee(int taskId, int employeeId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Удаляем предыдущие назначения для этой задачи
                string deleteQuery = "DELETE FROM TaskAssignments WHERE TaskId = @taskId";
                using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@taskId", taskId);
                    deleteCommand.ExecuteNonQuery();
                }

                // Добавляем новое назначение
                string insertQuery = "INSERT INTO TaskAssignments (TaskId, EmployeeId) VALUES (@taskId, @employeeId)";
                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@taskId", taskId);
                    insertCommand.Parameters.AddWithValue("@employeeId", employeeId);
                    insertCommand.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTaskProgress(int taskId, int progress, int status)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Tasks SET Progress = @progress, Status = @status WHERE Id = @taskId";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@taskId", taskId);
                    command.Parameters.AddWithValue("@progress", progress);
                    command.Parameters.AddWithValue("@status", status);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Методы для отчетов
        public List<ProjectReport> GetProjectReport()
        {
            List<ProjectReport> report = new List<ProjectReport>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT p.Name,
                           COUNT(t.Id) as TotalTasks,
                           SUM(CASE WHEN t.Status = 3 THEN 1 ELSE 0 END) as CompletedTasks,
                           CASE WHEN COUNT(t.Id) > 0 THEN 
                               ROUND(SUM(CASE WHEN t.Status = 3 THEN 1 ELSE 0 END) * 100.0 / COUNT(t.Id), 2)
                           ELSE 0 END as CompletionPercentage
                    FROM Projects p
                    LEFT JOIN Tasks t ON p.Id = t.ProjectId
                    GROUP BY p.Id, p.Name
                    ORDER BY p.CreatedDate DESC";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        report.Add(new ProjectReport
                        {
                            ProjectName = reader.GetString(0),
                            TotalTasks = reader.GetInt32(1),
                            CompletedTasks = reader.GetInt32(2),
                            CompletionPercentage = reader.GetDouble(3)
                        });
                    }
                }
            }

            return report;
        }

        public List<TaskReport> GetTaskReport()
        {
            List<TaskReport> report = new List<TaskReport>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT t.Title as TaskTitle, 
                           p.Name as ProjectName,
                           t.Status,
                           t.Progress,
                           e.FirstName || ' ' || e.LastName as AssignedEmployee
                    FROM Tasks t
                    LEFT JOIN Projects p ON t.ProjectId = p.Id
                    LEFT JOIN TaskAssignments ta ON t.Id = ta.TaskId
                    LEFT JOIN Employees e ON ta.EmployeeId = e.Id
                    ORDER BY t.Priority DESC, t.DueDate ASC";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        report.Add(new TaskReport
                        {
                            TaskTitle = reader.GetString(0),
                            ProjectName = reader.GetString(1),
                            Status = reader.GetInt32(2),
                            Progress = reader.GetInt32(3),
                            AssignedEmployee = reader.IsDBNull(4) ? "Не назначена" : reader.GetString(4)
                        });
                    }
                }
            }

            return report;
        }

        public List<EmployeeReport> GetEmployeeReport()
        {
            List<EmployeeReport> report = new List<EmployeeReport>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT e.FirstName || ' ' || e.LastName as EmployeeName,
                           e.Position,
                           COUNT(ta.TaskId) as TotalTasks,
                           SUM(CASE WHEN t.Status = 3 THEN 1 ELSE 0 END) as CompletedTasks
                    FROM Employees e
                    LEFT JOIN TaskAssignments ta ON e.Id = ta.EmployeeId
                    LEFT JOIN Tasks t ON ta.TaskId = t.Id
                    GROUP BY e.Id, e.FirstName, e.LastName, e.Position
                    ORDER BY TotalTasks DESC";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        report.Add(new EmployeeReport
                        {
                            EmployeeName = reader.GetString(0),
                            Position = reader.GetString(1),
                            TotalTasks = reader.GetInt32(2),
                            CompletedTasks = reader.GetInt32(3)
                        });
                    }
                }
            }

            return report;
        }
    }
}