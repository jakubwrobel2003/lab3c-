using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Rejestr;
namespace Motoryzacja
{
    public class Pojazd
    {
        private static int liczbaPojazdów;
        private string nazwa;
        private int liczbaKół;
        private double prędkość;

        public static int LiczbaPojazdów => liczbaPojazdów;
        public int Lp { get; private set; }
        private List<RejestrNazw> HistoriaNazw = new List<RejestrNazw>();

        static Pojazd()
        {
            liczbaPojazdów = 0;
        }

        public Pojazd()
        {
            liczbaPojazdów++;
            Lp = liczbaPojazdów;
        }

        public string Nazwa
        {
            get => nazwa;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nazwa nie może być pusta.");

                if (nazwa != null && nazwa != value)
                    HistoriaNazw.Add(new RejestrNazw(DateTime.Now, value));

                nazwa = value;
            }
        }

        public int LiczbaKół
        {
            get => liczbaKół;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Liczba kół musi być dodatnia.");
                liczbaKół = value;
            }
        }

        public double Prędkość
        {
            get => prędkość;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Prędkość nie może być ujemna.");
                prędkość = value;
            }
        }

        public Pojazd(string nazwa, int liczbaKół, double prędkość) : this()
        {
            Nazwa = nazwa;
            LiczbaKół = liczbaKół;
            Prędkość = prędkość;
        }

        public Pojazd(string nazwa, double prędkość) : this(nazwa, 4, prędkość) { }

        public override string ToString()
        {
            return $"{Lp}/{LiczbaPojazdów}: {Nazwa}, {LiczbaKół} kół, {Prędkość} km/h";
        }

        public void WyświetlHistorię(System.Windows.Controls.ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (var wpis in HistoriaNazw)
            {
                listBox.Items.Add(wpis);
            }
        }
    }

    

    public class PojazdMechaniczny : Pojazd
    {
        private double mocSilnika;

        public double MocSilnika
        {
            get => mocSilnika;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Moc silnika musi być dodatnia.");
                mocSilnika = value;
            }
        }

        public PojazdMechaniczny(string nazwa, int liczbaKół, double prędkość, double moc)
            : base(nazwa, liczbaKół, prędkość)
        {
            MocSilnika = moc;
        }

        public override string ToString()
        {
            return base.ToString() + $", moc: {MocSilnika} KM";
        }
    }

    public class Samochód : PojazdMechaniczny
    {
        private int liczbaPasażerów;

        public int LiczbaPasażerów
        {
            get => liczbaPasażerów;
            set
            {
                if (value < 1)
                    throw new ArgumentException("Samochód musi mieć przynajmniej 1 pasażera.");
                liczbaPasażerów = value;
            }
        }

        public string Marka { get; set; }

        public Samochód(string nazwa, int liczbaKół, double prędkość, double moc, int pasażerowie, string marka)
            : base(nazwa, liczbaKół, prędkość, moc)
        {
            LiczbaPasażerów = pasażerowie;
            Marka = marka;
        }

        public override string ToString()
        {
            return base.ToString() + $", {Marka}, {LiczbaPasażerów} pasażerów";
        }
    }
}
