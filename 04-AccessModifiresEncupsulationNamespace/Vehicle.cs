using System;

public class Vehicle
{
    private string _brand;
    private int _year;

    public string Brand
    {
        get => _brand;
        set
        {
            if (value.Length < 3)
                throw new ArgumentException("Brand minimum 3 simvol olmalıdır.");
            _brand = value;
        }
    }

    public string Model { get; set; }

    public int Year
    {
        get => _year;
        set
        {
            if (value <= 1900)
                throw new ArgumentException("Year 1900-dən böyük olmalıdır.");
            _year = value;
        }
    }

    public int MileageKm { get; protected set; }
    public bool IsRunning { get; protected set; }

    public Vehicle(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
        MileageKm = 0;
        IsRunning = false;
    }

    public void StartEngine()
    {
        IsRunning = true;
    }

    public void StopEngine()
    {
        IsRunning = false;
    }

    public virtual void Drive(int km)
    {
        if (!IsRunning)
        {
            Console.WriteLine("Mühərrik işləmədən sürmək olmaz!");
            return;
        }

        MileageKm += km;
    }

    public virtual void VehicleInfo()
    {
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Year: {Year}");
        Console.WriteLine($"Mileage: {MileageKm} km");
        Console.WriteLine($"Running: {(IsRunning ? "Yes" : "No")}");
    }
}