using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_InterfaceAbstraction
{
    public class Calculation : ICalculation
    {
        public double Calculate(double a, double b, char operation)
        {
            switch (operation)
            {
                case '+':
                    return a + b;

                case '-':
                    return a - b;

                case '*':
                    return a * b;

                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("0-a bölmək olmaz!");
                        return 0;
                    }
                    return a / b;

                default:
                    Console.WriteLine("Yanlısh emeliyyat!");
                    return 0;
            }
        }
    }
}
