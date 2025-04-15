using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Geometria;
using rozszezenie;
namespace rozszezenie
{
    public static class ListBoxExtensions
    {
        public static void Dodaj(this ListBox listBox, IWyświetl obiekt)
        {
            listBox.Items.Add(obiekt.PobierzIdentyfikator());
        }
    }
}

namespace lab4
{
    public static class InterfejsUżytkownika
    {
        public static bool Potwierdź(string pytanie)
        {
            // Tworzenie nowego okna
            Window okno = new Window()
            {
                Title = "Potwierdzenie",
                Width = 400,
                Height = 180,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Background = Brushes.IndianRed,
                ResizeMode = ResizeMode.NoResize,
                WindowStyle = WindowStyle.ToolWindow
            };

            // Pytanie i ikona
            StackPanel główny = new StackPanel() { Margin = new Thickness(10) };

            StackPanel górny = new StackPanel() { Orientation = Orientation.Horizontal };
            Image ikona = new Image()
            {
                Width = 48,
                Height = 48,
                Margin = new Thickness(5),
                Source = new BitmapImage(new Uri("https://icons.iconarchive.com/icons/paomedia/small-n-flat/1024/sign-question-icon.png"))
            };
            TextBlock tekst = new TextBlock()
            {
                Text = pytanie,
                FontSize = 16,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10)
            };
            górny.Children.Add(ikona);
            górny.Children.Add(tekst);

            // Przycisk TAK / NIE
            StackPanel dolny = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 20, 0, 0)
            };

            bool wynik = false;

            Button btnTak = new Button()
            {
                Content = "Tak",
                Width = 80,
                Margin = new Thickness(10),
                Background = Brushes.LightGreen
            };
            btnTak.Click += (s, e) => { wynik = true; okno.Close(); };

            Button btnNie = new Button()
            {
                Content = "Nie",
                Width = 80,
                Margin = new Thickness(10),
                Background = Brushes.LightCoral
            };
            btnNie.Click += (s, e) => { wynik = false; okno.Close(); };

            dolny.Children.Add(btnTak);
            dolny.Children.Add(btnNie);

            // Składanie okna
            główny.Children.Add(górny);
            główny.Children.Add(dolny);
            okno.Content = główny;

            okno.ShowDialog();

            return wynik;
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double w, h, P, O;
            Window2 okno1 = new Window2();
            okno1.ShowDialog();
            w = okno1.Szczerosc;
            h = okno1.wyskosc;
            P = w * h;
            O = 2 * w + 2 * h;
            Window1 okno2 = new Window1(P, O);
            okno2.ShowDialog();
        }

        private void btnstozek_Click(object sender, RoutedEventArgs e)
        {
            labelzad1.Content = "";
            Stozek XD = new Stozek(5, 4, 3, 2);
            labelzad1.Content = XD.ToString();
        }

        private void btnkula_Click(object sender, RoutedEventArgs e)
        {
            labelzad1.Content = "";
            Kula XD = new Kula(4, 3, 2);
            labelzad1.Content = XD.ToString();
        }

        private void btnZadC_Click(object sender, RoutedEventArgs e)
        {
            List<IWyświetl> obiekty = new List<IWyświetl>
            {
                new Kula(3, 2, 5),
                new Kula(2, 3, 6),
                new Stozek(5, 3, 2, 4),
                new Student("Anna", "Kowalska"),
                new Student("Jan", "Nowak"),
                new Student("Ewa", "Zielińska")
            };

            try
            {
                obiekty.Sort();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Błąd sortowania: " + ex.Message);
            }

            listBox1.Items.Clear();
            foreach (var obiekt in obiekty)
            {
                listBox1.Dodaj(obiekt);
            }
        }
        private void btnTestKula_Click(object sender, RoutedEventArgs e)
        {
            Kula k1 = new Kula(2, 1, 1);
            Kula k2 = new Kula(1, 1, 1);

            Kula suma = k1 + k2;
            Kula roznica = k1 - k2;
            Kula powiekszona = ++k1;

            MessageBox.Show($"Kula 1 objetosc {k1.ObliczObj():F2} Kula 2 objetosc {k2.ObliczObj():F2} Suma kul: {suma.ObliczObj():F2}\nRóżnica kul: {roznica.ObliczObj():F2}\nKula ++: {powiekszona.ObliczObj():F2}");
        }

        private void btnPotwierdz_Click(object sender, RoutedEventArgs e)
        {
            bool decyzja = InterfejsUżytkownika.Potwierdź("Czy na pewno chcesz kontynuować?");
            if (decyzja)
                MessageBox.Show("Kliknięto TAK");
            else
                MessageBox.Show("Kliknięto NIE");
        }
        //A
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            double[] liczby = { 1.5, 2.7, 3.14, 9.8, 7.3 };
            okno okno = new okno(liczby);
            okno.ShowDialog();
        }
        //B
        public class Istota
        {
            public string Opis { get; protected set; }

            public virtual void Wyswietl()
            {
                System.Windows.MessageBox.Show(Opis, "Informacja o istocie");
            }
        }
        public class Kosmita : Istota
        {
            private string planeta;
            private int liczbaOczu;

            public Kosmita()
            {
                planeta = "Mars";
                liczbaOczu = 3;
                Opis = $"Kosmita z planety {planeta}, liczba oczu: {liczbaOczu}";
            }
        }
        public class Waz : Istota
        {
            private bool jadowity;
            private double dlugosc;

            public Waz()
            {
                jadowity = true;
                dlugosc = 1.8;
                Opis = $"Wąż jadowity: {jadowity}, długość: {dlugosc}m";
            }
        }
       

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
                Istota kosmita = new Kosmita();
                Istota waz = new Waz();

                kosmita.Wyswietl();
                waz.Wyswietl();
        }
        
    }

    //c
    public class Towar
    {
        public int Ilosc { get; set; }
        public double Cena { get; set; }

        public override string ToString()
        {
            return $"Towar: ilość = {Ilosc}, cena = {Cena:F2} zł";
        }

        public static Towar operator +(Towar t1, Towar t2)
        {
            Towar nowy = new Towar();
            nowy.Ilosc = t1.Ilosc + t2.Ilosc;
            nowy.Cena = (t1.Cena * t1.Ilosc + t2.Cena * t2.Ilosc) / (t1.Ilosc + t2.Ilosc);
            return nowy;
        }
    }
    private void Button_Click4(object sender, RoutedEventArgs e)
        {
            Towar t1 = new Towar { Ilosc = 10, Cena = 5.0 };
            Towar t2 = new Towar { Ilosc = 20, Cena = 8.0 };

            Towar t3 = t1 + t2;

            MessageBox.Show(t3.ToString(), "Wynik dodawania towarów");
        }
    }
