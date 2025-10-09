using System;
using System.Collections.Generic;


public interface IDrawable
{
    void Draw(); 
}

public abstract class Shape
{
    public string Name { get; protected set; }
    public string Color { get; set; }

    protected Shape(string name, string color = "Black")
    {
        Name = name;
        Color = color;
    }

    // Абстрактный метод для вычисления площади
    public abstract double CalculateArea();

    // Виртуальный метод для вывода общей информации
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Фигура: {Name}");
        Console.WriteLine($"Цвет: {Color}");
        Console.WriteLine($"Площадь: {CalculateArea():F2}");
    }
}

// Класс Circle 
public class Circle : Shape, IDrawable
{
    public double Radius { get; private set; }

    public Circle(double radius, string color = "Red") : base("Круг", color)
    {
        if (radius <= 0)
            throw new ArgumentException("Радиус должен быть положительным числом");
        Radius = radius;
    }

    // Реализация метода из интерфейса IDrawable
    public void Draw()
    {
        Console.WriteLine("Отрисовка круга:");
        DisplayInfo();
        Console.WriteLine($"Радиус: {Radius:F2}");
        Console.WriteLine("   ***   ");
        Console.WriteLine(" *     * ");
        Console.WriteLine("*       *");
        Console.WriteLine(" *     * ");
        Console.WriteLine("   ***   ");
        Console.WriteLine();
    }

    // Реализация абстрактного метода из Shape
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

// Класс Rectangle (Прямоугольник)
public class Rectangle : Shape, IDrawable
{
    public double Width { get; private set; }
    public double Height { get; private set; }

    public Rectangle(double width, double height, string color = "Blue") 
        : base("Прямоугольник", color)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Ширина и высота должны быть положительными числами");
        Width = width;
        Height = height;
    }

    // Реализация метода из интерфейса IDrawable
    public void Draw()
    {
        Console.WriteLine("Отрисовка прямоугольника:");
        DisplayInfo();
        Console.WriteLine($"Ширина: {Width:F2}, Высота: {Height:F2}");
        Console.WriteLine("+-------+");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("|       |");
        }
        Console.WriteLine("+-------+");
        Console.WriteLine();
    }

    // Реализация абстрактного метода из Shape
    public override double CalculateArea()
    {
        return Width * Height;
    }

    // Переопределение метода DisplayInfo
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        if (Width == Height)
            Console.WriteLine("Это квадрат!");
    }
}

// Класс Triangle (Треугольник)
public class Triangle : Shape, IDrawable
{
    public double SideA { get; private set; }
    public double SideB { get; private set; }
    public double SideC { get; private set; }

    public Triangle(double sideA, double sideB, double sideC, string color = "Green") 
        : base("Треугольник", color)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new ArgumentException("Все стороны должны быть положительными числами");
        
        // Проверка неравенства треугольника
        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            throw new ArgumentException("Некорректные стороны треугольника");

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    // Реализация метода из интерфейса IDrawable
    public void Draw()
    {
        Console.WriteLine("Отрисовка треугольника:");
        DisplayInfo();
        Console.WriteLine($"Стороны: {SideA:F2}, {SideB:F2}, {SideC:F2}");
        Console.WriteLine($"Тип: {GetTriangleType()}");
        Console.WriteLine("    /\\    ");
        Console.WriteLine("   /  \\   ");
        Console.WriteLine("  /    \\  ");
        Console.WriteLine(" /______\\ ");
        Console.WriteLine();
    }

    // Реализация абстрактного метода из Shape
    public override double CalculateArea()
    {
        // Формула Герона
        double p = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }

    // Метод для определения типа треугольника
    private string GetTriangleType()
    {
        if (SideA == SideB && SideB == SideC)
            return "Равносторонний";
        else if (SideA == SideB || SideA == SideC || SideB == SideC)
            return "Равнобедренный";
        else
            return "Разносторонний";
    }
}

// Дополнительный класс Star (Звезда), реализующий только IDrawable
public class Star : IDrawable
{
    public string Color { get; set; }
    public int Points { get; set; }

    public Star(string color = "Yellow", int points = 5)
    {
        Color = color;
        Points = points;
    }

    // Реализация метода из интерфейса IDrawable
    public void Draw()
    {
        Console.WriteLine("Отрисовка звезды:");
        Console.WriteLine($"Цвет: {Color}");
        Console.WriteLine($"Количество лучей: {Points}");
        Console.WriteLine("    *    ");
        Console.WriteLine(" *     * ");
        Console.WriteLine("    *    ");
        Console.WriteLine(" *     * ");
        Console.WriteLine("    *    ");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Демонстрация интерфейсов и абстрактных классов");
            Console.WriteLine("==============================================\n");

            // Создание массива объектов, реализующих интерфейс IDrawable
            IDrawable[] drawableObjects = new IDrawable[]
            {
                new Circle(5.0, "Red"),
                new Rectangle(4.0, 6.0, "Blue"),
                new Triangle(3.0, 4.0, 5.0, "Green"),
                new Rectangle(5.0, 5.0, "Purple"), // Квадрат
                new Circle(3.5, "Orange"),
                new Triangle(6.0, 6.0, 6.0, "Pink"), // Равносторонний треугольник
                new Star("Gold", 5),
                new Star("Silver", 6)
            };

            // Вызов метода Draw() для каждого объекта
            Console.WriteLine("Отрисовка всех объектов:");
            Console.WriteLine("=======================\n");

            for (int i = 0; i < drawableObjects.Length; i++)
            {
                Console.WriteLine($"Объект #{i + 1}:");
                drawableObjects[i].Draw();
                Console.WriteLine(new string('-', 40));
            }

            // Демонстрация полиморфизма
            Console.WriteLine("\nДемонстрация полиморфизма:");
            Console.WriteLine("==========================\n");

            // Группировка по типам
            var circles = new List<IDrawable>();
            var rectangles = new List<IDrawable>();
            var triangles = new List<IDrawable>();
            var stars = new List<IDrawable>();

            foreach (var obj in drawableObjects)
            {
                if (obj is Circle)
                    circles.Add(obj);
                else if (obj is Rectangle)
                    rectangles.Add(obj);
                else if (obj is Triangle)
                    triangles.Add(obj);
                else if (obj is Star)
                    stars.Add(obj);
            }

            Console.WriteLine($"Кругов: {circles.Count}");
            Console.WriteLine($"Прямоугольников: {rectangles.Count}");
            Console.WriteLine($"Треугольников: {triangles.Count}");
            Console.WriteLine($"Звезд: {stars.Count}");

            // Отрисовка по группам
            Console.WriteLine("\nОтрисовка кругов:");
            foreach (var circle in circles)
            {
                circle.Draw();
            }

            Console.WriteLine("Отрисовка прямоугольников:");
            foreach (var rectangle in rectangles)
            {
                rectangle.Draw();
            }

            // Создание списка только фигур (наследников Shape)
            Console.WriteLine("\nТолько геометрические фигуры:");
            Console.WriteLine("============================\n");

            List<Shape> shapes = new List<Shape>();
            foreach (var obj in drawableObjects)
            {
                Shape shape = obj as Shape;
                if (shape != null)
                {
                    shapes.Add(shape);
                }
            }

            double totalArea = 0;
            foreach (var shape in shapes)
            {
                shape.DisplayInfo();
                totalArea += shape.CalculateArea();
                Console.WriteLine();
            }

            Console.WriteLine($"Общая площадь всех фигур: {totalArea:F2}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.ReadLine();
    }
}