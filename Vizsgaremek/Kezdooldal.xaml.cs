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
        public Kezdooldal()
        {
            InitializeComponent();
        }

		private void OpenMangaList(object sender, RoutedEventArgs e)
		{
			Fooldal fooldal = new Fooldal();
			fooldal.ShowDialog();
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
