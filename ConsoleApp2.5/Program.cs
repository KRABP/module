using System;

// Класс TemperatureSensor
public class TemperatureSensor
{
    private double currentTemperature;

    // Событие TemperatureChanged
    public event Action<double> TemperatureChanged;

    public double CurrentTemperature
    {
        get => currentTemperature;
        set
        {
            if (currentTemperature != value)
            {
                currentTemperature = value;
                TemperatureChanged?.Invoke(currentTemperature);
            }
        }
    }
}

// Класс Thermostat
public class Thermostat
{
    public Thermostat(TemperatureSensor sensor)
    {
        // Подписка на событие TemperatureChanged
        sensor.TemperatureChanged += OnTemperatureChanged;
    }

    private void OnTemperatureChanged(double temperature)
    {
        if (temperature < 20)
        {
            Console.WriteLine($"Температура {temperature}°C - Включить отопление");
        }
        else if (temperature > 25)
        {
            Console.WriteLine($"Температура {temperature}°C - Выключить отопление");
        }
        else
        {
            Console.WriteLine($"Температура {temperature}°C - Поддерживать текущий режим");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TemperatureSensor sensor = new TemperatureSensor();
        Thermostat thermostat = new Thermostat(sensor);


        sensor.CurrentTemperature = 18;
        sensor.CurrentTemperature = 22;
        sensor.CurrentTemperature = 28;
        sensor.CurrentTemperature = 19;

        Console.ReadLine();
    }
}