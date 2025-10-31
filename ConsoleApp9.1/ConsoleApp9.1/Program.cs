using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp9._1
{
    class Program
    {
        private static List<Student> students = new List<Student>();
        private const string DataFile = "students.txt";

        static void Main(string[] args)
        {
            LoadStudents();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Управление списком студентов ===");
                Console.WriteLine("1. Показать всех студентов");
                Console.WriteLine("2. Добавить студента");
                Console.WriteLine("3. Редактировать студента");
                Console.WriteLine("4. Удалить студента");
                Console.WriteLine("5. Поиск студентов");
                Console.WriteLine("6. Сортировка студентов");
                Console.WriteLine("7. Сохранить и выйти");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllStudents();
                        break;
                    case "2":
                        AddStudent();
                        break;
                    case "3":
                        EditStudent();
                        break;
                    case "4":
                        DeleteStudent();
                        break;
                    case "5":
                        SearchStudents();
                        break;
                    case "6":
                        SortStudents();
                        break;
                    case "7":
                        SaveStudents();
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        static void ShowAllStudents()
        {
            Console.WriteLine("\n=== Список всех студентов ===");
            if (students.Count == 0)
            {
                Console.WriteLine("Студентов нет.");
                return;
            }

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i]}");
            }
        }

        static void AddStudent()
        {
            Console.WriteLine("\n=== Добавление студента ===");

            Console.Write("Имя: ");
            string name = Console.ReadLine();

            Console.Write("Фамилия: ");
            string surname = Console.ReadLine();

            Console.Write("Возраст: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Неверный формат возраста!");
                return;
            }

            Console.Write("Группа: ");
            string group = Console.ReadLine();

            Console.Write("Средний балл: ");
            if (!double.TryParse(Console.ReadLine(), out double averageGrade))
            {
                Console.WriteLine("Неверный формат среднего балла!");
                return;
            }

            Student student = new Student(name, surname, age, group, averageGrade);
            students.Add(student);
            Console.WriteLine("Студент успешно добавлен!");
        }

        static void EditStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Студентов для редактирования нет.");
                return;
            }

            ShowAllStudents();
            Console.Write("\nВведите номер студента для редактирования: ");

            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > students.Count)
            {
                Console.WriteLine("Неверный номер!");
                return;
            }

            Student student = students[index - 1];

            Console.WriteLine($"Редактирование: {student}");
            Console.WriteLine("Оставьте поле пустым, чтобы не изменять значение:");

            Console.Write($"Имя [{student.Name}]: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                student.Name = name;

            Console.Write($"Фамилия [{student.Surname}]: ");
            string surname = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(surname))
                student.Surname = surname;

            Console.Write($"Возраст [{student.Age}]: ");
            string ageInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ageInput) && int.TryParse(ageInput, out int age))
                student.Age = age;

            Console.Write($"Группа [{student.Group}]: ");
            string group = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(group))
                student.Group = group;

            Console.Write($"Средний балл [{student.AverageGrade}]: ");
            string gradeInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(gradeInput) && double.TryParse(gradeInput, out double grade))
                student.AverageGrade = grade;

            Console.WriteLine("Данные студента обновлены!");
        }

        static void DeleteStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Студентов для удаления нет.");
                return;
            }

            ShowAllStudents();
            Console.Write("\nВведите номер студента для удаления: ");

            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > students.Count)
            {
                Console.WriteLine("Неверный номер!");
                return;
            }

            Student student = students[index - 1];
            students.RemoveAt(index - 1);
            Console.WriteLine($"Студент {student} удален!");
        }

        static void SearchStudents()
        {
            Console.WriteLine("\n=== Поиск студентов ===");
            Console.WriteLine("1. По имени");
            Console.WriteLine("2. По фамилии");
            Console.WriteLine("3. По группе");
            Console.Write("Выберите критерий поиска: ");

            string choice = Console.ReadLine();
            Console.Write("Введите поисковый запрос: ");
            string query = Console.ReadLine().ToLower();

            IEnumerable<Student> results;

            switch (choice)
            {
                case "1":
                    results = students.Where(s => s.Name.ToLower().Contains(query));
                    break;
                case "2":
                    results = students.Where(s => s.Surname.ToLower().Contains(query));
                    break;
                case "3":
                    results = students.Where(s => s.Group.ToLower().Contains(query));
                    break;
                default:
                    results = Enumerable.Empty<Student>();
                    break;
            }

            List<Student> resultList = results.ToList();
            if (resultList.Count == 0)
            {
                Console.WriteLine("Студенты не найдены.");
                return;
            }

            Console.WriteLine("\nРезультаты поиска:");
            foreach (Student student in resultList)
            {
                Console.WriteLine(student);
            }
        }

        static void SortStudents()
        {
            Console.WriteLine("\n=== Сортировка студентов ===");
            Console.WriteLine("1. По имени");
            Console.WriteLine("2. По фамилии");
            Console.WriteLine("3. По возрасту");
            Console.WriteLine("4. По группе");
            Console.WriteLine("5. По среднему баллу");
            Console.Write("Выберите критерий сортировки: ");

            string choice = Console.ReadLine();
            IEnumerable<Student> sortedStudents;

            switch (choice)
            {
                case "1":
                    sortedStudents = students.OrderBy(s => s.Name);
                    break;
                case "2":
                    sortedStudents = students.OrderBy(s => s.Surname);
                    break;
                case "3":
                    sortedStudents = students.OrderBy(s => s.Age);
                    break;
                case "4":
                    sortedStudents = students.OrderBy(s => s.Group);
                    break;
                case "5":
                    sortedStudents = students.OrderBy(s => s.AverageGrade);
                    break;
                default:
                    sortedStudents = students.OrderBy(s => s.Name);
                    break;
            }

            students = sortedStudents.ToList();
            Console.WriteLine("Список отсортирован!");
            ShowAllStudents();
        }

        static void LoadStudents()
        {
            if (File.Exists(DataFile))
            {
                try
                {
                    string[] lines = File.ReadAllLines(DataFile);
                    students.Clear();

                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] parts = line.Split('|');
                        if (parts.Length == 5)
                        {
                            Student student = new Student(
                                parts[0],
                                parts[1],
                                int.Parse(parts[2]),
                                parts[3],
                                double.Parse(parts[4])
                            );
                            students.Add(student);
                        }
                    }
                    Console.WriteLine("Данные загружены успешно!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка загрузки: {ex.Message}");
                }
            }
        }

        static void SaveStudents()
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (Student student in students)
                {
                    string line = $"{student.Name}|{student.Surname}|{student.Age}|{student.Group}|{student.AverageGrade}";
                    lines.Add(line);
                }
                File.WriteAllLines(DataFile, lines);
                Console.WriteLine("Данные сохранены успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
            }
        }
    }
}