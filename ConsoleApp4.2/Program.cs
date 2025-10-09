using System;
using System.Collections.Generic;

public interface IProduct
{
    string Name { get; set; }
    double GetPrice();
    int GetStockQuantity();
    void DisplayInfo();
}
 
public class FoodProduct : IProduct
{
    public string Name { get; set; }
    public double PricePerKg { get; set; }
    public double Weight { get; set; }
    public int Quantity { get; set; }

    public FoodProduct(string name, double pricePerKg, double weight, int quantity)
    {
        Name = name;
        PricePerKg = pricePerKg;
        Weight = weight;
        Quantity = quantity;
    }

    public double GetPrice()
    {
        return PricePerKg * Weight;
    }

    public int GetStockQuantity()
    {
        return Quantity;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Продукт: {Name}");
        Console.WriteLine($"Цена за кг: {PricePerKg:F2} руб.");
        Console.WriteLine($"Вес: {Weight:F2} кг");
        Console.WriteLine($"Стоимость: {GetPrice():F2} руб.");
        Console.WriteLine($"Остаток на складе: {Quantity} шт.");
        Console.WriteLine();
    }
}

public class ElectronicsProduct : IProduct
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int WarrantyMonths { get; set; }

    public ElectronicsProduct(string name, double price, int quantity, int warrantyMonths)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        WarrantyMonths = warrantyMonths;
    }

    public double GetPrice()
    {
        return Price;
    }

    public int GetStockQuantity()
    {
        return Quantity;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Электроника: {Name}");
        Console.WriteLine($"Цена: {Price:F2} руб.");
        Console.WriteLine($"Гарантия: {WarrantyMonths} мес.");
        Console.WriteLine($"Остаток на складе: {Quantity} шт.");
        Console.WriteLine();
    }
}

public class ClothingProduct : IProduct
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string Size { get; set; }

    public ClothingProduct(string name, double price, int quantity, string size)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        Size = size;
    }

    public double GetPrice()
    {
        return Price;
    }

    public int GetStockQuantity()
    {
        return Quantity;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Одежда: {Name}");
        Console.WriteLine($"Цена: {Price:F2} руб.");
        Console.WriteLine($"Размер: {Size}");
        Console.WriteLine($"Остаток на складе: {Quantity} шт.");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<IProduct> products = new List<IProduct>
        {
            new FoodProduct("Яблоки", 120.50, 2.5, 50),
            new FoodProduct("Молоко", 85.00, 1.0, 30),
            new ElectronicsProduct("Смартфон", 25000.00, 15, 24),
            new ElectronicsProduct("Ноутбук", 65000.00, 8, 36),
            new ClothingProduct("Футболка", 1500.00, 25, "L"),
            new ClothingProduct("Джинсы", 3500.00, 18, "M")
        };

        Console.WriteLine("=== Учет продуктов в магазине ===");
        Console.WriteLine("Все товары:");
        Console.WriteLine("============");

        foreach (var product in products)
        {
            product.DisplayInfo();
        }

        double totalValue = 0;
        foreach (var product in products)
        {
            totalValue += product.GetPrice() * product.GetStockQuantity();
        }
        Console.WriteLine($"Общая стоимость товаров на складе: {totalValue:F2} руб.");

        Console.WriteLine("\nТовары с низким остатком (меньше 10 шт.):");
        Console.WriteLine("========================================");

        foreach (var product in products)
        {
            if (product.GetStockQuantity() < 10)
            {
                product.DisplayInfo();
            }
        }

        Console.Write("\nВведите название товара для поиска: ");
        string searchName = Console.ReadLine();

        bool found = false;
        foreach (var product in products)
        {
            if (product.Name.ToLower().Contains(searchName.ToLower()))
            {
                Console.WriteLine("Найденный товар:");
                product.DisplayInfo();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Товар не найден!");
        }
    }
}