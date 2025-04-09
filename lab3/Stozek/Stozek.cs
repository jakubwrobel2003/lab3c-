using System;

namespace Stozekf
{
    public class Stozek
    {
        private double promien;
        private double wysokosc;

        public double Promien
        {
            get => promien;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Promień musi być dodatni.");
                promien = value;
            }
        }

        public double Wysokosc
        {
            get => wysokosc;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Wysokość musi być dodatnia.");
                wysokosc = value;
            }
        }

        public double Objetosc()
        {
            return (1.0 / 3) * Math.PI * promien * promien * wysokosc;
        }

        public double PolePowierzchni()
        {
            double l = Math.Sqrt(promien * promien + wysokosc * wysokosc); // tworząca
            return Math.PI * promien * (promien + l);
        }

        public override string ToString()
        {
            return $"Stożek → Promień: {promien}, Wysokość: {wysokosc}, Objętość: {Objetosc():F2}, Powierzchnia: {PolePowierzchni():F2}";
        }
    }
}
