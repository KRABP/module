using System;
class Program
{
    static void Main()
    {

        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Вы ввели пустую строку!");
            return;
        }
        string reversed = ReverseString(input);
        Console.WriteLine($"\nОригинал: {input}");
        Console.WriteLine($"Реверс:   {reversed}");
    }
    static string ReverseString(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
