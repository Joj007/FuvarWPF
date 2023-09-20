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
using System.IO;

namespace Doga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuvar> fuvarok = new ();
        public MainWindow()
        {
            InitializeComponent();
            //          Balra: -
            //          Jobbra: Gazdag Zsolt

            foreach (string sor in File.ReadAllLines("fuvar.csv").Skip(1))
            {
                string[] elemek = sor.Split(';');
                fuvarok.Add(new Fuvar(int.Parse(elemek[0]), DateTime.Parse(elemek[1]), int.Parse(elemek[2]), double.Parse(elemek[3]), double.Parse(elemek[4]), double.Parse(elemek[5]), elemek[6]));
            }
            fuvarok.DistinctBy(n => n.TaxiId).Select(n=>n.TaxiId).OrderBy(n=>n).ToList().ForEach(n =>cbTaxiSzam.Items.Add(n));

        }

        private void Urit()
        {
            lbEredmeny.Items.Clear();
        }

        private void btnHarom_Click(object sender, RoutedEventArgs e)
        {
            Urit();
            lbEredmeny.Items.Add($"3. feladat: {fuvarok.Count} fuvar");
        }

        private void btnNegy_Click(object sender, RoutedEventArgs e)
        {
            Urit();
            lbEredmeny.Items.Add($"4. feladat: {fuvarok.Count(n=>Convert.ToString(n.TaxiId) == Convert.ToString(cbTaxiSzam.SelectedItem))} fuvar alatt: {fuvarok.Where(n => Convert.ToString(n.TaxiId) == Convert.ToString(cbTaxiSzam.SelectedItem)).Sum(n=>n.VitelDij+n.Borravalo)}$");
        }

        private void btnOt_Click(object sender, RoutedEventArgs e)
        {
            Urit();
            lbEredmeny.Items.Add("5. feladat: ");
            fuvarok.GroupBy(n => n.FizetesiMod).ToList().ForEach(n=>lbEredmeny.Items.Add($"\t{n.Key}: {n.Count()} fuvar"));
        }

        private void btnHat_Click(object sender, RoutedEventArgs e)
        {
            Urit();
            lbEredmeny.Items.Add($"6. feladat {Math.Round(fuvarok.Sum(n=>n.TavolsagKilometer), 2)} km");
        }

        private void btnHet_Click(object sender, RoutedEventArgs e)
        {
            Urit();
            lbEredmeny.Items.Add($"6. feladat: Leghosszabb fuvar: \n{fuvarok.MaxBy(n => n.Idotartam).OsszesAdat}");
        }

        private void btnNyolc_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("Hibak.txt");
            sw.Write("");
            sw.WriteLine(File.ReadAllLines("fuvar.csv")[0]);
            List<Fuvar> hibasFuvarok = new();
            foreach(Fuvar fuvar in fuvarok)
            {
                if (fuvar.Idotartam > 0 && fuvar.VitelDij > 0 && fuvar.TavolsagKilometer == 0)
                {
                    hibasFuvarok.Add(fuvar);
                }
            }
            hibasFuvarok.OrderBy(n=>n.Indulas);
            foreach (var item in hibasFuvarok)
            {
                sw.WriteLine(item.Fajlba);
            }
            sw.Close();
        }
    }
}
