using System;

// Структура Train
public struct Train
{
    public string Destination;
    public int TrainNumber;
    public DateTime DepartureTime;

    public Train(string destination, int trainNumber, DateTime departureTime)
    {
        Destination = destination;
        TrainNumber = trainNumber;
        DepartureTime = departureTime;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Поезд №{TrainNumber}");
        Console.WriteLine($"Пункт назначения: {Destination}");
        Console.WriteLine($"Время отправления: {DepartureTime:HH:mm}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание массива из 5 поездов
        Train[] trains = new Train[5]
        {
            new Train("Москва", 104, new DateTime(2024, 1, 1, 14, 30, 0)),
            new Train("Санкт-Петербург", 78, new DateTime(2024, 1, 1, 8, 15, 0)),
            new Train("Москва", 56, new DateTime(2024, 1, 1, 20, 45, 0)),
            new Train("Казань", 123, new DateTime(2024, 1, 1, 16, 0, 0)),
            new Train("Санкт-Петербург", 91, new DateTime(2024, 1, 1, 10, 20, 0))
        };

        // Упорядочивание по номерам поездов
        Array.Sort(trains, (t1, t2) => t1.TrainNumber.CompareTo(t2.TrainNumber));

        Console.WriteLine("Поезда, упорядоченные по номерам:");
        Console.WriteLine("=================================");
        foreach (var train in trains)
        {
            train.DisplayInfo();
        }

        // Поиск поезда по номеру
        Console.Write("Введите номер поезда для поиска: ");
        int searchNumber = int.Parse(Console.ReadLine());

        bool found = false;
        foreach (var train in trains)
        {
            if (train.TrainNumber == searchNumber)
            {
                Console.WriteLine("Найденный поезд:");
                train.DisplayInfo();
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine($"Поезд с номером {searchNumber} не найден.");
        }

        // Сортировка по пункту назначения и времени отправления
        Array.Sort(trains, (t1, t2) =>
        {
            int destinationCompare = t1.Destination.CompareTo(t2.Destination);
            if (destinationCompare == 0)
            {
                return t1.DepartureTime.CompareTo(t2.DepartureTime);
            }
            return destinationCompare;
        });

        Console.WriteLine("Поезда, упорядоченные по пункту назначения и времени отправления:");
        Console.WriteLine("=================================================================");
        foreach (var train in trains)
        {
            train.DisplayInfo();
        }
    }
}