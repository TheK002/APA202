class Program
{
    static void Main()
    {
        // Cars
        Car car1 = new Car("Mercedes", "E200", 2023, "10-AA-001", 4, 500, true, 220);
        Car car2 = new Car("BMW", "320i", 2022, "10-AA-002", 4, 480, true, 235);
        Car car3 = new Car("Toyota", "Camry", 2021, "10-AA-003", 4, 524, true, 210);

        // Motorcycles
        Motorcycle m1 = new Motorcycle("Yamaha", "R1", 2023, "10-BB-001", 998, false, 299, "Sport");
        Motorcycle m2 = new Motorcycle("Harley-Davidson", "HD", 2022, "10-BB-002", 1868, true, 180, "Cruiser");

        // Trucks
        Truck t1 = new Truck("MAN", "TGX", 2020, "10-CC-001", 18, 3, 12, 120);
        Truck t2 = new Truck("Volvo", "FH16", 2021, "10-CC-002", 25, 4, 18, 110);

        // Show Info + Fuel Cost
        Console.WriteLine("---- CARS ----");
        car1.ShowCarInfo(); Console.WriteLine("Fuel Cost (500km): " + car1.CalculateFuelCost(500));
        car2.ShowCarInfo(); Console.WriteLine("Fuel Cost (500km): " + car2.CalculateFuelCost(500));
        car3.ShowCarInfo(); Console.WriteLine("Fuel Cost (500km): " + car3.CalculateFuelCost(500));

        Console.WriteLine("\n---- MOTORCYCLES ----");
        m1.ShowMotorcycleInfo(); Console.WriteLine("Fuel Cost (300km): " + m1.CalculateFuelCost(300));
        m2.ShowMotorcycleInfo(); Console.WriteLine("Fuel Cost (300km): " + m2.CalculateFuelCost(300));

        Console.WriteLine("\n---- TRUCKS ----");
        t1.ShowTruckInfo(); Console.WriteLine("Fuel Cost (800km): " + t1.CalculateFuelCost(800));
        t2.ShowTruckInfo(); Console.WriteLine("Fuel Cost (800km): " + t2.CalculateFuelCost(800));

        // Load cargo
        Console.WriteLine("\n--- Loading Cargo ---");
        t1.LoadCargo(5);
        Console.WriteLine("New Fuel Cost (800km): " + t1.CalculateFuelCost(800));

        // Statistics
        Vehicle[] vehicles = { car1, car2, car3, m1, m2, t1, t2 };

        int total = vehicles.Length;
        double avgSpeed =
            (car1.MaxSpeed + car2.MaxSpeed + car3.MaxSpeed +
             m1.MaxSpeed + m2.MaxSpeed +
             t1.MaxSpeed + t2.MaxSpeed) / (double)total;

        double maxFuel = 0;
        string expensiveVehicle = "";

        foreach (var v in vehicles)
        {
            double cost = 0;

            if (v is Car c) cost = c.CalculateFuelCost(500);
            else if (v is Motorcycle m) cost = m.CalculateFuelCost(300);
            else if (v is Truck t) cost = t.CalculateFuelCost(800);

            if (cost > maxFuel)
            {
                maxFuel = cost;
                expensiveVehicle = v.Brand + " " + v.Model;
            }
        }

        Console.WriteLine("\n---- STATISTICS ----");
        Console.WriteLine("Total Vehicles: " + total);
        Console.WriteLine("Average Max Speed: " + avgSpeed);
        Console.WriteLine("Most Expensive Fuel Cost: " + expensiveVehicle + " - " + maxFuel);
    }
}