using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
<<<<<<< HEAD  
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string profileName = ProfileNameTextBox.Text;
            string password = PasswordBox.Password;

            var httpClient = new HttpClient();
            var json = JsonSerializer.Serialize(new
            {
                email = email,
                profilename = profileName,
                password = password
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync("http://localhost:3000/auth/regist", content);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Registration successful!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error at registration. " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message);
=======
	public partial class Registration : Window
	{
		private Database database;
        private HashSet<string> favoriteMangas = new HashSet<string>();
        public Registration()
		{
			InitializeComponent();
			database = new Database();
		}

		private void OpenFooldal_Click(object sender, RoutedEventArgs e)
		{
			Fooldal fooldal = new Fooldal();
			fooldal.ShowDialog();
		}
        private void FavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            string mangaTitle = button.Tag.ToString();
            Image? img = button.Content as Image;

            if (favoriteMangas.Contains(mangaTitle))
            {
                favoriteMangas.Remove(mangaTitle);
                img.Source = new BitmapImage(new Uri("Images/heart_empty.png", UriKind.Relative));
            }
            else
            {
                favoriteMangas.Add(mangaTitle);
                img.Source = new BitmapImage(new Uri("Images/heart_filled.png", UriKind.Relative));
>>>>>>> 28dd3f46719ca737479d2eca067b4d21cffb2c17
            }
        }
    }
}
