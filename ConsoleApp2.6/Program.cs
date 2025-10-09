using System;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public double AverageGrade { get; set; }

    // Конструктор
    public Student(string firstName, string lastName, int age, double averageGrade)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        AverageGrade = averageGrade;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Студент: {FirstName} {LastName}");
        Console.WriteLine($"Возраст: {Age} лет");
        Console.WriteLine($"Средний балл: {AverageGrade:F2}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("Иван", "Петров", 20, 4.5);
        Student student2 = new Student("Мария", "Сидорова", 19, 4.8);
        Student student3 = new Student("Алексей", "Иванов", 21, 3.9);

        student1.DisplayInfo();
        student2.DisplayInfo();
        student3.DisplayInfo();
    }
}