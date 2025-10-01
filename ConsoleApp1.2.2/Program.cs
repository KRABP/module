using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] array = { 15, 7, 23, 9, 42, 18, 31, 5, 27, 12 };

        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        int maxValue = array.Max();
        int maxIndex = Array.IndexOf(array, maxValue);

        Console.WriteLine($"\nМаксимальный элемент: array[{maxIndex}] = {maxValue}");

        int newNumber;
        while (true)
        {
            Console.Write("\nВведите целое число для замены: ");
            if (int.TryParse(Console.ReadLine(), out newNumber))
            {
                break;
            }
            Console.WriteLine("Ошибка: введите целое число!");
        }

        array[maxIndex] = newNumber;

        Console.WriteLine("\nИзмененный массив:");
        PrintArray(array);

        Console.WriteLine($"\nМаксимальный элемент заменен на: {newNumber}");
    }

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"[{i}] = {array[i]}");
        }
    }
}
