using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab4
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {


        public Window1()
        {
            InitializeComponent();
        }
        public Window1(double P, double O) : this()
        {

            this.tbkobw.Text = $"Pole:{O}";
            this.tbkPole.Text = $"Pole:{P}";
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
