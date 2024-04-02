using Motoryzacja;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnZadA_Click(object sender, RoutedEventArgs e)
        {
            List<Pojazd> pojazdy = new List<Pojazd>
            {
                new Pojazd("Samochód", 4, 120),
                new Pojazd("Motocykl", 2, 180),
                new Pojazd("Rower", 2, 30),
                new Pojazd("Autobus", 6, 80),
                new PojazdMechaniczny("Ciągnik", 4, 50, 100),
                new Samochod("Sedan", 4, 150, 200, 5, "Toyota")
            };

            pojazdy[0].DodajDoHistorii();
            WyswietlHistorie(pojazdy[0]);
            WyswietlPojazdy(pojazdy);
        }

        private void WyswietlPojazdy(List<Pojazd> pojazdy)
        {
            lbxZadA.Items.Clear();

            foreach (Pojazd pojazd in pojazdy)
            {
                lbxZadA.Items.Add(pojazd.ToString());
            }
        }

        private void WyswietlHistorie(Pojazd pojazd)
        {
            lbxHistoriaZmian.Items.Clear();

            foreach (var wpis in pojazd.PobierzHistorie())
            {
                lbxHistoriaZmian.Items.Add(wpis);
            }
        }
    }
}
