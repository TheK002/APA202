using _06_InterfaceAbstraction;

class Program
{
    static void Main(string[] args)
    {
        ICalculation calc = new Calculation();

        Console.Write("1-ci ededi daxil et: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("2-ci ededi daxil et: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Emeliyyati daxil et (+, -, *, /): ");
        char op = Convert.ToChar(Console.ReadLine());

        double result = calc.Calculate(a, b, op);

        Console.WriteLine($"Netice: {result}");
    }
}