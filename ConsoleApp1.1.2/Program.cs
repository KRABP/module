using System;

class Program
{
    static void Main()
    {

        Console.Write("Введите первое число: ");
        string input1 = Console.ReadLine();

        Console.Write("Введите второе число: ");
        string input2 = Console.ReadLine();

        if (int.TryParse(input1, out int number1) && int.TryParse(input2, out int number2))
        {
            int sum = number1 + number2;
            Console.WriteLine($"\nРезультат: {number1} + {number2} = {sum}");
        }
        else
        {
            Console.WriteLine("\nОшибка: Пожалуйста, введите корректные целые числа!");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
