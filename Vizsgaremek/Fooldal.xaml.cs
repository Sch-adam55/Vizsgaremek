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
        private List<string> favoriteMangas = new List<string>();
        public Fooldal()
		{
			InitializeComponent();
        }

		private void OpenKezdooldal(object sender, RoutedEventArgs e)
		{
			Kezdooldal kezdooldal = new Kezdooldal();
			kezdooldal.ShowDialog();
		}
		private void OpenProfile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.ShowDialog();
        }
        private void OpenRegistration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }
        private void OpenFavorites_Click(object sender, RoutedEventArgs e)
        {
            Favorites favorites = new Favorites(favoriteMangas);
            favorites.ShowDialog();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();
            var items = new[] { Manga1, Manga2, Manga3, Manga4, Manga5 };
            var textBlocks = new[] { MangaName1, MangaName2, MangaName3, MangaName4, MangaName5 };

            for (int i = 0; i < items.Length; i++)
            {
                var mangaName = textBlocks[i].Text.ToLower();
                if (string.IsNullOrEmpty(searchText) || mangaName.Contains(searchText))
                {
                    items[i].Visibility = Visibility.Visible;
                }
                else
                {
                    items[i].Visibility = Visibility.Collapsed;
                }
            }
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
    

