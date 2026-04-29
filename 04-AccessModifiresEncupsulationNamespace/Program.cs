class Program
{
    static void Main()
    {
        Car car = new Car("Toyota", "Corolla", 2018, 50, 7.5, 20);

        car.StartEngine();
        car.Drive(100);
        car.VehicleInfo();

        car.Refuel(10);
        car.VehicleInfo();
    }
}