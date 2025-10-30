using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SimpleFinanceApp
{
    public partial class MainForm : Form
    {
        private DatabaseHelper database;
        private List<Transaction> transactions;
        private Transaction selectedTransaction;

        public MainForm()
        {
            InitializeComponent();
            listBoxTransactions.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxTransactions.DrawItem += listBoxTransactions_DrawItem;
            database = new DatabaseHelper();
            LoadTransactions();
            UpdateStatistics();
        }

        private void LoadTransactions()
        {
            transactions = database.GetAllTransactions();
            listBoxTransactions.Items.Clear();

            
            listBoxTransactions.DrawMode = DrawMode.OwnerDrawFixed;

            foreach (var transaction in transactions)
            {
                listBoxTransactions.Items.Add(transaction);
            }

           
            if (transactions.Count > 0)
            {
                Console.WriteLine($"Загружено {transactions.Count} транзакций");
                foreach (var transaction in transactions)
                {
                    Console.WriteLine(transaction.ToString());
                }
            }
        }


        private void UpdateStatistics()
        {
            decimal totalIncome = transactions.Where(t => t.Type == "Income").Sum(t => t.Amount);
            decimal totalExpenses = transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            decimal balance = totalIncome - totalExpenses;

            lblTotalIncome.Text = $"Доходы: {totalIncome:C}";
            lblTotalExpenses.Text = $"Расходы: {totalExpenses:C}";
            lblBalance.Text = $"Баланс: {balance:C}";

            
            lblBalance.ForeColor = balance >= 0 ? Color.Green : Color.Red;

        
            var categoryStats = transactions
                .Where(t => t.Type == "Expense")
                .GroupBy(t => t.Category)
                .Select(g => new { Category = g.Key, Total = g.Sum(t => t.Amount) })
                .OrderByDescending(x => x.Total)
                .Take(5);

            lblCategoryStats.Text = "Топ расходы: " + string.Join(", ",
                categoryStats.Select(x => $"{x.Category}({x.Total:C})"));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            var transaction = new Transaction
            {
                Description = txtDescription.Text.Trim(),
                Amount = numAmount.Value,
                Type = cmbType.Text,
                Category = cmbCategory.Text,
                Date = dtpDate.Value,
                
            };

            if (database.AddTransaction(transaction))
            {
                LoadTransactions();
                UpdateStatistics();
                ClearInputs();
                MessageBox.Show("Запись добавлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении записи!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTransaction == null)
            {
                MessageBox.Show("Выберите запись для редактирования!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            selectedTransaction.Description = txtDescription.Text.Trim();
            selectedTransaction.Amount = numAmount.Value;
            selectedTransaction.Type = cmbType.Text;
            selectedTransaction.Category = cmbCategory.Text;
            selectedTransaction.Date = dtpDate.Value;


            if (database.UpdateTransaction(selectedTransaction))
            {
                LoadTransactions();
                UpdateStatistics();
                ClearSelection();
                MessageBox.Show("Запись обновлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении записи!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTransaction == null)
            {
                MessageBox.Show("Выберите запись для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Удалить запись '{selectedTransaction.Description}'?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (database.DeleteTransaction(selectedTransaction.Id))
                {
                    LoadTransactions();
                    UpdateStatistics();
                    ClearSelection();
                    MessageBox.Show("Запись удалена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении записи!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBoxTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTransactions.SelectedIndex >= 0)
            {
                selectedTransaction = transactions[listBoxTransactions.SelectedIndex];
                ShowTransactionDetails(selectedTransaction);
            }
            else
            {
                ClearSelection();
            }
        }

        private void ShowTransactionDetails(Transaction transaction)
        {
            txtDescription.Text = transaction.Description;
            numAmount.Value = transaction.Amount;
            cmbType.Text = transaction.Type;
            cmbCategory.Text = transaction.Category;
            dtpDate.Value = transaction.Date;


            lblSelectedDetails.Text = $"ID: {transaction.Id} | {transaction.Date:dd.MM.yyyy HH:mm}";
        }

        private void ClearSelection()
        {
            selectedTransaction = null;
            ClearInputs();
            lblSelectedDetails.Text = "Выберите запись для просмотра деталей";
        }

        private void ClearInputs()
        {
            txtDescription.Clear();
            numAmount.Value = 0;
            cmbType.SelectedIndex = 1; // Expense
            cmbCategory.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now;

        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Введите описание!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Сумма должна быть больше 0!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numAmount.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Выберите категорию!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSelection();
        }

        

        private void listBoxTransactions_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            if (listBoxTransactions.Items[e.Index] is Transaction transaction)
            {
                Color textColor = e.ForeColor;

                // Устанавливаем цвет текста в зависимости от типа транзакции
                if (transaction.Type == "Income")
                {
                    textColor = Color.Green;
                }
                else
                {
                    textColor = Color.Red;
                }

                using (Brush brush = new SolidBrush(textColor))
                {
                    e.Graphics.DrawString(listBoxTransactions.Items[e.Index].ToString(),
                                         e.Font, brush, e.Bounds);
                }
            }
            else
            {
                using (Brush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(listBoxTransactions.Items[e.Index].ToString(),
                                         e.Font, brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadTransactions();
            UpdateStatistics();
        }
    }

    // Расширение для цветного ListBox
    public static class ListBoxExtensions
    {
        public static void SetItemColor(this ListBox listBox, int index, Color color)
        {
            // Для изменения цвета нужно обработать событие DrawItem
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
        }
    }
}