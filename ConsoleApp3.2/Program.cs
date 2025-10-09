using System;

public class Notification
{
    // События для разных типов уведомлений
    public event Action<string> MessageReceived;
    public event Action<string> CallReceived;
    public event Action<string, string> EmailReceived;

    // Методы для генерации событий
    public void SendMessage(string message)
    {
        Console.WriteLine($"Новое сообщение: {message}");
        MessageReceived?.Invoke(message);
    }

    public void MakeCall(string caller)
    {
        Console.WriteLine($"Входящий звонок от: {caller}");
        CallReceived?.Invoke(caller);
    }

    public void SendEmail(string sender, string subject)
    {
        Console.WriteLine($"Новое письмо от: {sender} - {subject}");
        EmailReceived?.Invoke(sender, subject);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Notification notification = new Notification();

        // Регистрация обработчиков событий для сообщений
        notification.MessageReceived += (message) =>
        {
            Console.WriteLine($"Обработка сообщения: показать уведомление - '{message}'");
        };

        notification.MessageReceived += (message) =>
        {
            Console.WriteLine($"Обработка сообщения: сохранить в историю - '{message}'");
        };

        // Регистрация обработчиков событий для звонков
        notification.CallReceived += (caller) =>
        {
            Console.WriteLine($"Обработка звонка: показать экран вызова от '{caller}'");
        };

        notification.CallReceived += (caller) =>
        {
            Console.WriteLine($"Обработка звонка: записать в журнал вызовов '{caller}'");
        };

        // Регистрация обработчиков событий для email
        notification.EmailReceived += (sender, subject) =>
        {
            Console.WriteLine($"Обработка email: уведомить пользователя о письме от '{sender}'");
        };

        notification.EmailReceived += (sender, subject) =>
        {
            Console.WriteLine($"Обработка email: добавить в папку 'Входящие' - '{subject}'");
        };

        // Генерация событий
        Console.WriteLine("=== Отправка сообщения ===");
        notification.SendMessage("Привет! Как дела?");

        Console.WriteLine("\n=== Входящий звонок ===");
        notification.MakeCall("Иван Петров");

        Console.WriteLine("\n=== Получение email ===");
        notification.SendEmail("company@example.com", "Ваш заказ готов");

        Console.WriteLine("\n=== Еще одно сообщение ===");
        notification.SendMessage("Напоминание о встрече");
    }
}