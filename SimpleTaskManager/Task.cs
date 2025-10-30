using System;

namespace SimpleTaskManager
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedAt { get; set; }

        public Task()
        {
            DueDate = DateTime.Now.AddDays(1);
            CreatedAt = DateTime.Now;
            Priority = "Medium";
        }

        public override string ToString()
        {
            string status = IsCompleted ? "✓" : "○";
            return $"{status} {Title} (до {DueDate:dd.MM.yyyy})";
        }
    }
}