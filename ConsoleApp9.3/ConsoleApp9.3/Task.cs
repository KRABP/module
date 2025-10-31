using System;

namespace ConsoleApp9._3
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed
    }

    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public string DisplayInfo
        {
            get
            {
                var dueDateInfo = DueDate.HasValue ? $" - до {DueDate:dd.MM.yyyy HH:mm}" : "";
                return $"{Title} [{Status}] [{Priority}]{dueDateInfo}";
            }
        }
    }
}