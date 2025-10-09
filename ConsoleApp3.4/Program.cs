using System;
using System.Collections.Generic;

public class DataItem
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; }

    public DataItem(string title, string content, DateTime date, string category)
    {
        Title = title;
        Content = content;
        Date = date;
        Category = category;
    }

    public override string ToString()
    {
        return $"{Title} ({Date:dd.MM.yyyy}) - {Category}";
    }
}

class Program
{
    // Делегат для фильтрации данных
    public delegate bool FilterDelegate(DataItem item);

    // Методы-фильтры
    static bool FilterByDate(DataItem item)
    {
        Console.Write("Введите дату для фильтра (dd.MM.yyyy): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime filterDate))
        {
            return item.Date.Date == filterDate.Date;
        }
        return false;
    }

    static bool FilterByKeyword(DataItem item)
    {
        Console.Write("Введите ключевое слово: ");
        string keyword = Console.ReadLine().ToLower();
        return item.Title.ToLower().Contains(keyword) ||
               item.Content.ToLower().Contains(keyword);
    }

    static bool FilterByCategory(DataItem item)
    {
        Console.Write("Введите категорию: ");
        string category = Console.ReadLine().ToLower();
        return item.Category.ToLower().Contains(category);
    }

    static bool FilterByDateRange(DataItem item)
    {
        Console.Write("Введите начальную дату (dd.MM.yyyy): ");
        DateTime startDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Введите конечную дату (dd.MM.yyyy): ");
        DateTime endDate = DateTime.Parse(Console.ReadLine());
        return item.Date >= startDate && item.Date <= endDate;
    }

    // Метод для применения фильтра
    static List<DataItem> ApplyFilter(List<DataItem> data, FilterDelegate filter)
    {
        List<DataItem> result = new List<DataItem>();
        foreach (var item in data)
        {
            if (filter(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        // Создание тестовых данных
        List<DataItem> data = new List<DataItem>
        {
            new DataItem("Отчет за январь", "Ежемесячный финансовый отчет", new DateTime(2024, 1, 31), "Финансы"),
            new DataItem("Встреча с клиентом", "Обсуждение нового проекта", new DateTime(2024, 2, 15), "Встречи"),
            new DataItem("Техническое задание", "Разработка нового функционала", new DateTime(2024, 2, 20), "Разработка"),
            new DataItem("Финансовый план", "Планирование бюджета на квартал", new DateTime(2024, 3, 1), "Финансы"),
            new DataItem("Обучение сотрудников", "Проведение тренинга по новым технологиям", new DateTime(2024, 3, 10), "Обучение")
        };

        // Словарь доступных фильтров
        Dictionary<string, FilterDelegate> filters = new Dictionary<string, FilterDelegate>
        {
            { "1", FilterByDate },
            { "2", FilterByKeyword },
            { "3", FilterByCategory },
            { "4", FilterByDateRange }
        };

        while (true)
        {
            Console.WriteLine("\n=== Система фильтрации данных ===");
            Console.WriteLine("Исходные данные:");
            foreach (var item in data)
            {
                Console.WriteLine($"  {item}");
            }

            Console.WriteLine("\nДоступные фильтры:");
            Console.WriteLine("1. Фильтр по дате");
            Console.WriteLine("2. Фильтр по ключевому слову");
            Console.WriteLine("3. Фильтр по категории");
            Console.WriteLine("4. Фильтр по диапазону дат");
            Console.WriteLine("5. Выйти");
            Console.Write("Выберите фильтр: ");

            string choice = Console.ReadLine();

            if (choice == "5")
            {
                Console.WriteLine("Выход из системы...");
                break;
            }

            if (filters.ContainsKey(choice))
            {
                FilterDelegate selectedFilter = filters[choice];
                List<DataItem> filteredData = ApplyFilter(data, selectedFilter);

                Console.WriteLine("\nРезультаты фильтрации:");
                if (filteredData.Count > 0)
                {
                    foreach (var item in filteredData)
                    {
                        Console.WriteLine($"  {item}");
                        Console.WriteLine($"    Содержание: {item.Content}");
                    }
                }
                else
                {
                    Console.WriteLine("  Данные не найдены");
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор фильтра!");
            }
        }
    }
}