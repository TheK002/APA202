using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_InterfaceAbstraction
{
    public interface ICalculation
    {
        double Calculate(double a, double b, char operation);
    }
}
