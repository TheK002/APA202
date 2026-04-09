using _07_NullableEnumStruct.Enums.CafeApp.Enums;

class Program
{
    static void Main()
    {
        // 1️⃣ Sifarişlər

        var order1 = new DrinkOrder(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
        order1.DisplayOrder();

        order1.UpdateStatus(OrderStatus.Preparing);
        order1.UpdateStatus(OrderStatus.Ready);
        order1.UpdateStatus(OrderStatus.Delivered);


        var order2 = new DrinkOrder(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
        order2.DisplayOrder();

        order2.UpdateStatus(OrderStatus.Ready);


        var order3 = new DrinkOrder(103, "Vüqar", DrinkType.Juice, DrinkSize.Small);
        order3.DisplayOrder();


        // 2️⃣ Enum metodları

        Console.WriteLine("\n--- DrinkType ---");
        foreach (var item in Enum.GetValues(typeof(DrinkType)))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\n--- DrinkSize ---");
        foreach (var item in Enum.GetValues(typeof(DrinkSize)))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\n--- OrderStatus ---");
        foreach (var item in Enum.GetValues(typeof(OrderStatus)))
        {
            Console.WriteLine(item);
        }

        // ToString
        Console.WriteLine(DrinkType.Coffee.ToString()); // Coffee
        Console.WriteLine(DrinkSize.Large.ToString());  // Large

        // Parse
        DrinkType drinkParsed = (DrinkType)Enum.Parse(typeof(DrinkType), "Tea");
        DrinkSize sizeParsed = (DrinkSize)Enum.Parse(typeof(DrinkSize), "Medium");

        Console.WriteLine(drinkParsed);
        Console.WriteLine(sizeParsed);


        // 3️⃣ Statistika

        Console.WriteLine("\n--- Statistika ---");

        Console.WriteLine($"Ümumi sifariş: 3");
        Console.WriteLine($"1-ci sifariş qiyməti: {order1.Price}");
        Console.WriteLine($"2-ci sifariş qiyməti: {order2.Price}");
        Console.WriteLine($"3-cü sifariş qiyməti: {order3.Price}");

        decimal total = order1.Price + order2.Price + order3.Price;
        Console.WriteLine($"Ümumi məbləğ: {total}");
    }
}