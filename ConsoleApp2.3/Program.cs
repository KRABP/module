using System;
using System.Collections.Generic;

public class Author
{
    public string Name { get; set; }
    public int BirthYear { get; set; }

    public Author()
    {
        Name = "Неизвестный автор";
        BirthYear = DateTime.Now.Year;
    }

    // Конструктор с параметрами
    public Author(string name, int birthYear)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя автора не может быть пустым");

        if (birthYear <= 0 || birthYear > DateTime.Now.Year)
            throw new ArgumentException("Некорректный год рождения");

        Name = name;
        BirthYear = birthYear;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Автор: {Name}");
        Console.WriteLine($"Год рождения: {BirthYear}");
    }

    public int CalculateAge(int currentYear)
    {
        return currentYear - BirthYear;
    }
}

public class Book
{
    public string Title { get; set; }
    public int PublicationYear { get; set; }
    public Author Author { get; set; } // Композиция: книга содержит автора

    // Конструктор по умолчанию
    public Book()
    {
        Title = "Без названия";
        PublicationYear = DateTime.Now.Year;
        Author = new Author(); // Создание автора по умолчанию
    }

    // Конструктор с параметрами
    public Book(string title, int publicationYear, Author author)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Название книги не может быть пустым");

        if (publicationYear <= 0 || publicationYear > DateTime.Now.Year + 1)
            throw new ArgumentException("Некорректный год публикации");

        if (author == null)
            throw new ArgumentNullException(nameof(author), "Автор не может быть null");

        Title = title;
        PublicationYear = publicationYear;
        Author = author; // Композиция: книга использует существующий объект Author
    }

    // Метод для вывода информации о книге
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Книга: \"{Title}\"");
        Console.WriteLine($"Год публикации: {PublicationYear}");
        Console.WriteLine("--- Информация об авторе ---");
        Author.DisplayInfo();
        Console.WriteLine($"Возраст автора на момент публикации: {Author.CalculateAge(PublicationYear)} лет");
        Console.WriteLine();
    }

}

class Program
{
    static void Main(string[] args)
    {
        try
        {

            // Создание объектов Author
            Author author1 = new Author("Лев Толстой", 1828);
            Author author2 = new Author("Фёдор Достоевский", 1821);
            Author author3 = new Author("Антон Чехов", 1860);
            Author author4 = new Author("Александр Пушкин", 1799);

            // Создание объектов Book с использованием композиции
            Book book1 = new Book("Война и мир", 1869, author1);
            Book book2 = new Book("Анна Каренина", 1877, author1);
            Book book3 = new Book("Преступление и наказание", 1866, author2);
            Book book4 = new Book("Земля", 1869, author2);
            Book book5 = new Book("Вишнёвый сад", 1904, author3);
            Book book6 = new Book("Евгений Онегин", 1833, author4);

            // Вывод информации о книгах
            Console.WriteLine("Информация о книгах:");
            Console.WriteLine("====================\n");

            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();
            book4.DisplayInfo();
            book5.DisplayInfo();
            book6.DisplayInfo();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.ReadLine();
    }
}