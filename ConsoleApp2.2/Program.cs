using System;


public abstract class Shape
{

    public abstract double Area();
    public abstract double Perimeter();


    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Площадь: {Area():F2}");
        Console.WriteLine($"Периметр: {Perimeter():F2}");
    }
}

// Производный класс Circle (круг)
public class Circle : Shape
{
    public double Radius { get; set; }

    // Конструктор
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Радиус должен быть положительным числом");
        Radius = radius;
    }

    // Переопределение метода Area для круга
    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    // Переопределение метода Perimeter для круга
    public override double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }

    // Переопределение метода DisplayInfo
    public override void DisplayInfo()
    {
        Console.WriteLine($"Круг с радиусом {Radius:F2}");
        base.DisplayInfo();
        Console.WriteLine();
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    // Конструктор
    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Ширина и высота должны быть положительными числами");
        Width = width;
        Height = height;
    }

    // Переопределение метода Area для прямоугольника
    public override double Area()
    {
        return Width * Height;
    }

    // Переопределение метода Perimeter для прямоугольника
    public override double Perimeter()
    {
        return 2 * (Width + Height);
    }

    // Переопределение метода DisplayInfo
    public override void DisplayInfo()
    {
        Console.WriteLine($"Прямоугольник {Width:F2} x {Height:F2}");
        base.DisplayInfo();
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {


            // Круги
            Circle circle1 = new Circle(5.0);
            Circle circle2 = new Circle(3.5);

            // Прямоугольники
            Rectangle rectangle1 = new Rectangle(4.0, 6.0);
            Rectangle rectangle2 = new Rectangle(2.5, 8.0);
            Rectangle square = new Rectangle(5.0, 5.0); // Квадрат

            // Вывод информации о фигурах
            Console.WriteLine("Информация о фигурах:");
            Console.WriteLine("---------------------");

            circle1.DisplayInfo();
            circle2.DisplayInfo();
            rectangle1.DisplayInfo();
            rectangle2.DisplayInfo();
            square.DisplayInfo();


            Shape[] shapes = new Shape[]
            {
                new Circle(7.0),
                new Rectangle(3.0, 4.0),
                new Circle(2.0),
                new Rectangle(6.0, 8.0)
            };

            double totalArea = 0;
            double totalPerimeter = 0;

            foreach (Shape shape in shapes)
            {
                shape.DisplayInfo();
                totalArea += shape.Area();
                totalPerimeter += shape.Perimeter();
            }

            Console.WriteLine($"Общая площадь всех фигур: {totalArea:F2}");
            Console.WriteLine($"Общий периметр всех фигур: {totalPerimeter:F2}");


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.ReadLine();
    }
}