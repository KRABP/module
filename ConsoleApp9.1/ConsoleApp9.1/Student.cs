using System;

namespace ConsoleApp9._1
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public double AverageGrade { get; set; }

        public Student(string name, string surname, int age, string group, double averageGrade)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Group = group;
            AverageGrade = averageGrade;
        }

        public override string ToString()
        {
            return $"{Surname} {Name}, {Age} лет, группа {Group}, средний балл: {AverageGrade:F2}";
        }
    }
}