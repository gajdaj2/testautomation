using System;
using System.Collections.Generic;
using System.Text;
using Szkolenie.models;

namespace Szkolenie.Cards
{
    public class Visa : Card
    {

        private double AccountSaldo;

        public void History()
        {
            Console.WriteLine("History of card usage");
        }

        public void Pay(double wartosc)
        {
            Console.WriteLine("You wand spend "+wartosc);
        }

        public void Saldo()
        {
            Console.WriteLine("Your saldo is: "+AccountSaldo);
        }
    }
}
