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
namespace vlm
{
    public partial class Window1 : Window
    {
        public class CsapatStat
        {
            public string Csapat { get; set; }
            public int VersenyzokSzama { get; set; }
            public int OsszNyereseg { get; set; }
            public int OsszVeszteseg { get; set; }
            public int PirosLapok { get; set; }
            public int SargaLapok { get; set; }
        }

        public Window1()
        {
            InitializeComponent();
            BetoltCsapatStatisztika();
        }

        private void BetoltCsapatStatisztika()
        {
            var sorok = System.IO.File.ReadAllLines("adatok.txt");
            var csapatok = new Dictionary<string, CsapatStat>();

            foreach (var sor in sorok)
            {
                var mezok = sor.Split(',');
                if (mezok.Length < 9) continue;

                string csapat = mezok[1];
                bool piros = bool.Parse(mezok[5]);
                int pirosSzam = int.Parse(mezok[6]);
                bool sarga = bool.Parse(mezok[7]);
                int sargaSzam = int.Parse(mezok[8]);

                int nyereseg = new Random().Next(0, 10);
                int veszteseg = new Random().Next(0, 10);

                if (!csapatok.ContainsKey(csapat))
                {
                    csapatok[csapat] = new CsapatStat
                    {
                        Csapat = csapat,
                        VersenyzokSzama = 0,
                        OsszNyereseg = 0,
                        OsszVeszteseg = 0,
                        PirosLapok = 0,
                        SargaLapok = 0
                    };
                }

                var stat = csapatok[csapat];
                stat.VersenyzokSzama++;
                stat.OsszNyereseg += nyereseg;
                stat.OsszVeszteseg += veszteseg;
                stat.PirosLapok += piros ? pirosSzam : 0;
                stat.SargaLapok += sarga ? sargaSzam : 0;
            }

            CsapatListView.ItemsSource = csapatok.Values.ToList();
        }

        private void OpenVersenyzoStat_Click(object sender, RoutedEventArgs e)
        {
            var statWindow = new stat_versenyzo(new List<stat_versenyzo.VersenyzoStat>()); // üres vagy feltöltött lista
            statWindow.Show();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

