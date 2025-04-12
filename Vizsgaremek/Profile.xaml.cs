using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class Profile : Window
    {

        public Profile()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string profileName = ProfileNameTextBox.Text;
            string password = PasswordBox.Password;

            var httpClient = new HttpClient();
            var json = JsonSerializer.Serialize(new
            {
                profilename = profileName,
                password = password
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = httpClient.PostAsync("http://localhost:3000/auth/login", content).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Login successful, Welcome back " + profileName + " !");

                    if (Application.Current.Windows.OfType<Fooldal>().FirstOrDefault() is Fooldal fooldal)
                    {
                        fooldal.UpdateUsername(profileName);
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error at login. " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message);
            }
        }
    }
}
