using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

class Program
{
    static void Main()
    {
        int targetSum = GetPositiveInteger("Введите максимальную сумму элементов: ");

        var result = GenerateArrayWithSumLimit(targetSum);
        int[] array = result.Item1;
        int actualSum = result.Item2;
        int count = result.Item3;

        Console.WriteLine("\nРезультат:");
        Console.WriteLine("Количество элементов: " + count);
        Console.WriteLine("Сумма элементов: " + actualSum);
        Console.WriteLine("Целевая сумма: " + targetSum);
        Console.WriteLine("Разница: " + (targetSum - actualSum));

        PrintArray(array, count);
    }

    static Tuple<int[], int, int> GenerateArrayWithSumLimit(int targetSum)
    {
        Random random = new Random();
        List<int> elements = new List<int>();
        int currentSum = 0;
        int count = 0;

        while (currentSum < targetSum)
        {
            int randomValue = random.Next(1, 10);
            int potentialSum = currentSum + randomValue;

            if (potentialSum > targetSum)
                break;

            elements.Add(randomValue);
            currentSum = potentialSum;
            count++;
        }

        return Tuple.Create(elements.ToArray(), currentSum, count);
    }

    static void PrintArray(int[] array, int count)
    {
        Console.WriteLine("\nМассив элементов:");
        for (int i = 0; i < count; i++)
        {
            Console.Write(array[i] + " ");
            if ((i + 1) % 15 == 0)
                Console.WriteLine();
        }
        Console.WriteLine();

        var subArray = new List<int>();
        for (int i = 0; i < count; i++)
        {
            subArray.Add(array[i]);
        }
        Console.Write("Сумма: " + string.Join(" + ", subArray) + " = " + subArray.Sum());
        Console.WriteLine();
    }



    static int GetPositiveInteger(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
                return number;
            Console.WriteLine("Ошибка: введите положительное целое число!");
        }
    }
}
