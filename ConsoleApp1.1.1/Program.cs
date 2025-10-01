using System;

class SimpleFactorial
{
    static void Main()
    {
        while (true)
        {
            Console.Write("\nВведите число: ");
            string input = Console.ReadLine();

            if (input == "exit")
                break;

            if (int.TryParse(input, out int number))
            {
                if (number < 0)
                {
                    Console.WriteLine("Факториал отрицательного числа не существует!");
                }
                else if (number > 20)
                {
                    Console.WriteLine("Попробуйте число до 20.");
                }
                else
                {
                    long factorial = 1;

                    for (int i = 1; i <= number; i++)
                    {
                        factorial *= i;
                    }

                    Console.WriteLine($"Факториал {number} = {factorial}");
                }
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите целое число!");
            }
        }
    }
}
