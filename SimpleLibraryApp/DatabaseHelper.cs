using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace SimpleLibraryApp
{
    public class DatabaseHelper
    {
        private string databaseFile = "library.db";
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
                    CREATE TABLE IF NOT EXISTS Books (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Author TEXT NOT NULL,
                        Genre TEXT NOT NULL,
                        Year INTEGER NOT NULL,
                        IsAvailable INTEGER DEFAULT 1,
                        RentedBy TEXT,
                        RentDate TEXT,
                        ReturnDate TEXT
                    )";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Добавляем тестовые данные, если таблица пустая
                string checkDataQuery = "SELECT COUNT(*) FROM Books";
                using (var command = new SQLiteCommand(checkDataQuery, connection))
                {
                    long count = (long)command.ExecuteScalar();
                    if (count == 0)
                    {
                        AddSampleBooks(connection);
                    }
                }
            }
        }

        private void AddSampleBooks(SQLiteConnection connection)
        {
            var sampleBooks = new[]
            {
                new { Title = "Война и мир", Author = "Лев Толстой", Genre = "Роман", Year = 1869 },
                new { Title = "Преступление и наказание", Author = "Федор Достоевский", Genre = "Роман", Year = 1866 },
                new { Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Genre = "Роман", Year = 1967 },
                new { Title = "1984", Author = "Джордж Оруэлл", Genre = "Антиутопия", Year = 1949 },
                new { Title = "Гарри Поттер и философский камень", Author = "Джоан Роулинг", Genre = "Фэнтези", Year = 1997 },
                new { Title = "Убить пересмешника", Author = "Харпер Ли", Genre = "Роман", Year = 1960 },
                new { Title = "Властелин колец", Author = "Дж. Р. Р. Толкин", Genre = "Фэнтези", Year = 1954 }
            };

            foreach (var book in sampleBooks)
            {
                string query = @"
                    INSERT INTO Books (Title, Author, Genre, Year, IsAvailable)
                    VALUES (@Title, @Author, @Genre, @Year, 1)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@Year", book.Year);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Books ORDER BY Title";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            Genre = reader.GetString(3),
                            Year = reader.GetInt32(4),
                            IsAvailable = reader.GetInt32(5) == 1,
                            RentedBy = reader.IsDBNull(6) ? null : reader.GetString(6),
                            RentDate = reader.IsDBNull(7) ? null : (DateTime?)DateTime.Parse(reader.GetString(7)),
                            ReturnDate = reader.IsDBNull(8) ? null : (DateTime?)DateTime.Parse(reader.GetString(8))
                        });
                    }
                }
            }

            return books;
        }

        public bool AddBook(Book book)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    INSERT INTO Books (Title, Author, Genre, Year, IsAvailable)
                    VALUES (@Title, @Author, @Genre, @Year, 1)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@Year", book.Year);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool RentBook(int bookId, string readerName)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    UPDATE Books 
                    SET IsAvailable = 0, 
                        RentedBy = @RentedBy, 
                        RentDate = @RentDate,
                        ReturnDate = @ReturnDate
                    WHERE Id = @Id AND IsAvailable = 1";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", bookId);
                    command.Parameters.AddWithValue("@RentedBy", readerName);
                    command.Parameters.AddWithValue("@RentDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@ReturnDate", DateTime.Now.AddDays(14).ToString("yyyy-MM-dd HH:mm:ss"));

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ReturnBook(int bookId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    UPDATE Books 
                    SET IsAvailable = 1, 
                        RentedBy = NULL, 
                        RentDate = NULL,
                        ReturnDate = NULL
                    WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", bookId);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Book> SearchBooks(string searchText)
        {
            var books = new List<Book>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT * FROM Books 
                    WHERE Title LIKE @SearchText 
                       OR Author LIKE @SearchText 
                       OR Genre LIKE @SearchText
                    ORDER BY Title";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Author = reader.GetString(2),
                                Genre = reader.GetString(3),
                                Year = reader.GetInt32(4),
                                IsAvailable = reader.GetInt32(5) == 1,
                                RentedBy = reader.IsDBNull(6) ? null : reader.GetString(6),
                                RentDate = reader.IsDBNull(7) ? null : (DateTime?)DateTime.Parse(reader.GetString(7)),
                                ReturnDate = reader.IsDBNull(8) ? null : (DateTime?)DateTime.Parse(reader.GetString(8))
                            });
                        }
                    }
                }
            }

            return books;
        }
    }
}