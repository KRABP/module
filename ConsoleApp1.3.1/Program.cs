using System;
using System.Runtime.ConstrainedExecution;

class Program
{
    static void Main()
    {
        int numerator = GetNonNegativeInteger("Введите неотрицательный числитель: ");
        int denominator = GetPositiveInteger("Введите положительный знаменатель: ");

        Console.WriteLine($"\nИсходная дробь: {numerator}/{denominator}");

        (int simplifiedNumerator, int simplifiedDenominator) = SimplifyFraction(numerator, denominator);

        Console.WriteLine($"Сокращенная дробь: {simplifiedNumerator}/{simplifiedDenominator}");

        if (simplifiedNumerator >= simplifiedDenominator && simplifiedDenominator != 1)
        {
            int wholePart = simplifiedNumerator / simplifiedDenominator;
            int remainder = simplifiedNumerator % simplifiedDenominator;
            if (remainder != 0)
            {
                Console.WriteLine($"В виде смешанного числа: {wholePart} {remainder}/{simplifiedDenominator}");
            }
            else
            {
                Console.WriteLine($"Целое число: {wholePart}");
            }
        }

        double decimalValue = (double)numerator / denominator;
        Console.WriteLine($"Десятичное представление: {decimalValue:F6}");
    }

    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static (int numerator, int denominator) SimplifyFraction(int numerator, int denominator)
    {
        if (numerator == 0)
            return (0, 1);

        int gcd = GCD(numerator, denominator);

        int simplifiedNumerator = numerator / gcd;
        int simplifiedDenominator = denominator / gcd;

        return (simplifiedNumerator, simplifiedDenominator);
    }

    static int GetNonNegativeInteger(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int number) && number >= 0)
                return number;
            Console.WriteLine("Ошибка: введите неотрицательное целое чис-ло!");
        }
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
