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
    public partial class okno : Window
    {
        public double[] Liczby { private get; set; }

        public okno(double[] liczby)
        {
            InitializeComponent();
            Liczby = liczby;
            WypelnijListBox();
        }

        private void WypelnijListBox()
        {
            foreach (double liczba in Liczby)
            {
                listBox.Items.Add(liczba);
            }
        }
    }
}
