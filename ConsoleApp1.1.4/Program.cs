using System;
using System.Linq;

class Program
{
    static void Main()
    {

        int[] numbers = GenerateRandomArray(15, -100, 100);

        PrintArray("Сгенерированный массив", numbers);

        int[] positiveNumbers = numbers.Where(n => n > 0).ToArray();

        PrintArray("Положительные числа", positiveNumbers);

        if (positiveNumbers.Length > 0)
        {
            double average = positiveNumbers.Average();
            Console.WriteLine($"\n Результаты:");
            Console.WriteLine($"Количество положительных чисел: {positiveNumbers.Length}");
            Console.WriteLine($"Сумма положительных чисел: {positiveNumbers.Sum()}");
            Console.WriteLine($"Среднее значение: {average:F2}");
        }
        else
        {
            Console.WriteLine("\n В массиве нет положительных чисел!");
        }
    }

    static int[] GenerateRandomArray(int size, int minValue, int maxValue)
    {
        Random random = new Random();
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(minValue, maxValue + 1);
        }

        return array;
    }

    static void PrintArray(string title, int[] array)
    {
        Console.WriteLine($"\n{title}:");
        Console.WriteLine(string.Join(", ", array));
    }
}
