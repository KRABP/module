using System;
using System.Linq;

class Program
{
    static void Main()
    {
        double[] array = GenerateRandomArray(10, -10, 10);

        Console.WriteLine("\n Исходный массив:");
        PrintArray(array);

        int[] sortedIndices = GetSortedIndices(array);

        Console.WriteLine("\n Отсортированные индексы по возрастанию зна-чений:");
        PrintSortedResults(array, sortedIndices);

    }

    static double[] GenerateRandomArray(int size, double min, double max)
    {
        Random random = new Random();
        double[] array = new double[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = min + (random.NextDouble() * (max - min));
        }

        return array;
    }

    static int[] GetSortedIndices(double[] array)
    {
        int[] indices = new int[array.Length];
        for (int i = 0; i < indices.Length; i++)
        {
            indices[i] = i;
        }

        Array.Sort(indices, (a, b) => array[a].CompareTo(array[b]));

        return indices;
    }

    static void PrintArray(double[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"[{i,2}] = {array[i],8:F3}");
        }
    }

    static void PrintSortedResults(double[] array, int[] sortedIndices)
    {
        Console.WriteLine("Индекс |  Значение");
        Console.WriteLine("-------------------");

        foreach (int index in sortedIndices)
        {
            Console.WriteLine($"{index,6} | {array[index],8:F3}");
        }
    }
}
