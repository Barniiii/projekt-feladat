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
using projekt_feladat;

namespace vlm
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
        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            // Új ablak megnyitása
            Window1 window1 = new Window1();
            window1.Show();

            // Adatok beolvasása a felületről
            string nev = NevInput.Text;
            string csapat = CsapatInput.Text;
            string korosztaly = (KorosztalyInput.SelectedItem as ComboBoxItem)?.Content.ToString();
            string tapasztalat = TapasztalatInput.Text;
            string verseny = VersenyInput.Text;

            bool pirosLap = PirosLapInput.IsChecked ?? false;
            string pirosLapMennyiseg = pirosLap ? PirosLapSzamInput.Text : "0";

            bool sargaLap = SargaLapInput.IsChecked ?? false;
            string sargaLapMennyiseg = sargaLap ? SargaLapSzamInput.Text : "0";

            // Adatok formázása (pl. CSV)
            string sor = $"{nev},{csapat},{korosztaly},{tapasztalat},{verseny},{pirosLap},{pirosLapMennyiseg},{sargaLap},{sargaLapMennyiseg}";

            // Mentés fájlba (pl. adatok.txt a program mappájában)
            string filePath = "adatok.txt";

            try
            {
                System.IO.File.AppendAllText(filePath, sor + Environment.NewLine);
                MessageBox.Show("Adatokat mentettük!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a mentés közben: " + ex.Message);
            }
        }


        private void PirosLapInput_Checked(object sender, RoutedEventArgs e)
        {
            PirosLapMennyisegPanel.Visibility = Visibility.Visible;
        }

        private void PirosLapInput_Unchecked(object sender, RoutedEventArgs e)
        {
            PirosLapMennyisegPanel.Visibility = Visibility.Collapsed;
            PirosLapSzamInput.Text = string.Empty;
        }

        private void SargaLapInput_Checked(object sender, RoutedEventArgs e)
        {
            SargaLapMennyisegPanel.Visibility = Visibility.Visible;
        }

        private void SargaLapInput_Unchecked(object sender, RoutedEventArgs e)
        {
            SargaLapMennyisegPanel.Visibility = Visibility.Collapsed;
            SargaLapSzamInput.Text = string.Empty;
        }

    }

}
