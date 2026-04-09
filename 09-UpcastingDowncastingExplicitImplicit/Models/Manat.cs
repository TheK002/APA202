using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    internal class Manat
    {
        public decimal AZN { get; set; }

        public Manat(decimal azn)
        {
            AZN = azn;
        }

        public static implicit operator Manat(Dolar dolar)
        {
            return new Manat(dolar.USD * 1.7m);
        }
    }
}
