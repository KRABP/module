using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            if (input?.ToLower() == "exit")
                break;

            if (int.TryParse(input, out int number))
            {
                if (number < 2)
                {
                    Console.WriteLine($" Число {number} не является простым (простые числа ≥ 2)");
                }
                else if (IsPrime(number))
                {
                    Console.WriteLine($" Число {number} - Простое");
                }
                else
                {
                    Console.WriteLine($" Число {number} - Составное");
                }
            }
            else
            {
                Console.WriteLine(" Ошибка: Введите целое число!");
            }

            Console.WriteLine();
        }
    }

    static bool IsPrime(int n)
    {
        if (n == 2 || n == 3)
            return true;

        if (n % 2 == 0 || n % 3 == 0)
            return false;

        for (int i = 5; i * i <= n; i += 6)
        {
            if (n % i == 0 || n % (i + 2) == 0)
                return false;
        }

        return true;
    }
}
