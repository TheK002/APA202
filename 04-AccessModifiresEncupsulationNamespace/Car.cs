public class Car : Vehicle
{
    private double _fuelCapacity;
    private double _fuel;

    public double FuelCapacity
    {
        get => _fuelCapacity;
        set
        {
            if (value <= 0)
                throw new ArgumentException("FuelCapacity müsbət olmalıdır.");
            _fuelCapacity = value;
        }
    }

    public double Fuel
    {
        get => _fuel;
        set
        {
            if (value < 0)
                throw new ArgumentException("Fuel mənfi ola bilməz.");
            if (value > FuelCapacity)
                throw new ArgumentException("Fuel, FuelCapacity-dən böyük ola bilməz.");
            _fuel = value;
        }
    }

    public double FuelConsumptionPer100Km { get; set; }

    public Car(string brand, string model, int year,
               double fuelCapacity,
               double fuelConsumptionPer100Km,
               double fuel)
        : base(brand, model, year)
    {
        FuelCapacity = fuelCapacity;
        FuelConsumptionPer100Km = fuelConsumptionPer100Km;
        Fuel = fuel;
    }

    public void Refuel(double liters)
    {
        if (Fuel + liters > FuelCapacity)
        {
            Console.WriteLine("Çox yanacaq doldurmaq olmaz!");
            return;
        }

        Fuel += liters;
    }

    public override void Drive(int km)
    {
        if (!IsRunning)
        {
            Console.WriteLine("Mühərrik işləmədən sürmək olmaz!");
            return;
        }

        double requiredLiters = (km / 100.0) * FuelConsumptionPer100Km;

        if (Fuel < requiredLiters)
        {
            Console.WriteLine("Kifayət qədər yanacaq yoxdur!");
            return;
        }

        Fuel -= requiredLiters;
        MileageKm += km;
    }

    public override void VehicleInfo()
    {
        base.VehicleInfo();
        Console.WriteLine($"Fuel: {Fuel}L / {FuelCapacity}L");
    }
}