using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n;
        while (true)
        {
            Console.Write("Введите размер массива N: ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
            {
                break;
            }
            Console.WriteLine("Ошибка: введите целое положительное чис-ло!");
        }
        double[] array = new double[n];
        Console.WriteLine($"Введите {n} элементов массива:");

        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"Элемент [{i}]: ");
                if (double.TryParse(Console.ReadLine(), out array[i]))
                {
                    break;
                }
                Console.WriteLine("Ошибка: введите число!");
            }
        }
        Console.WriteLine("\nИсходный массив:");
        PrintArray(array);
        double[] normalizedArray = NormalizeArray(array);
        Console.WriteLine("\nНормированный массив:");
        PrintArray(normalizedArray);
        Console.WriteLine($"\nМаксимальный по модулю элемент: {FindMaxAbsolute(array)}");
    }
    static double[] NormalizeArray(double[] array)
    {
        double maxAbsolute = FindMaxAbsolute(array);
        if (maxAbsolute == 0)
            return (double[])array.Clone();

        double[] result = new double[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = array[i] / maxAbsolute;
        }
        return result;
    }
    static double FindMaxAbsolute(double[] array)
    {
        double max = 0;
        foreach (double element in array)
        {
            double absolute = Math.Abs(element);
            if (absolute > max)
                max = absolute;
        }
        return max;
    }
    static void PrintArray(double[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"[{i}] = {array[i]:F6}");
        }
    }
}
