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
    public partial class FavoritesWindow : Fooldal
    {
        private List<string> favoriteManga;

        public FavoritesWindow(List<string> favorites)
        {
            InitializeComponent();
            favoriteManga = favorites;
            FavoriteList.ItemsSource = favoriteManga;
        }

        private void RemoveFromFavorites_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var mangaTitle = (button.DataContext as string);
                if (mangaTitle != null)
                {
                    favoriteManga.Remove(mangaTitle);
                    FavoriteList.ItemsSource = null;
                    FavoriteList.ItemsSource = favoriteManga; 
                }
            }
        }
    }
}
