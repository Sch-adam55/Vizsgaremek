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
	public partial class Profile : Window
	{
		private Database database;
		public Profile()
		{
			InitializeComponent();
			database = new Database();
		}

		private void OpenFooldal_Click(object sender, RoutedEventArgs e)
		{
			Fooldal fooldal = new Fooldal();
			fooldal.ShowDialog();
		}
		public void OpenRegistration(object sender, RoutedEventArgs e)
		{
			Registration registrationWindow = new Registration();
			registrationWindow.ShowDialog();
		}

	}
}
