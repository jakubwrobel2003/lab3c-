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
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public double Szczerosc
        {
            get
            {
                return Convert.ToDouble(szeroksc.Text);
            }
        }
        //public double wyskosc
        //{
        //    get => Convert.ToDouble(szeroksc.Text);

        //}
        public double wyskosc => Convert.ToDouble(szeroksc.Text);
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
