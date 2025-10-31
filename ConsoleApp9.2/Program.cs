using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace ConsoleApp9._2
{
    class Program
    {
        private static DatabaseManager dbManager;

        static void Main(string[] args)
        {
            dbManager = new DatabaseManager();
            dbManager.InitializeDatabase();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Управление задачами проекта ===");
                Console.WriteLine("1. Управление проектами");
                Console.WriteLine("2. Управление сотрудниками");
                Console.WriteLine("3. Управление задачами");
                Console.WriteLine("4. Отчеты");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageProjects();
                        break;
                    case "2":
                        ManageEmployees();
                        break;
                    case "3":
                        ManageTasks();
                        break;
                    case "4":
                        GenerateReports();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        static void ManageProjects()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Управление проектами ===");
                Console.WriteLine("1. Показать все проекты");
                Console.WriteLine("2. Добавить проект");
                Console.WriteLine("3. Редактировать проект");
                Console.WriteLine("4. Удалить проект");
                Console.WriteLine("5. Назад");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllProjects();
                        break;
                    case "2":
                        AddProject();
                        break;
                    case "3":
                        EditProject();
                        break;
                    case "4":
                        DeleteProject();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        static void ManageEmployees()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Управление сотрудниками ===");
                Console.WriteLine("1. Показать всех сотрудников");
                Console.WriteLine("2. Добавить сотрудника");
                Console.WriteLine("3. Редактировать сотрудника");
                Console.WriteLine("4. Удалить сотрудника");
                Console.WriteLine("5. Назад");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllEmployees();
                        break;
                    case "2":
                        AddEmployee();
                        break;
                    case "3":
                        EditEmployee();
                        break;
                    case "4":
                        DeleteEmployee();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        static void ManageTasks()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Управление задачами ===");
                Console.WriteLine("1. Показать все задачи");
                Console.WriteLine("2. Добавить задачу");
                Console.WriteLine("3. Редактировать задачу");
                Console.WriteLine("4. Удалить задачу");
                Console.WriteLine("5. Назначить задачу сотруднику");
                Console.WriteLine("6. Обновить прогресс задачи");
                Console.WriteLine("7. Назад");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllTasks();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        EditTask();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        AssignTaskToEmployee();
                        break;
                    case "6":
                        UpdateTaskProgress();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        static void GenerateReports()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Отчеты ===");
                Console.WriteLine("1. Отчет по проектам");
                Console.WriteLine("2. Отчет по задачам");
                Console.WriteLine("3. Отчет по сотрудникам");
                Console.WriteLine("4. Назад");
                Console.Write("Выберите отчет: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GenerateProjectReport();
                        break;
                    case "2":
                        GenerateTaskReport();
                        break;
                    case "3":
                        GenerateEmployeeReport();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        // Методы для работы с проектами
        static void ShowAllProjects()
        {
            List<Project> projects = dbManager.GetAllProjects();
            Console.WriteLine("\n=== Все проекты ===");
            foreach (Project project in projects)
            {
                Console.WriteLine(project);
            }
        }

        static void AddProject()
        {
            Console.WriteLine("\n=== Добавление проекта ===");
            Console.Write("Название проекта: ");
            string name = Console.ReadLine();
            Console.Write("Описание: ");
            string description = Console.ReadLine();
            Console.Write("Дата начала (гггг-мм-дд): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Дата окончания (гггг-мм-дд): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            dbManager.AddProject(name, description, startDate, endDate);
            Console.WriteLine("Проект добавлен!");
        }

        static void EditProject()
        {
            ShowAllProjects();
            Console.Write("Введите ID проекта для редактирования: ");
            int id = int.Parse(Console.ReadLine());

            Project project = dbManager.GetProject(id);
            if (project == null)
            {
                Console.WriteLine("Проект не найден!");
                return;
            }

            Console.WriteLine($"Редактирование: {project}");
            Console.Write("Новое название: ");
            string name = Console.ReadLine();
            Console.Write("Новое описание: ");
            string description = Console.ReadLine();

            dbManager.UpdateProject(id, name, description);
            Console.WriteLine("Проект обновлен!");
        }

        static void DeleteProject()
        {
            ShowAllProjects();
            Console.Write("Введите ID проекта для удаления: ");
            int id = int.Parse(Console.ReadLine());

            dbManager.DeleteProject(id);
            Console.WriteLine("Проект удален!");
        }

        // Методы для работы с сотрудниками
        static void ShowAllEmployees()
        {
            List<Employee> employees = dbManager.GetAllEmployees();
            Console.WriteLine("\n=== Все сотрудники ===");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        static void AddEmployee()
        {
            Console.WriteLine("\n=== Добавление сотрудника ===");
            Console.Write("Имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Фамилия: ");
            string lastName = Console.ReadLine();
            Console.Write("Должность: ");
            string position = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            dbManager.AddEmployee(firstName, lastName, position, email);
            Console.WriteLine("Сотрудник добавлен!");
        }

        static void EditEmployee()
        {
            ShowAllEmployees();
            Console.Write("Введите ID сотрудника для редактирования: ");
            int id = int.Parse(Console.ReadLine());

            Employee employee = dbManager.GetEmployee(id);
            if (employee == null)
            {
                Console.WriteLine("Сотрудник не найден!");
                return;
            }

            Console.WriteLine($"Редактирование: {employee}");
            Console.Write("Новое имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Новая фамилия: ");
            string lastName = Console.ReadLine();
            Console.Write("Новая должность: ");
            string position = Console.ReadLine();

            dbManager.UpdateEmployee(id, firstName, lastName, position);
            Console.WriteLine("Сотрудник обновлен!");
        }

        static void DeleteEmployee()
        {
            ShowAllEmployees();
            Console.Write("Введите ID сотрудника для удаления: ");
            int id = int.Parse(Console.ReadLine());

            dbManager.DeleteEmployee(id);
            Console.WriteLine("Сотрудник удален!");
        }

        // Методы для работы с задачами
        static void ShowAllTasks()
        {
            List<Task> tasks = dbManager.GetAllTasksWithDetails();
            Console.WriteLine("\n=== Все задачи ===");
            foreach (Task task in tasks)
            {
                Console.WriteLine(task);
            }
        }

        static void AddTask()
        {
            ShowAllProjects();
            Console.WriteLine("\n=== Добавление задачи ===");
            Console.Write("ID проекта: ");
            int projectId = int.Parse(Console.ReadLine());
            Console.Write("Название задачи: ");
            string title = Console.ReadLine();
            Console.Write("Описание: ");
            string description = Console.ReadLine();
            Console.Write("Приоритет (1-Низкий, 2-Средний, 3-Высокий): ");
            int priority = int.Parse(Console.ReadLine());
            Console.Write("Срок выполнения (гггг-мм-дд): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            dbManager.AddTask(projectId, title, description, priority, dueDate);
            Console.WriteLine("Задача добавлена!");
        }

        static void EditTask()
        {
            ShowAllTasks();
            Console.Write("Введите ID задачи для редактирования: ");
            int id = int.Parse(Console.ReadLine());

            Task task = dbManager.GetTask(id);
            if (task == null)
            {
                Console.WriteLine("Задача не найдена!");
                return;
            }

            Console.WriteLine($"Редактирование: {task}");
            Console.Write("Новое название: ");
            string title = Console.ReadLine();
            Console.Write("Новое описание: ");
            string description = Console.ReadLine();
            Console.Write("Новый приоритет (1-3): ");
            int priority = int.Parse(Console.ReadLine());

            dbManager.UpdateTask(id, title, description, priority);
            Console.WriteLine("Задача обновлена!");
        }

        static void DeleteTask()
        {
            ShowAllTasks();
            Console.Write("Введите ID задачи для удаления: ");
            int id = int.Parse(Console.ReadLine());

            dbManager.DeleteTask(id);
            Console.WriteLine("Задача удалена!");
        }

        static void AssignTaskToEmployee()
        {
            ShowAllTasks();
            ShowAllEmployees();

            Console.Write("Введите ID задачи: ");
            int taskId = int.Parse(Console.ReadLine());
            Console.Write("Введите ID сотрудника: ");
            int employeeId = int.Parse(Console.ReadLine());

            dbManager.AssignTaskToEmployee(taskId, employeeId);
            Console.WriteLine("Задача назначена сотруднику!");
        }

        static void UpdateTaskProgress()
        {
            ShowAllTasks();
            Console.Write("Введите ID задачи: ");
            int taskId = int.Parse(Console.ReadLine());
            Console.Write("Новый прогресс (0-100): ");
            int progress = int.Parse(Console.ReadLine());
            Console.Write("Новый статус (1-Новая, 2-В работе, 3-Завершена): ");
            int status = int.Parse(Console.ReadLine());

            dbManager.UpdateTaskProgress(taskId, progress, status);
            Console.WriteLine("Прогресс задачи обновлен!");
        }

        // Методы для отчетов
        static void GenerateProjectReport()
        {
            List<ProjectReport> report = dbManager.GetProjectReport();
            Console.WriteLine("\n=== Отчет по проектам ===");
            foreach (ProjectReport item in report)
            {
                Console.WriteLine($"Проект: {item.ProjectName}");
                Console.WriteLine($"Всего задач: {item.TotalTasks}");
                Console.WriteLine($"Завершено: {item.CompletedTasks}");
                Console.WriteLine($"Прогресс: {item.CompletionPercentage}%");
                Console.WriteLine("---");
            }
        }

        static void GenerateTaskReport()
        {
            List<TaskReport> report = dbManager.GetTaskReport();
            Console.WriteLine("\n=== Отчет по задачам ===");
            foreach (TaskReport item in report)
            {
                string status = GetStatusText(item.Status);
                Console.WriteLine($"Задача: {item.TaskTitle}");
                Console.WriteLine($"Проект: {item.ProjectName}");
                Console.WriteLine($"Статус: {status}");
                Console.WriteLine($"Прогресс: {item.Progress}%");
                Console.WriteLine($"Назначена: {item.AssignedEmployee}");
                Console.WriteLine("---");
            }
        }

        static void GenerateEmployeeReport()
        {
            List<EmployeeReport> report = dbManager.GetEmployeeReport();
            Console.WriteLine("\n=== Отчет по сотрудникам ===");
            foreach (EmployeeReport item in report)
            {
                Console.WriteLine($"Сотрудник: {item.EmployeeName}");
                Console.WriteLine($"Должность: {item.Position}");
                Console.WriteLine($"Всего задач: {item.TotalTasks}");
                Console.WriteLine($"Завершено: {item.CompletedTasks}");
                Console.WriteLine("---");
            }
        }

        static string GetStatusText(int status)
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
}