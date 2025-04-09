using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Motoryzacja;
using Obywatelf;
using Prostopadloscianf;
using Stozekf;
namespace lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
        public partial class MainWindow : Window
        {
            private Pojazd ostatniKlikniętyPojazd;

            public MainWindow()
            {
                InitializeComponent();
            }

            private void WyświetlPojazdy(IEnumerable<Pojazd> pojazdy)
            {
                listBoxPojazdy.Items.Clear();
                foreach (var pojazd in pojazdy)
                {
                    listBoxPojazdy.Items.Add(pojazd);
                }
            }

            private void btnZadanieA_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    Pojazd[] pojazdy = new Pojazd[]
                    {
                    new Pojazd("Rower", 2, 25),
                    new Pojazd("Skuter", 2, 40),
                    new Pojazd("Auto", 4, 130),
                    new Samochód("BMW", 4, 160, 180, 5, "BMW"),
                    new PojazdMechaniczny("Traktor", 4, 35, 70),
                    new Pojazd("Ciągnik", 2, 15),
                    new Pojazd() // użycie konstruktora bezparametrycznego
                    };

                    // Dla testu historii nazw:
                    pojazdy[2].Nazwa = "Sedan";
                    pojazdy[2].Nazwa = "Kombi";
                    pojazdy[2].Nazwa = "SUV";

                    // Zapamiętaj obiekt do wyświetlenia historii
                    ostatniKlikniętyPojazd = pojazdy[2];

                    WyświetlPojazdy(pojazdy);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Błąd: " + ex.Message);
                }
            }

            private void btnHistoria_Click(object sender, RoutedEventArgs e)
            {
                if (ostatniKlikniętyPojazd != null)
                {
                    ostatniKlikniętyPojazd.WyświetlHistorię(listBoxHistoria);
                }
                else
                {
                    MessageBox.Show("Nie wybrano żadnego pojazdu z historią nazw.");
                }
            }
        // Zadanie A – Obywatele
        private void btnStworzObywateli_Click(object sender, RoutedEventArgs e)
        {
            Obywatel.Obywatele.Clear();
            listBoxObywatele.Items.Clear();

            new Obywatel("Kowalski", "90010112345");
            new Obywatel("Nowak", "85030456789");
            new Obywatel("Wiśniewski", "92081234567");

            foreach (var ob in Obywatel.Obywatele)
            {
                listBoxObywatele.Items.Add(ob);
            }
        }

        // Zadanie B – Stożek
        private void btnStworzStozek_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var stozek = new Stozek
                {
                    Promien = 3,
                    Wysokosc = 5
                };
                labelStozek.Content = stozek.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        // Zadanie C – Prostopadłościany
        private void btnStworzProstopadlosciany_Click(object sender, RoutedEventArgs e)
        {
            listBoxProstopadlosciany.Items.Clear();

            Prostopadloscian[] tablica =
            {
                new Prostopadloscian(2, 3, 4),
                new Prostopadloscian(5),
                new Prostopadloscian(1.5, 2.5, 3.5),
                new Prostopadloscian(2)
            };

            foreach (var p in tablica)
            {
                listBoxProstopadlosciany.Items.Add(p.ToString());
            }
        }
    }
    }