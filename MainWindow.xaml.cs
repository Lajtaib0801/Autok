using System;
using System.Collections.Generic;
using System.IO;
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

namespace Autok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Eredmeny eredmeny = new Eredmeny();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = eredmeny;

        }

        private void btnUjAuto_Click(object sender, RoutedEventArgs e)
        {
            spAdatok.IsEnabled = true;
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbTipus.Text) &&
                !String.IsNullOrWhiteSpace(tbSzin.Text) &&
                !String.IsNullOrWhiteSpace(tbGyartasEve.Text) &&
                !String.IsNullOrWhiteSpace(tbAjtokSzama.Text))
            {
                eredmeny.autok.Add(new Auto($"{tbTipus.Text};{tbGyartasEve.Text};{tbAjtokSzama.Text};{tbSzin.Text}"));
                tbTipus.Text = tbSzin.Text = tbGyartasEve.Text = tbAjtokSzama.Text = String.Empty;
                MessageBox.Show("Autó hozzáadása sikeres!", "Siker!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Minden mező kitöltése kötelező!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            spAdatok.IsEnabled = false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("autok.txt");
                eredmeny.autok.ToList().ForEach(x => sw.WriteLine($"{x.Tipus};{x.GyartasEv};{x.AjtokSzama};{x.Szin}"));
                sw.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"A fájl írása sikertelen: {ex}");
                throw;
            }

        }
    }
}
