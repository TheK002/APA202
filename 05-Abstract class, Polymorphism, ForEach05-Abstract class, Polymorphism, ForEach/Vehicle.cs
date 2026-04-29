using System;

class Vehicle
{
    public string Brand;
    public string Model;
    public int Year;
    public string PlateNumber;
    public double FuelLevel;

    public Vehicle(string brand, string model, int year, string plateNumber)
    {
        this.Brand = brand;
        this.Model = model;
        this.Year = year;
        this.PlateNumber = plateNumber;
        this.FuelLevel = 100;
    }

    public string GetVehicleInfo()
    {
        return $"{Brand} {Model} ({Year}) - Plate: {PlateNumber} - Fuel: {FuelLevel}%";
    }

    public void ShowBasicInfo()
    {
        Console.WriteLine(GetVehicleInfo());
    }
}