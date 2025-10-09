using System;
using System.Collections.Generic;

public interface IBook
{
    string Title { get; set; }
    string Author { get; set; }
    bool IsAvailable();
    void BorrowBook();
    void ReturnBook();
}

public class PrintedBook : IBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    private bool isBorrowed;

    public PrintedBook(string title, string author)
    {
        Title = title;
        Author = author;
        isBorrowed = false;
    }

    public bool IsAvailable()
    {
        return !isBorrowed;
    }

    public void BorrowBook()
    {
        if (!isBorrowed)
        {
            isBorrowed = true;
            Console.WriteLine($"Книга '{Title}' выдана");
        }
        else
        {
            Console.WriteLine($"Книга '{Title}' уже выдана");
        }
    }

    public void ReturnBook()
    {
        if (isBorrowed)
        {
            isBorrowed = false;
            Console.WriteLine($"Книга '{Title}' возвращена");
        }
        else
        {
            Console.WriteLine($"Книга '{Title}' уже в библиотеке");
        }
    }
}

// Класс EBook (Электронная книга)
public class EBook : IBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    private int downloadCount;
    private const int MaxDownloads = 3;

    public EBook(string title, string author)
    {
        Title = title;
        Author = author;
        downloadCount = 0;
    }

    public bool IsAvailable()
    {
        return downloadCount < MaxDownloads;
    }

    public void BorrowBook()
    {
        if (downloadCount < MaxDownloads)
        {
            downloadCount++;
            Console.WriteLine($"Электронная книга '{Title}' скачана. Скачиваний: {downloadCount}/{MaxDownloads}");
        }
        else
        {
            Console.WriteLine($"Достигнут лимит скачиваний для книги '{Title}'");
        }
    }

    public void ReturnBook()
    {
        if (downloadCount > 0)
        {
            downloadCount--;
            Console.WriteLine($"Скачивание электронной книги '{Title}' отменено. Скачиваний: {downloadCount}/{MaxDownloads}");
        }
        else
        {
            Console.WriteLine($"Нет активных скачиваний для книги '{Title}'");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание списка книг
        List<IBook> books = new List<IBook>
        {
            new PrintedBook("Война и мир", "Лев Толстой"),
            new PrintedBook("Преступление и наказание", "Федор Достоевский"),
            new EBook("1984", "Джордж Оруэлл"),
            new EBook("Мастер и Маргарита", "Михаил Булгаков")
        };

        // Вывод информации о книгах
        Console.WriteLine("=== Библиотека книг ===");
        foreach (var book in books)
        {
            string status = book.IsAvailable() ? "доступна" : "не доступна";
            Console.WriteLine($"{book.Title} - {book.Author} ({status})");
        }

        // Работа с книгами
        Console.WriteLine("\n=== Выдача книг ===");
        books[0].BorrowBook(); // Печатная книга
        books[2].BorrowBook(); // Электронная книга
        books[2].BorrowBook(); // Электронная книга еще раз

        Console.WriteLine("\n=== Возврат книг ===");
        books[0].ReturnBook(); // Печатная книга
        books[2].ReturnBook(); // Электронная книга

        Console.WriteLine("\n=== Проверка доступности ===");
        foreach (var book in books)
        {
            string status = book.IsAvailable() ? "доступна" : "не доступна";
            Console.WriteLine($"{book.Title} - {status}");
        }
    }
}