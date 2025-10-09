using System;
using System.Collections.Generic;

class Program
{
    // Делегат для методов сортировки
    public delegate void SortDelegate(List<int> data);

    // Метод сортировки пузырьком
    static void BubbleSort(List<int> data)
    {
        for (int i = 0; i < data.Count - 1; i++)
        {
            for (int j = 0; j < data.Count - i - 1; j++)
            {
                if (data[j] > data[j + 1])
                {
                    int temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                }
            }
        }
    }

    // Метод быстрой сортировки
    static void QuickSort(List<int> data)
    {
        QuickSortRecursive(data, 0, data.Count - 1);
    }

    static void QuickSortRecursive(List<int> data, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(data, left, right);
            QuickSortRecursive(data, left, pivotIndex - 1);
            QuickSortRecursive(data, pivotIndex + 1, right);
        }
    }

    static int Partition(List<int> data, int left, int right)
    {
        int pivot = data[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (data[j] <= pivot)
            {
                i++;
                int temp = data[i];
                data[i] = data[j];
                data[j] = temp;
            }
        }

        int temp2 = data[i + 1];
        data[i + 1] = data[right];
        data[right] = temp2;

        return i + 1;
    }

    // Метод сортировки выбором
    static void SelectionSort(List<int> data)
    {
        for (int i = 0; i < data.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < data.Count; j++)
            {
                if (data[j] < data[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                int temp = data[i];
                data[i] = data[minIndex];
                data[minIndex] = temp;
            }
        }
    }

    // Метод для вывода массива
    static void PrintArray(List<int> data)
    {
        Console.WriteLine(string.Join(", ", data));
    }

    // Метод для генерации случайных данных
    static List<int> GenerateRandomData(int count)
    {
        Random random = new Random();
        List<int> data = new List<int>();

        for (int i = 0; i < count; i++)
        {
            data.Add(random.Next(1, 100));
        }

        return data;
    }

    static void Main(string[] args)
    {
        // Словарь доступных методов сортировки
        Dictionary<string, SortDelegate> sortMethods = new Dictionary<string, SortDelegate>
        {
            { "1", BubbleSort },
            { "2", QuickSort },
            { "3", SelectionSort }
        };

        List<int> data = new List<int>();

        while (true)
        {
            Console.WriteLine("\n=== Приложение для сортировки ===");
            Console.WriteLine("1. Ввести данные вручную");
            Console.WriteLine("2. Сгенерировать случайные данные");
            Console.WriteLine("3. Выбрать метод сортировки");
            Console.WriteLine("4. Выйти");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите числа через пробел: ");
                    string input = Console.ReadLine();
                    string[] numbers = input.Split(' ');

                    data.Clear();
                    foreach (string number in numbers)
                    {
                        if (int.TryParse(number, out int num))
                        {
                            data.Add(num);
                        }
                    }
                    Console.WriteLine("Данные сохранены: " + string.Join(", ", data));
                    break;

                case "2":
                    Console.Write("Введите количество элементов: ");
                    if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
                    {
                        data = GenerateRandomData(count);
                        Console.WriteLine("Сгенерированные данные: " + string.Join(", ", data));
                    }
                    else
                    {
                        Console.WriteLine("Неверное количество!");
                    }
                    break;

                case "3":
                    if (data.Count == 0)
                    {
                        Console.WriteLine("Сначала введите данные!");
                        break;
                    }

                    Console.WriteLine("\nДоступные методы сортировки:");
                    Console.WriteLine("1. Сортировка пузырьком");
                    Console.WriteLine("2. Быстрая сортировка");
                    Console.WriteLine("3. Сортировка выбором");
                    Console.Write("Выберите метод: ");

                    string methodChoice = Console.ReadLine();

                    if (sortMethods.ContainsKey(methodChoice))
                    {
                        List<int> dataToSort = new List<int>(data); // Копия для сортировки

                        Console.WriteLine("\nИсходные данные:");
                        PrintArray(dataToSort);

                        SortDelegate selectedSort = sortMethods[methodChoice];
                        selectedSort(dataToSort);

                        Console.WriteLine("Отсортированные данные:");
                        PrintArray(dataToSort);
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор метода!");
                    }
                    break;

                case "4":
                    Console.WriteLine("Выход из приложения...");
                    return;

                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }
}