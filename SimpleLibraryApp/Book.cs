using System;

namespace SimpleLibraryApp
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; }
        public string RentedBy { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public override string ToString()
        {
            string status = IsAvailable ? "✓ Доступна" : $"✗ Арендована ({RentedBy})";
            return $"{Title} - {Author} [{status}]";
        }
    }
}