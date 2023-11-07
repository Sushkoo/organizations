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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Organization> szervezetek = new List<Organization>();
        private void Betoltes(string org)
        {
            foreach (var sor in File.ReadAllLines(org).Skip(1))
            {
                szervezetek.Add(new Organization(sor.Split(';')));
            }
        }

            public MainWindow()
            {
                InitializeComponent();
                Betoltes("organizations-100.csv");
                dgAdatok.ItemsSource = szervezetek;

                cbOrszag.ItemsSource = szervezetek.Select(x => x.Country).OrderBy(x => x).Distinct().ToList();
                cbEv.ItemsSource = szervezetek.Select(x => x.Founded).OrderBy(x => x).Distinct().ToList();
                labTotalEmpl.Content = szervezetek.Sum(x => x.EmployeesNumber);


            }
            private void dgAdatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAdatok.SelectedItem is Organization)
            {
                Organization valaszottObjektum = dgAdatok.SelectedItem as Organization;
                labID.Content = valaszottObjektum.Id.ToString();
                labWEB.Content = valaszottObjektum.Website;
                labISM.Content = valaszottObjektum.Description;
            }
            else
            {
                MessageBox.Show("Hiba!");
            }
            int valasztottev = 10;
            dgAdatok.ItemsSource = szervezetek.Select(x => x.Country).Where(x=>x.)


        }


    }
    }
