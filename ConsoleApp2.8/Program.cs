using System;

// Базовый класс для геометрических фигур
public abstract class Shape
{
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
}

// Класс Circle (Круг)
public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

// Класс Rectangle (Прямоугольник)
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }
}

// Класс Triangle (Треугольник)
public class Triangle : Shape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public override double CalculateArea()
    {
        // Формула Герона
        double p = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }

    public override double CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание объектов различных фигур
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(4, 6);
        Shape triangle = new Triangle(3, 4, 5);

        // Вычисление и вывод площадей и периметров
        Console.WriteLine("Круг (радиус = 5):");
        Console.WriteLine($"Площадь: {circle.CalculateArea():F2}");
        Console.WriteLine($"Периметр: {circle.CalculatePerimeter():F2}");
        Console.WriteLine();

        Console.WriteLine("Прямоугольник (4 x 6):");
        Console.WriteLine($"Площадь: {rectangle.CalculateArea():F2}");
        Console.WriteLine($"Периметр: {rectangle.CalculatePerimeter():F2}");
        Console.WriteLine();

        Console.WriteLine("Треугольник (3, 4, 5):");
        Console.WriteLine($"Площадь: {triangle.CalculateArea():F2}");
        Console.WriteLine($"Периметр: {triangle.CalculatePerimeter():F2}");
    }
}