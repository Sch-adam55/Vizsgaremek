using System;
using System.Collections.Generic;
using System.Diagnostics;
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
<<<<<<< HEAD
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            OpenRegistration();
        }
        public void OpenRegistration()
        {
            Registration registrationWindow = new Registration();
            registrationWindow.ShowDialog();

        }
        public void OpenRegistration(object sender, RoutedEventArgs e)
        {
            Registration registrationWindow = new Registration();
            registrationWindow.ShowDialog();
        }

=======
	public partial class Profile : Window
	{
		private Database database;
        private HashSet<string> favoriteMangas = new HashSet<string>();
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
            }
        }
>>>>>>> 28dd3f46719ca737479d2eca067b4d21cffb2c17
    }
}
