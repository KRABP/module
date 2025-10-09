using System;


public class Person
{

    private string name;
    private int age;
    private string address;

    public Person()
    {
        name = "Неизвестно";
        age = 0;
        address = "Не указан";
    }

    public Person(string name, int age, string address)
    {
        this.name = name;
        this.age = age;
        this.address = address;
    }

    public string GetName()
    {
        return name;
    }

    public int GetAge()
    {
        return age;
    }

    public string GetAddress()
    {
        return address;
    }

    public void SetName(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            this.name = name;
        }
    }

    public void SetAge(int age)
    {
        if (age >= 0 && age <= 150)
        {
            this.age = age;
        }
    }

    public void SetAddress(string address)
    {
        if (!string.IsNullOrWhiteSpace(address))
        {
            this.address = address;
        }
    }


    public void DisplayInfo()
    {
        Console.WriteLine($"Имя: {name}");
        Console.WriteLine($"Возраст: {age} лет");
        Console.WriteLine($"Адрес: {address}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {

        Person person1 = new Person();
        person1.SetName("Иван Петров");
        person1.SetAge(25);
        person1.SetAddress("г. Москва, ул. Ленина, д. 10");

        Person person2 = new Person("Мария Сидорова", 30, "г. Санкт-Петербург, Невский пр., д. 25");

        Person person3 = new Person();
        person3.SetName("Алексей Иванов");
        person3.SetAge(35);
        person3.SetAddress("г. Екатеринбург, ул. Мира, д. 15");


        person1.DisplayInfo();
        person2.DisplayInfo();
        person3.DisplayInfo();

        Console.WriteLine($"Имя первого человека: {person1.GetName()}");
        Console.WriteLine($"Возраст второго человека: {person2.GetAge()} лет");
        Console.WriteLine($"Адрес третьего человека: {person3.GetAddress()}");

        Console.ReadLine();
    }
}