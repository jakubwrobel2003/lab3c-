using System;

namespace Geometria
{
    public interface IWyświetl : IComparable
    {
        string PobierzIdentyfikator();
    }

    public abstract class Bryła
    {
        private string nazwa;
        private double gestosc;
        private double cenaZaKg;

        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }
        public double Gestosc => gestosc;
        public double CenaZaKg => cenaZaKg;

        public abstract double ObliczObj();
        public double ObliczMase()
        {
            return ObliczObj() * this.gestosc;
        }
        public double ObliczCene()
        {
            return ObliczObj() * this.cenaZaKg;
        }

        public Bryła(string n, double g, double c)
        {
            this.nazwa = n;
            this.gestosc = g;
            this.cenaZaKg = c;
        }

        public override string ToString()
        {
            return $"Nazwa: {nazwa}, Gęstość: {gestosc}, Cena za kg: {cenaZaKg} Objętość: {ObliczObj()} Masa: {ObliczMase()} Cena: {ObliczCene()}";
        }
    }

    public class Kula : Bryła, IWyświetl
    {
        private double promien;
        public double Promien => promien;

        public override double ObliczObj()
        {
            return 4.0 / 3.0 * Math.PI * Math.Pow(promien, 3);
        }

        public Kula(double p, double g, double c) : base("Kula", g, c)
        {
            this.promien = p;
        }

        public virtual string PobierzIdentyfikator()
        {
            return $"Kula - Promień: {Promien:F2}, Objętość: {ObliczObj():F2}";
        }

        public virtual int CompareTo(object obj)
        {
            if (obj is Student) return 1;
            if (obj is Kula k)
                return ObliczObj().CompareTo(k.ObliczObj()) * -1;
            if (obj is Stozek s)
                return ObliczObj().CompareTo(s.ObliczObj()) * -1;
            return 0;
        }
        //zadanie domowe
        // operator +
        public static Kula operator +(Kula k1, Kula k2)
        {
            double sumaObjetosci = k1.ObliczObj() + k2.ObliczObj();
            double nowyPromien = Math.Pow((3 * sumaObjetosci) / (4 * Math.PI), 1.0 / 3.0);
            return new Kula(nowyPromien, k1.Gestosc, k1.CenaZaKg);
        }

        // operator -
        public static Kula operator -(Kula k1, Kula k2)
        {
            double roznicaObjetosci = Math.Max(0, k1.ObliczObj() - k2.ObliczObj());
            double nowyPromien = Math.Pow((3 * roznicaObjetosci) / (4 * Math.PI), 1.0 / 3.0);
            return new Kula(nowyPromien, k1.Gestosc, k1.CenaZaKg);
        }

        // operator ++
        public static Kula operator ++(Kula k)
        {
            double nowaObjetosc = k.ObliczObj() + 1;
            double nowyPromien = Math.Pow((3 * nowaObjetosc) / (4 * Math.PI), 1.0 / 3.0);
            return new Kula(nowyPromien, k.Gestosc, k.CenaZaKg);
        }
    }

    public class Stozek : Kula, IWyświetl
    {
        private double h;
        public double H => h;

        public override double ObliczObj()
        {
            return 1.0 / 3.0 * Math.PI * Math.Pow(this.Promien, 2) * h;
        }

        public Stozek(double e, double p, double g, double c) : base(p, g, c)
        {
            this.h = e;
            this.Nazwa = "Stożek";
        }

        public override string PobierzIdentyfikator()
        {
            return $"Stożek - Promień: {Promien:F2}, Wysokość: {H:F2}, Objętość: {ObliczObj():F2}";
        }

        public override int CompareTo(object obj)
        {
            if (obj is Student) return 1;
            if (obj is Kula k)
                return ObliczObj().CompareTo(k.ObliczObj()) * -1;
            if (obj is Stozek s)
                return ObliczObj().CompareTo(s.ObliczObj()) * -1;
            return 0;
        }
    }

    public class Student : IWyświetl
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public Student(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public string PobierzIdentyfikator()
        {
            return $"Student: {Imie} {Nazwisko}";
        }

        public int CompareTo(object obj)
        {
            if (obj is Student s)
                return this.Nazwisko.CompareTo(s.Nazwisko);
            return -1;
        }
    }
}
