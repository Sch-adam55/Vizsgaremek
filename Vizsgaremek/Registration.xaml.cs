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
	public partial class Registration : Window
	{
		private Database database;
		public Registration()
		{
			InitializeComponent();
			database = new Database();
		}
		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			string email = EmailTextBox.Text.Trim();
			string username = UsernameTextBox.Text.Trim();
			string password = PasswordTextBox.Password.Trim();

			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("Minden mezőt ki kell tölteni!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			bool success = dbHelper.RegisterUser(email, username, password);
			if (success)
			{
				MessageBox.Show("Sikeres regisztráció!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
				this.Close(); 
			}
			else
			{
				MessageBox.Show("Hiba történt a regisztráció során!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
