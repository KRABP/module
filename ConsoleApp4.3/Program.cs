using System;
using System.Collections.Generic;

// Интерфейс Студент
public interface IStudent
{
    string Name { get; set; }
    string Specialty { get; set; }
    double CalculateAverageGrade();
    string GetCourseInfo();
    void DisplayInfo();
}

// Класс FirstYearStudent (Студент 1 курса)
public class FirstYearStudent : IStudent
{
    public string Name { get; set; }
    public string Specialty { get; set; }
    public List<double> Grades { get; set; }

    public FirstYearStudent(string name, string specialty)
    {
        Name = name;
        Specialty = specialty;
        Grades = new List<double>();
    }

    public void AddGrade(double grade)
    {
        Grades.Add(grade);
    }

    public double CalculateAverageGrade()
    {
        if (Grades.Count == 0) return 0;

        double sum = 0;
        foreach (var grade in Grades)
        {
            sum += grade;
        }
        return sum / Grades.Count;
    }

    public string GetCourseInfo()
    {
        return "1 курс - базовые дисциплины";
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Студент 1 курса: {Name}");
        Console.WriteLine($"Специальность: {Specialty}");
        Console.WriteLine($"Средний балл: {CalculateAverageGrade():F2}");
        Console.WriteLine($"Курс: {GetCourseInfo()}");
        Console.WriteLine($"Оценки: {string.Join(", ", Grades)}");
        Console.WriteLine();
    }
}

// Класс SecondYearStudent (Студент 2 курса)
public class SecondYearStudent : IStudent
{
    public string Name { get; set; }
    public string Specialty { get; set; }
    public List<double> Grades { get; set; }
    public string PracticeCompany { get; set; }

    public SecondYearStudent(string name, string specialty, string practiceCompany = "")
    {
        Name = name;
        Specialty = specialty;
        PracticeCompany = practiceCompany;
        Grades = new List<double>();
    }

    public void AddGrade(double grade)
    {
        Grades.Add(grade);
    }

    public double CalculateAverageGrade()
    {
        if (Grades.Count == 0) return 0;

        double sum = 0;
        foreach (var grade in Grades)
        {
            sum += grade;
        }
        return sum / Grades.Count;
    }

    public string GetCourseInfo()
    {
        string practiceInfo = string.IsNullOrEmpty(PracticeCompany) ?
            "практика не назначена" : $"практика в {PracticeCompany}";
        return $"2 курс - профильные дисциплины, {practiceInfo}";
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Студент 2 курса: {Name}");
        Console.WriteLine($"Специальность: {Specialty}");
        Console.WriteLine($"Средний балл: {CalculateAverageGrade():F2}");
        Console.WriteLine($"Курс: {GetCourseInfo()}");
        Console.WriteLine($"Оценки: {string.Join(", ", Grades)}");
        Console.WriteLine();
    }
}

// Класс ThirdYearStudent (Студент 3 курса)
public class ThirdYearStudent : IStudent
{
    public string Name { get; set; }
    public string Specialty { get; set; }
    public List<double> Grades { get; set; }
    public string DiplomaTopic { get; set; }

    public ThirdYearStudent(string name, string specialty, string diplomaTopic = "")
    {
        Name = name;
        Specialty = specialty;
        DiplomaTopic = diplomaTopic;
        Grades = new List<double>();
    }

    public void AddGrade(double grade)
    {
        Grades.Add(grade);
    }

    public double CalculateAverageGrade()
    {
        if (Grades.Count == 0) return 0;

        double sum = 0;
        foreach (var grade in Grades)
        {
            sum += grade;
        }
        return sum / Grades.Count;
    }

    public string GetCourseInfo()
    {
        string diplomaInfo = string.IsNullOrEmpty(DiplomaTopic) ?
            "тема диплома не выбрана" : $"тема диплома: {DiplomaTopic}";
        return $"3 курс - углубленная специализация, {diplomaInfo}";
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Студент 3 курса: {Name}");
        Console.WriteLine($"Специальность: {Specialty}");
        Console.WriteLine($"Средний балл: {CalculateAverageGrade():F2}");
        Console.WriteLine($"Курс: {GetCourseInfo()}");
        Console.WriteLine($"Оценки: {string.Join(", ", Grades)}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание списка студентов
        List<IStudent> students = new List<IStudent>
        {
            new FirstYearStudent("Иван Петров", "Информатика"),
            new FirstYearStudent("Мария Сидорова", "Математика"),
            new SecondYearStudent("Алексей Иванов", "Физика", "НИИ Физики"),
            new SecondYearStudent("Елена Козлова", "Химия"),
            new ThirdYearStudent("Дмитрий Смирнов", "Программирование", "Разработка AI-систем"),
            new ThirdYearStudent("Ольга Новикова", "Биология", "Исследование ДНК")
        };

        // Добавление оценок студентам
        ((FirstYearStudent)students[0]).AddGrade(4.5);
        ((FirstYearStudent)students[0]).AddGrade(5.0);
        ((FirstYearStudent)students[0]).AddGrade(4.0);

        ((FirstYearStudent)students[1]).AddGrade(3.5);
        ((FirstYearStudent)students[1]).AddGrade(4.0);

        ((SecondYearStudent)students[2]).AddGrade(5.0);
        ((SecondYearStudent)students[2]).AddGrade(4.5);
        ((SecondYearStudent)students[2]).AddGrade(5.0);

        ((SecondYearStudent)students[3]).AddGrade(4.0);
        ((SecondYearStudent)students[3]).AddGrade(3.0);

        ((ThirdYearStudent)students[4]).AddGrade(5.0);
        ((ThirdYearStudent)students[4]).AddGrade(5.0);
        ((ThirdYearStudent)students[4]).AddGrade(4.5);

        ((ThirdYearStudent)students[5]).AddGrade(4.0);
        ((ThirdYearStudent)students[5]).AddGrade(4.5);

        // Вывод информации о всех студентах
        Console.WriteLine("=== Система учета студентов университета ===");
        Console.WriteLine("Все студенты:");
        Console.WriteLine("==============");

        foreach (var student in students)
        {
            student.DisplayInfo();
        }

        // Средний балл по всем студентам
        double totalAverage = 0;
        foreach (var student in students)
        {
            totalAverage += student.CalculateAverageGrade();
        }
        totalAverage /= students.Count;
        Console.WriteLine($"Средний балл по всем студентам: {totalAverage:F2}");

        // Студенты с высоким средним баллом
        Console.WriteLine("\nСтуденты с высоким средним баллом (>= 4.5):");
        Console.WriteLine("===========================================");

        foreach (var student in students)
        {
            if (student.CalculateAverageGrade() >= 4.5)
            {
                student.DisplayInfo();
            }
        }

        // Поиск студента по имени
        Console.Write("\nВведите имя студента для поиска: ");
        string searchName = Console.ReadLine();

        bool found = false;
        foreach (var student in students)
        {
            if (student.Name.ToLower().Contains(searchName.ToLower()))
            {
                Console.WriteLine("Найденный студент:");
                student.DisplayInfo();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Студент не найден!");
        }
    }
}