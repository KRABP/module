using System;

namespace TaskManagerOOP
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public enum Status
    {
        Pending,
        InProgress,
        Completed
    }

    public class Task
    {
        // Поля (инкапсуляция)
        private string title;
        private string description;
        private DateTime dueDate;
        private Priority priority;
        private Status status;
        private string category;
        private DateTime createdDate;

        // Свойства (геттеры и сеттеры)
        public int Id { get; set; }
        public string Title
        {
            get => title;
            set => title = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Title cannot be empty");
        }
        public string Description
        {
            get => description;
            set => description = value ?? "";
        }
        public DateTime DueDate
        {
            get => dueDate;
            set => dueDate = value;
        }
        public Priority Priority
        {
            get => priority;
            set => priority = value;
        }
        public Status Status
        {
            get => status;
            set => status = value;
        }
        public string Category
        {
            get => category;
            set => category = value ?? "General";
        }
        public DateTime CreatedDate => createdDate;

        // Конструктор
        public Task(string title, string description = "", Priority priority = Priority.Medium,
                   string category = "General", DateTime? dueDate = null)
        {
            Title = title;
            Description = description;
            Priority = priority;
            Category = category;
            DueDate = dueDate ?? DateTime.Now.AddDays(7);
            Status = Status.Pending;
            createdDate = DateTime.Now;
        }

        // Методы
        public void MarkInProgress()
        {
            Status = Status.InProgress;
        }

        public void MarkCompleted()
        {
            Status = Status.Completed;
        }

        public void UpdatePriority(Priority newPriority)
        {
            Priority = newPriority;
        }

        public bool IsOverdue()
        {
            return DateTime.Now > DueDate && Status != Status.Completed;
        }

        public override string ToString()
        {
            string statusIcon;
            switch (Status)
            {
                case Status.Pending:
                    statusIcon = "○";
                    break;
                case Status.InProgress:
                    statusIcon = "▶";
                    break;
                case Status.Completed:
                    statusIcon = "✓";
                    break;
                default:
                    statusIcon = "○";
                    break;
            }

            string priorityIcon;
            switch (Priority)
            {
                case Priority.Low:
                    priorityIcon = "↓";
                    break;
                case Priority.Medium:
                    priorityIcon = "→";
                    break;
                case Priority.High:
                    priorityIcon = "↑";
                    break;
                default:
                    priorityIcon = "→";
                    break;
            }

            string overdue = IsOverdue() ? " ⚠" : "";
            return $"{statusIcon} {priorityIcon} {Title} ({DueDate:dd.MM.yy}){overdue}";
        }
    }
}