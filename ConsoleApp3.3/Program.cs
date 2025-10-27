using System;
using System.Collections.Generic;

public class Task
{
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public Task(string description)
    {
        Description = description;
        CreatedAt = DateTime.Now;
    }
}

class Program
{
    public delegate void TaskExecutor(Task task);

    // Методы-обработчики задач
    static void SendNotification(Task task)
    {
        Console.WriteLine($" Уведомление: выполнена задача '{task.Description}'");
        Console.WriteLine($"   Время создания: {task.CreatedAt:HH:mm:ss}");
    }

    static void LogToJournal(Task task)
    {
        Console.WriteLine($"Запись в журнал: '{task.Description}'");
        Console.WriteLine($"   Время создания: {task.CreatedAt:HH:mm:ss}");
    }

    static void SendEmail(Task task)
    {
        Console.WriteLine($"Email отправлен: уведомление о задаче '{task.Description}'");
        Console.WriteLine($"   Время создания: {task.CreatedAt:HH:mm:ss}");
    }

    static void SaveToDatabase(Task task)
    {
        Console.WriteLine($"Сохранено в базу данных: '{task.Description}'");
        Console.WriteLine($"   Время создания: {task.CreatedAt:HH:mm:ss}");
    }

    static void Main(string[] args)
    {
        List<Task> tasks = new List<Task>();
        Dictionary<string, TaskExecutor> executors = new Dictionary<string, TaskExecutor>
        {
            { "1", SendNotification },
            { "2", LogToJournal },
            { "3", SendEmail },
            { "4", SaveToDatabase }
        };

        while (true)
        {
            Console.WriteLine("\n=== Управление задачами ===");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Выполнить задачи");
            Console.WriteLine("3. Выйти");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите описание задачи: ");
                    string description = Console.ReadLine();
                    tasks.Add(new Task(description));
                    Console.WriteLine("Задача добавлена!");
                    break;

                case "2":
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("Список задач пуст!");
                        break;
                    }

                    Console.WriteLine("\nДоступные исполнители:");
                    Console.WriteLine("1. Отправить уведомление");
                    Console.WriteLine("2. Записать в журнал");
                    Console.WriteLine("3. Отправить email");
                    Console.WriteLine("4. Сохранить в базу данных");
                    Console.Write("Выберите исполнителя: ");

                    string executorChoice = Console.ReadLine();

                    if (executors.ContainsKey(executorChoice))
                    {
                        TaskExecutor executor = executors[executorChoice];
                        Console.WriteLine($"\nВыполнение задач:");

                        foreach (var task in tasks)
                        {
                            executor(task);
                        }

                        tasks.Clear();
                        Console.WriteLine("Все задачи выполнены и удалены из списка!");
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор исполнителя!");
                    }
                    break;

                case "3":
                    Console.WriteLine("Выход из приложения...");
                    return;

                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }

}
