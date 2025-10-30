using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleLibraryApp
{
    public partial class MainForm : Form
    {
        private DatabaseHelper database;
        private List<Book> books;
        private Book selectedBook;

        public MainForm()
        {
            InitializeComponent();
            database = new DatabaseHelper();
            LoadBooks();
            UpdateStatistics();
        }

        private void LoadBooks()
        {
            books = database.GetAllBooks();
            listBoxBooks.Items.Clear();
            foreach (var book in books)
            {
                listBoxBooks.Items.Add(book);
            }
        }

        private void UpdateStatistics()
        {
            int total = books.Count;
            int available = books.FindAll(b => b.IsAvailable).Count;
            int rented = total - available;

            lblStats.Text = $"Всего книг: {total} | Доступно: {available} | Арендовано: {rented}";
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string genre = txtGenre.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(genre))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtYear.Text, out int year) || year < 1000 || year > DateTime.Now.Year)
            {
                MessageBox.Show("Введите корректный год издания!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var book = new Book
            {
                Title = title,
                Author = author,
                Genre = genre,
                Year = year
            };

            if (database.AddBook(book))
            {
                LoadBooks();
                UpdateStatistics();
                ClearInputs();
                MessageBox.Show("Книга добавлена в библиотеку!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении книги!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (selectedBook == null)
            {
                MessageBox.Show("Выберите книгу для аренды!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!selectedBook.IsAvailable)
            {
                MessageBox.Show("Эта книга уже арендована!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string readerName = txtReaderName.Text.Trim();
            if (string.IsNullOrEmpty(readerName))
            {
                MessageBox.Show("Введите имя читателя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (database.RentBook(selectedBook.Id, readerName))
            {
                LoadBooks();
                UpdateStatistics();
                ShowBookDetails(selectedBook);
                MessageBox.Show($"Книга '{selectedBook.Title}' арендована читателем {readerName}!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при аренде книги!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (selectedBook == null)
            {
                MessageBox.Show("Выберите книгу для возврата!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedBook.IsAvailable)
            {
                MessageBox.Show("Эта книга уже доступна в библиотеке!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (database.ReturnBook(selectedBook.Id))
            {
                LoadBooks();
                UpdateStatistics();
                ShowBookDetails(selectedBook);
                MessageBox.Show($"Книга '{selectedBook.Title}' возвращена в библиотеку!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при возврате книги!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBooks.SelectedIndex >= 0)
            {
                selectedBook = books[listBoxBooks.SelectedIndex];
                ShowBookDetails(selectedBook);
            }
            else
            {
                ClearSelection();
            }
        }

        private void ShowBookDetails(Book book)
        {
            lblDetails.Text = $"Автор: {book.Author}\r\n" +
                            $"Жанр: {book.Genre}\r\n" +
                            $"Год: {book.Year}\r\n" +
                            $"Статус: {(book.IsAvailable ? "Доступна" : "Арендована")}";

            if (!book.IsAvailable)
            {
                lblDetails.Text += $"\r\nЧитатель: {book.RentedBy}" +
                                 $"\r\nДата аренды: {book.RentDate:dd.MM.yyyy}" +
                                 $"\r\nВернуть до: {book.ReturnDate:dd.MM.yyyy}";
            }

            btnRent.Enabled = book.IsAvailable;
            btnReturn.Enabled = !book.IsAvailable;
        }

        private void ClearSelection()
        {
            selectedBook = null;
            lblDetails.Text = "Выберите книгу для просмотра деталей";
            btnRent.Enabled = false;
            btnReturn.Enabled = false;
        }

        private void ClearInputs()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtGenre.Clear();
            txtYear.Clear();
            txtReaderName.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadBooks();
            }
            else
            {
                var searchResults = database.SearchBooks(txtSearch.Text);
                listBoxBooks.Items.Clear();
                foreach (var book in searchResults)
                {
                    listBoxBooks.Items.Add(book);
                }
            }
            UpdateStatistics();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtSearch.Clear();
        }
    }
}
