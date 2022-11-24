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
    }
}
