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

namespace Vizsgaremek
{
    public partial class Kezdooldal : Window
    {
        private Fooldal fooldal;
        public Kezdooldal()
        {
            InitializeComponent();
        }

        private void OpenMangaList(object sender, RoutedEventArgs e)
        {
            
            if (Application.Current.Windows.OfType<Fooldal>().Any())
            {
                Application.Current.Windows.OfType<Fooldal>().First().Focus();
                return;
            }

            var fooldal = new Fooldal { Owner = this };
            this.Hide();
            fooldal.Closed += (s, args) => this.Show();
            fooldal.Show();
        }
       

        private void OpenRegistration(object sender, RoutedEventArgs e)
		{
			Registration registration = new Registration();
			registration.ShowDialog();
		}

		private void OpenProfile(object sender, RoutedEventArgs e)
		{
			Profile profile = new Profile();
			profile.ShowDialog();
		}
    }
}
