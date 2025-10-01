using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int k;
        while (true)
        {
            Console.Write("Введите количество простых чисел K: ");
            if (int.TryParse(Console.ReadLine(), out k) && k > 0)
            {
                break;
            }
            Console.WriteLine("Ошибка: введите целое положительное чис-ло!");
        }
        List<int> primes = GeneratePrimes(k);
        Console.WriteLine($"\nПервые {k} простых чисел:");
        PrintPrimesFormatted(primes);
        Console.WriteLine($"\n Статистика:");
        Console.WriteLine($"Последнее простое число: {primes[primes.Count - 1]}");
        Console.WriteLine($"Сумма всех чисел: {SumPrimes(primes):N0}");
    }
    static List<int> GeneratePrimes(int k)
    {
        List<int> primes = new List<int>();
        int number = 2;

        while (primes.Count < k)
        {
            if (IsPrime(number))
            {
                primes.Add(number);
            }
            number++;
        }

        return primes;
    }
    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        for (int i = 3; i * i <= n; i += 2)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }

    static void PrintPrimesFormatted(List<int> primes)
    {
        for (int i = 0; i < primes.Count; i++)
        {
            Console.Write($"{primes[i],6}");
            if ((i + 1) % 10 == 0)
                Console.WriteLine();
        }

        if (primes.Count % 10 != 0)
            Console.WriteLine();
    }

    static long SumPrimes(List<int> primes)
    {
        long sum = 0;
        foreach (int prime in primes)
        {
            sum += prime;
        }
        return sum;
    }
}
