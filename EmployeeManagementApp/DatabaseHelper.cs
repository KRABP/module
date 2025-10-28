using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace EmployeeManagementApp
{
    public class DatabaseHelper
    {
        private string databaseFile = "employees.db";
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
                    CREATE TABLE IF NOT EXISTS Employees (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        Position TEXT NOT NULL,
                        Salary DECIMAL(10,2) NOT NULL,
                        HireDate TEXT NOT NULL,
                        Department TEXT NOT NULL,
                        Email TEXT,
                        Phone TEXT,
                        Address TEXT
                    )";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Employees ORDER BY LastName, FirstName";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Position = reader.GetString(3),
                            Salary = reader.GetDecimal(4),
                            HireDate = DateTime.Parse(reader.GetString(5)),
                            Department = reader.GetString(6),
                            Email = reader.IsDBNull(7) ? "" : reader.GetString(7),
                            Phone = reader.IsDBNull(8) ? "" : reader.GetString(8),
                            Address = reader.IsDBNull(9) ? "" : reader.GetString(9)
                        });
                    }
                }
            }

            return employees;
        }

        public bool AddEmployee(Employee employee)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    INSERT INTO Employees 
                    (FirstName, LastName, Position, Salary, HireDate, Department, Email, Phone, Address)
                    VALUES (@FirstName, @LastName, @Position, @Salary, @HireDate, @Department, @Email, @Phone, @Address)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Position", employee.Position);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@HireDate", employee.HireDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@Email", employee.Email ?? "");
                    command.Parameters.AddWithValue("@Phone", employee.Phone ?? "");
                    command.Parameters.AddWithValue("@Address", employee.Address ?? "");

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    UPDATE Employees 
                    SET FirstName = @FirstName, 
                        LastName = @LastName, 
                        Position = @Position, 
                        Salary = @Salary, 
                        HireDate = @HireDate, 
                        Department = @Department, 
                        Email = @Email, 
                        Phone = @Phone, 
                        Address = @Address
                    WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Position", employee.Position);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@HireDate", employee.HireDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@Email", employee.Email ?? "");
                    command.Parameters.AddWithValue("@Phone", employee.Phone ?? "");
                    command.Parameters.AddWithValue("@Address", employee.Address ?? "");

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Employees WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Employee> SearchEmployees(string searchText)
        {
            var employees = new List<Employee>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT * FROM Employees 
                    WHERE FirstName LIKE @SearchText 
                       OR LastName LIKE @SearchText 
                       OR Position LIKE @SearchText 
                       OR Department LIKE @SearchText
                    ORDER BY LastName, FirstName";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Position = reader.GetString(3),
                                Salary = reader.GetDecimal(4),
                                HireDate = DateTime.Parse(reader.GetString(5)),
                                Department = reader.GetString(6),
                                Email = reader.IsDBNull(7) ? "" : reader.GetString(7),
                                Phone = reader.IsDBNull(8) ? "" : reader.GetString(8),
                                Address = reader.IsDBNull(9) ? "" : reader.GetString(9)
                            });
                        }
                    }
                }
            }

            return employees;
        }
    }
}