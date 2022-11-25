using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace ACT_3BIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string typeLoge;
        bool reservation;
        int nbrPersonnes;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void checkedChalet(object sender, RoutedEventArgs e)
        {
            typeLoge = "chalet";
        }

        private void checkedTente(object sender, RoutedEventArgs e)
        {
            typeLoge = "tente";
        }

        private void checkedReservation(object sender, RoutedEventArgs e)
        {
            reservation = true;
        }

        private bool estEntier(string textuser)
        {
            return int.TryParse(textuser, out int nbr);
        }

        private void PreviewNbrPersonne(object sender, TextCompositionEventArgs e)
        {
            if (!estEntier(e.Text))
            {
                e.Handled = true;
            }
            else if(estEntier(e.Text))
            {
                nbrPersonnes = Int32.Parse(e.Text);
                if (nbrPersonnes <= 6)
                {
                     
                    if(((TextBox)sender).Text.IndexOf(e.Text) > -1 || nbrPersonnes == 0)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
            
        }
        

        private void previewDA(object sender, TextCompositionEventArgs e)
        {
            if(estEntier(e.Text) || e.Text == "/")
            {
                e.Handled = false;
            }
            else if(e.Text == "," || !estEntier(e.Text) || e.Text == "-")
            {
                e.Handled = true;
            }

        }

        private void previewDS(object sender, TextCompositionEventArgs e)
        {
            if (estEntier(e.Text) || e.Text == "/")
            {
                e.Handled = false;
            }
            else if (e.Text == "," || !estEntier(e.Text) || e.Text == "-")
            {
                e.Handled = true;
            }

        }

        private void clickCalcDuree(object sender, RoutedEventArgs e)
        {
            DateTime da;
            DateTime ds;

            if(DateTime.TryParse(txtDa.Text, out da) && DateTime.TryParse(txtDs.Text, out ds))
            {
                int daMois = da.Month;
                int daJours = da.Day;
                int daAnnee = da.Year;
                int dsMois = ds.Month;
                int dsJours = ds.Day;
                int dsAnnee = ds.Year;

               

                if(daMois == 7 && dsMois == 7 || daMois == 8 && dsMois == 8 || daMois == 7 && dsMois == 8 || daMois == 12 && dsMois == 12  || daMois == 1 && dsMois == 1 || daMois == 12 && dsMois == 1 || daMois == 4 && dsMois == 4 && dsAnnee == daAnnee || daAnnee == dsAnnee -1)
                {
                    TimeSpan nbrJours;
                    nbrJours = ds - da;
                    int nbrSemaines = (int)(nbrJours.TotalDays / 7);
                    if(nbrJours.TotalDays % 7 != 0)
                    {
                        nbrSemaines += 1;
                    }
                    tbNbrSemaine1.Text = nbrSemaines.ToString();
                    tbNbrSemaineAffiche.Text = nbrSemaines.ToString();
                    MessageBox.Show(" Calcule du nombre de semaines effectué ! ");
                }
                else
                {
                    MessageBox.Show("Les dates sont incorrects !");
                }
            }
            else
            {
                MessageBox.Show("Les dates entrées ne sont pas dans autorisé pour la reservation.");
            }
        }
    }
}
