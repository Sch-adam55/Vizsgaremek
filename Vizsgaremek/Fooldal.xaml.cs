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
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();
            foreach (ListBoxItem item in MangaList.Items)
            {
                var textBlock = (TextBlock)item.FindName("MangaName_" + item.Tag);
                var mangaName = textBlock?.Text.ToLower();

                if (!string.IsNullOrEmpty(mangaName) && mangaName.Contains(searchText))
                {
                    item.Visibility = Visibility.Visible;
                }
                else
                {
                    item.Visibility = Visibility.Collapsed;
                }
            }
        }

    }
}
    

