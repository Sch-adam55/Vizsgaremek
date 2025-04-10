using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Favorites : Window
    {
        private List<string> favoriteMangas;

        public Favorites(List<string> favoriteMangas)
        {
            InitializeComponent();
            this.favoriteMangas = favoriteMangas;
            LoadFavorites();
          
        }

        private void OpenProfile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.ShowDialog();
        }
        private void OpenFooldal_Click(object sender, RoutedEventArgs e)
        {
            Fooldal fooldal = new Fooldal();
            fooldal.ShowDialog();
        }

        private void LoadFavorites()
        {
            FavoritesListBox.Items.Clear();
            foreach (var mangaTitle in favoriteMangas)
            {
                ListBoxItem item = new ListBoxItem();
                StackPanel panel = new StackPanel { Orientation = Orientation.Horizontal };

                TextBlock mangaText = new TextBlock
                {
                    Text = mangaTitle,
                    Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White),
                    VerticalAlignment = VerticalAlignment.Center
                };
                panel.Children.Add(mangaText);

                Image heartImage = new Image
                {
                    Source = new BitmapImage(new Uri("Images/heart_filled.png", UriKind.Relative)),
                    Width = 20,
                    Height = 20,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                panel.Children.Add(heartImage);

                item.Content = panel;
                FavoritesListBox.Items.Add(item); 
            }
        }
    }
}
