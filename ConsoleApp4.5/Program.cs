using System;

// Интерфейс Рисунок
public interface IDrawing
{
    void DrawLine(int x1, int y1, int x2, int y2);
    void DrawCircle(int x, int y, int radius);
    void DrawRectangle(int x, int y, int width, int height);
}

// Класс Canvas (Холст)
public class Canvas : IDrawing
{
    private int width;
    private int height;
    private char[,] canvas;

    public Canvas(int width, int height)
    {
        this.width = width;
        this.height = height;
        canvas = new char[height, width];
        ClearCanvas();
    }

    private void ClearCanvas()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                canvas[y, x] = ' ';
            }
        }
    }

    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        Console.WriteLine($"Рисую линию от ({x1},{y1}) до ({x2},{y2})");

        // Простой алгоритм Брезенхема для горизонтальных и вертикальных линий
        if (x1 == x2)
        {
            // Вертикальная линия
            int startY = Math.Min(y1, y2);
            int endY = Math.Max(y1, y2);
            for (int y = startY; y <= endY; y++)
            {
                if (IsInBounds(x1, y))
                    canvas[y, x1] = '|';
            }
        }
        else if (y1 == y2)
        {
            // Горизонтальная линия
            int startX = Math.Min(x1, x2);
            int endX = Math.Max(x1, x2);
            for (int x = startX; x <= endX; x++)
            {
                if (IsInBounds(x, y1))
                    canvas[y1, x] = '-';
            }
        }
    }

    public void DrawCircle(int x, int y, int radius)
    {
        Console.WriteLine($"Рисую круг в точке ({x},{y}) с радиусом {radius}");

        // Простая реализация окружности
        for (int angle = 0; angle < 360; angle++)
        {
            double rad = angle * Math.PI / 180;
            int px = (int)(x + radius * Math.Cos(rad));
            int py = (int)(y + radius * Math.Sin(rad));

            if (IsInBounds(px, py))
                canvas[py, px] = '*';
        }
    }

    public void DrawRectangle(int x, int y, int width, int height)
    {
        Console.WriteLine($"Рисую прямоугольник в точке ({x},{y}) размером {width}x{height}");

        // Верхняя и нижняя стороны
        for (int i = x; i < x + width; i++)
        {
            if (IsInBounds(i, y))
                canvas[y, i] = '-';
            if (IsInBounds(i, y + height - 1))
                canvas[y + height - 1, i] = '-';
        }

        // Левая и правая стороны
        for (int i = y; i < y + height; i++)
        {
            if (IsInBounds(x, i))
                canvas[i, x] = '|';
            if (IsInBounds(x + width - 1, i))
                canvas[i, x + width - 1] = '|';
        }

        // Углы
        if (IsInBounds(x, y))
            canvas[y, x] = '+';
        if (IsInBounds(x + width - 1, y))
            canvas[y, x + width - 1] = '+';
        if (IsInBounds(x, y + height - 1))
            canvas[y + height - 1, x] = '+';
        if (IsInBounds(x + width - 1, y + height - 1))
            canvas[y + height - 1, x + width - 1] = '+';
    }

    private bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    public void Display()
    {
        Console.WriteLine("Холст:");
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(canvas[y, x]);
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание холста
        Canvas canvas = new Canvas(30, 15);
        IDrawing drawing = canvas;

        // Рисование различных фигур
        drawing.DrawLine(5, 5, 25, 5);
        drawing.DrawLine(5, 5, 5, 12);

        drawing.DrawCircle(15, 7, 4);

        drawing.DrawRectangle(20, 2, 8, 6);
        drawing.DrawRectangle(2, 8, 10, 4);

        // Отображение холста
        canvas.Display();
    }
}