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
	public partial class Fooldal : Window
	{
        private HashSet<string> favoriteMangas = new HashSet<string>();
        public Fooldal()
		{
			InitializeComponent();
<<<<<<< HEAD
			OpenProfile_Click();
		}
		public void OpenProfile_Click()
		{
            Console.WriteLine("Profile button clicked");
=======
>>>>>>> 28dd3f46719ca737479d2eca067b4d21cffb2c17
		}

		private void OpenProfile_Click(object sender, RoutedEventArgs e)
		{
			Profile profile = new Profile();
			profile.ShowDialog();
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
    }
}
