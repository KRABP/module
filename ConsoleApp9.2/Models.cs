using System;

namespace ConsoleApp9._2
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Проект: {Name}, Описание: {Description}, Период: {StartDate:dd.MM.yyyy} - {EndDate:dd.MM.yyyy}";
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Сотрудник: {FirstName} {LastName}, Должность: {Position}, Email: {Email}";
        }
    }

    public class Task
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public int Progress { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProjectName { get; set; }
        public string AssignedEmployee { get; set; }

        public override string ToString()
        {
            string priorityText = GetPriorityText(Priority);
            string statusText = GetStatusText(Status);
            return $"ID: {Id}, Задача: {Title}, Проект: {ProjectName}, Приоритет: {priorityText}, Статус: {statusText}, Прогресс: {Progress}%, Исполнитель: {AssignedEmployee}, Срок: {DueDate:dd.MM.yyyy}";
        }

        private string GetPriorityText(int priority)
        {
            switch (priority)
            {
                case 1: return "Низкий";
                case 2: return "Средний";
                case 3: return "Высокий";
                default: return "Неизвестно";
            }
        }

        private string GetStatusText(int status)
        {
            switch (status)
            {
                case 1: return "Новая";
                case 2: return "В работе";
                case 3: return "Завершена";
                default: return "Неизвестно";
            }
        }
    }

    // Модели для отчетов
    public class ProjectReport
    {
        public string ProjectName { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public double CompletionPercentage { get; set; }
    }

    public class TaskReport
    {
        public string TaskTitle { get; set; }
        public string ProjectName { get; set; }
        public int Status { get; set; }
        public int Progress { get; set; }
        public string AssignedEmployee { get; set; }
    }

    public class EmployeeReport
    {
        public string EmployeeName { get; set; }
        public string Position { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
    }
}