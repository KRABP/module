using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading.Tasks;

namespace TaskManagerOOP
{
    public interface ITaskRepository
    {
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(int taskId);
        Task GetTaskById(int taskId);
        List<Task> GetAllTasks();
        List<Task> GetTasksByStatus(Status status);
        List<Task> GetTasksByPriority(Priority priority);
        List<Task> GetTasksByCategory(string category);
        List<Task> SearchTasks(string searchTerm);
    }
}