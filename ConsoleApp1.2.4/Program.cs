using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int k = GetPositiveInteger("Введите размер массива K: ");
        int a = GetInteger("Введите начало диапазона A: ");
        int b = GetInteger("Введите конец диапазона B: ");

        if (b <= a)
        {
            Console.WriteLine("Ошибка: B должно быть больше A!");
            return;
        }
        int[] array = GenerateRandomArray(k, a, b);
        Console.WriteLine("\n Исходный массив:");
        PrintArray(array);
        int minIndex = FindMinIndex(array);
        int maxIndex = FindMaxIndex(array);

        Console.WriteLine($"\n Минимальный элемент: array[{minIndex}] = {array[minIndex]}");
        Console.WriteLine($" Максимальный элемент: array[{maxIndex}] = {array[maxIndex]}");

        PrintElementsBetween(array, minIndex, maxIndex);
    }

    static int GetPositiveInteger(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                return n;
            Console.WriteLine(" Ошибка: введите целое положительное чис-ло!");
        }
    }
    static int GetInteger(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int n))
                return n;
            Console.WriteLine(" Ошибка: введите целое число!");
        }
    }

    static int[] GenerateRandomArray(int size, int min, int max)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(min, max);
        }
        return array;
    }
    static int FindMinIndex(int[] array)
    {
        int minIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[minIndex])
                minIndex = i;
        }
        return minIndex;
    }
    static int FindMaxIndex(int[] array)
    {
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex])
                maxIndex = i;
        }
        return maxIndex;
    }
    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"[{i,2}] = {array[i],4}");
        }
    }
    static void PrintElementsBetween(int[] array, int index1, int index2)
    {
        int start = Math.Min(index1, index2);
        int end = Math.Max(index1, index2);
        Console.WriteLine($"\n Элементы между индексами {start} и {end}:");
        for (int i = start; i <= end; i++)
        {
            Console.WriteLine($"[{i,2}] = {array[i],4}");
        }
        Console.WriteLine($"\n Количество элементов: {end - start + 1}");
        Console.WriteLine($" Диапазон значений: от {array[start]} до {array[end]}");
    }
}
