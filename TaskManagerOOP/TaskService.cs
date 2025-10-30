using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerOOP
{
    public class TaskService
    {
        // Агрегация - сервис использует репозиторий
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository repository)
        {
            taskRepository = repository;
        }

        // Бизнес-логика
        public void CreateTask(string title, string description = "", Priority priority = Priority.Medium,
                             string category = "General", DateTime? dueDate = null)
        {
            var task = new Task(title, description, priority, category, dueDate);
            taskRepository.AddTask(task);
        }

        public void CompleteTask(int taskId)
        {
            var task = taskRepository.GetTaskById(taskId);
            if (task != null)
            {
                task.MarkCompleted();
                taskRepository.UpdateTask(task);
            }
        }

        // ДОБАВЛЕННЫЙ МЕТОД
        public List<Task> GetAllTasks()
        {
            return taskRepository.GetAllTasks();
        }

        public List<Task> GetOverdueTasks()
        {
            return taskRepository.GetAllTasks().Where(t => t.IsOverdue()).ToList();
        }

        public List<Task> GetTasksDueToday()
        {
            return taskRepository.GetAllTasks()
                .Where(t => t.DueDate.Date == DateTime.Today && t.Status != Status.Completed)
                .ToList();
        }

        // Фильтрация и сортировка
        public List<Task> FilterTasks(Status? status = null, Priority? priority = null, string category = null)
        {
            var tasks = taskRepository.GetAllTasks();

            if (status.HasValue)
                tasks = tasks.Where(t => t.Status == status.Value).ToList();

            if (priority.HasValue)
                tasks = tasks.Where(t => t.Priority == priority.Value).ToList();

            if (!string.IsNullOrEmpty(category))
                tasks = tasks.Where(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();

            return tasks;
        }

        public List<Task> SortTasks(List<Task> tasks, string sortBy, bool ascending = true)
        {
            if (tasks == null) return new List<Task>();

            switch (sortBy.ToLower())
            {
                case "priority":
                    return ascending ?
                        tasks.OrderBy(t => t.Priority).ToList() :
                        tasks.OrderByDescending(t => t.Priority).ToList();

                case "duedate":
                    return ascending ?
                        tasks.OrderBy(t => t.DueDate).ToList() :
                        tasks.OrderByDescending(t => t.DueDate).ToList();

                case "status":
                    return ascending ?
                        tasks.OrderBy(t => t.Status).ToList() :
                        tasks.OrderByDescending(t => t.Status).ToList();

                case "category":
                    return ascending ?
                        tasks.OrderBy(t => t.Category).ToList() :
                        tasks.OrderByDescending(t => t.Category).ToList();

                default: // title
                    return ascending ?
                        tasks.OrderBy(t => t.Title).ToList() :
                        tasks.OrderByDescending(t => t.Title).ToList();
            }
        }

        public List<string> GetAllCategories()
        {
            return taskRepository.GetAllTasks()
                .Select(t => t.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToList();
        }

        public Dictionary<Status, int> GetStatusStatistics()
        {
            return taskRepository.GetAllTasks()
                .GroupBy(t => t.Status)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public Dictionary<Priority, int> GetPriorityStatistics()
        {
            return taskRepository.GetAllTasks()
                .GroupBy(t => t.Priority)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}