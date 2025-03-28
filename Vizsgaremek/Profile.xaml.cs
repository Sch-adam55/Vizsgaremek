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
			OpenRegistration();
			database = new Database();
		}
		public void OpenRegistration()
		{
			throw new NotImplementedException();
		}
		public void OpenRegistration(object sender, RoutedEventArgs e)
		{
			Registration registrationWindow = new Registration();
			registrationWindow.ShowDialog();
		}

		internal void ShowDialog()
		{
			throw new NotImplementedException();
		}

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			string username = txtUsername.Text;
			string password = txtPassword.Password;

			if (database.AuthenticateUser(username, password))
			{
				MessageBox.Show("Sikeres bejelentkezés!", "Üdv", MessageBoxButton.OK, MessageBoxImage.Information);
				Fooldal foolad= new Fooldal();
				foolad.Show();
				this.Close();
			}
			else
			{
				MessageBox.Show("Hibás felhasználónév vagy jelszó!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
