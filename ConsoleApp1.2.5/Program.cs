using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int k = GetPositiveInteger("Введите размер массива K: ");
        char[] originalArray = GRussianArray(k);
        char[] consonantsArray = FilterConsonants(originalArray);

        Console.WriteLine("\n Исходный массив:");
        PrintCharArray(originalArray);

        Console.WriteLine("\n Массив согласных букв:");
        PrintCharArray(consonantsArray);

        Console.WriteLine($"\n Статистика:");
        Console.WriteLine($"Всего элементов: {originalArray.Length}");
        Console.WriteLine($"Согласных букв: {consonantsArray.Length}");
        Console.WriteLine($"Гласных букв: {CountVowels(originalArray)}");
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

    static char[] GRussianArray(int size)
    {
        char[] russianAlphabet = {
            'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М',
            'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ',
            'Ы', 'Ь', 'Э', 'Ю', 'Я',
            'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м',
            'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ',
            'ы', 'ь', 'э', 'ю', 'я'
        };

        Random random = new Random();
        char[] array = new char[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = russianAlphabet[random.Next(russianAlphabet.Length)];
        }

        return array;
    }

    static char[] FilterConsonants(char[] array)
    {
        char[] vowels = { 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я',
                         'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };

        return array.Where(c => !vowels.Contains(c)).ToArray();
    }

    static void PrintCharArray(char[] array)
    {
        if (array.Length == 0)
        {
            Console.WriteLine("Массив пуст");
            return;
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]} ");
            if ((i + 1) % 15 == 0)
                Console.WriteLine();
        }

        if (array.Length % 15 != 0)
            Console.WriteLine();
    }

    static int CountVowels(char[] array)
    {
        char[] vowels = { 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я',
                         'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };

        return array.Count(c => vowels.Contains(c));
    }
}
