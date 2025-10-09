using System;

public abstract class Shape
{
    public abstract double CalculateArea();
}

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
}

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
}

public class Triangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public Triangle(double @base, double height)
    {
        Base = @base;
        Height = height;
    }

    public override double CalculateArea()
    {
        return 0.5 * Base * Height;
    }
}

class Program
{
    // Делегат для вычисления площади
    public delegate double AreaCalculator();

    static void Main(string[] args)
    {
        // Создание объектов фигур
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(4, 6);
        Shape triangle = new Triangle(3, 4);

        // Создание делегатов для каждой фигуры
        AreaCalculator circleArea = circle.CalculateArea;
        AreaCalculator rectangleArea = rectangle.CalculateArea;
        AreaCalculator triangleArea = triangle.CalculateArea;

        // Динамический вызов методов через делегаты
        Console.WriteLine("Площади фигур (через делегаты):");
        Console.WriteLine($"Круг: {circleArea():F2}");
        Console.WriteLine($"Прямоугольник: {rectangleArea():F2}");
        Console.WriteLine($"Треугольник: {triangleArea():F2}");

        Console.WriteLine();

        // Использование массива делегатов
        AreaCalculator[] calculators = new AreaCalculator[]
        {
            circleArea,
            rectangleArea,
            triangleArea
        };

        Console.WriteLine("Площади фигур (через массив делегатов):");
        for (int i = 0; i < calculators.Length; i++)
        {
            Console.WriteLine($"Фигура {i + 1}: {calculators[i]():F2}");
        }
    }
}