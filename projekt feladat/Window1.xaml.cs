using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace vlm
{
    public partial class stat_versenyzo : Window
    {
        public class VersenyzoStat
        {
            public string Nev { get; set; }
            public string Csapat { get; set; }
            public string Tapasztalat { get; set; }
            public string Korosztaly { get; set; }
            public string PirosLap { get; set; }
            public string SargaLap { get; set; }
            public int Nyereseg { get; set; }
            public int Veszteseg { get; set; }
        }

        private List<VersenyzoStat> statisztikak;

        public stat_versenyzo(List<VersenyzoStat> versenyzok)
        {
            InitializeComponent();
            statisztikak = versenyzok;
            StatListView.ItemsSource = statisztikak;
        }

        private void MentesStat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("stat.txt"))
                {
                    foreach (var v in statisztikak)
                    {
                        sw.WriteLine($"Név: {v.Nev}, Csapat: {v.Csapat}, Tapasztalat: {v.Tapasztalat}, Korosztály: {v.Korosztaly}, " +
                                     $"Piros lap: {v.PirosLap}, Sárga lap: {v.SargaLap}, Nyereség: {v.Nyereseg}, Veszteség: {v.Veszteseg}");
                    }
                }
                MessageBox.Show("Statisztika mentve a stat.txt fájlba!", "Mentés sikeres");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Hiba a mentés közben: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
