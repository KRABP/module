using System;

namespace SimpleFinanceApp
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // "Income" или "Expense"
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public Transaction()
        {
            Date = DateTime.Now;
            Type = "Expense";
        }

        public override string ToString()
        {
            string sign = Type == "Income" ? "+" : "-";
            return $"{Date:dd.MM.yy} {sign}{Amount:C} - {Description}";
        }
    }
}