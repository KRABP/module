using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace SimpleFinanceApp
{
    public class DatabaseHelper
    {
        private string databaseFile = "finance.db";
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
                    CREATE TABLE IF NOT EXISTS Transactions (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Description TEXT NOT NULL,
                        Amount DECIMAL(10,2) NOT NULL,
                        Type TEXT NOT NULL,
                        Category TEXT NOT NULL,
                        Date TEXT NOT NULL,
                        Notes TEXT
                    )";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Transaction> GetAllTransactions()
        {
            var transactions = new List<Transaction>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Transactions ORDER BY Date DESC";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transactions.Add(new Transaction
                        {
                            Id = reader.GetInt32(0),
                            Description = reader.GetString(1),
                            Amount = reader.GetDecimal(2),
                            Type = reader.GetString(3),
                            Category = reader.GetString(4),
                            Date = DateTime.Parse(reader.GetString(5)),
                            Notes = reader.IsDBNull(6) ? "" : reader.GetString(6)
                        });
                    }
                }
            }

            return transactions;
        }

        public bool AddTransaction(Transaction transaction)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    INSERT INTO Transactions (Description, Amount, Type, Category, Date, Notes)
                    VALUES (@Description, @Amount, @Type, @Category, @Date, @Notes)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Description", transaction.Description);
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    command.Parameters.AddWithValue("@Type", transaction.Type);
                    command.Parameters.AddWithValue("@Category", transaction.Category);
                    command.Parameters.AddWithValue("@Date", transaction.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Notes", transaction.Notes ?? "");

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateTransaction(Transaction transaction)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    UPDATE Transactions 
                    SET Description = @Description, 
                        Amount = @Amount, 
                        Type = @Type, 
                        Category = @Category, 
                        Date = @Date,
                        Notes = @Notes
                    WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", transaction.Id);
                    command.Parameters.AddWithValue("@Description", transaction.Description);
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    command.Parameters.AddWithValue("@Type", transaction.Type);
                    command.Parameters.AddWithValue("@Category", transaction.Category);
                    command.Parameters.AddWithValue("@Date", transaction.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Notes", transaction.Notes ?? "");

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteTransaction(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Transactions WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Transaction> GetTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            var transactions = new List<Transaction>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT * FROM Transactions 
                    WHERE Date BETWEEN @StartDate AND @EndDate
                    ORDER BY Date DESC";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd 23:59:59"));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transactions.Add(new Transaction
                            {
                                Id = reader.GetInt32(0),
                                Description = reader.GetString(1),
                                Amount = reader.GetDecimal(2),
                                Type = reader.GetString(3),
                                Category = reader.GetString(4),
                                Date = DateTime.Parse(reader.GetString(5)),
                                Notes = reader.IsDBNull(6) ? "" : reader.GetString(6)
                            });
                        }
                    }
                }
            }

            return transactions;
        }
    }
}