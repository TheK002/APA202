using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    internal class Dolar
    {
        public decimal USD { get; set; }

        public Dolar(decimal usd)
        {
            USD = usd;
        }

        public static implicit operator Dolar(Manat manat)
        {
            return new Dolar(manat.AZN / 1.7m);
        }
    }
}
