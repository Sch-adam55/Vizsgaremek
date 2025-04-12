using Mysqlx.Crud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        private Kezdooldal kezdooldal;
        private Fooldal fooldal;


        public Favorites(List<string> favoriteMangas)
        {
            InitializeComponent();
            LoadFavorites();

        }
        private void OpenKezdooldal(object sender, RoutedEventArgs e)
        {
            var kezdooldal = Application.Current.Windows.OfType<Kezdooldal>().FirstOrDefault();

            if (kezdooldal == null)
            {
                kezdooldal = new Kezdooldal();
            }

            kezdooldal.Show();
            kezdooldal.WindowState = WindowState.Normal;
            kezdooldal.Focus();

            this.Close();
        }
        private void OpenRegistration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }
        private void OpenFooldal_Click(object sender, RoutedEventArgs e)
        {
            var fooldal = Application.Current.Windows.OfType<Fooldal>().FirstOrDefault();

            if (fooldal == null)
            {
                fooldal = new Fooldal();
            }

            fooldal.Show();
            fooldal.WindowState = WindowState.Normal;
            fooldal.Focus();

            this.Close();
        }

        private void LoadFavorites()
        {
            FavoritesListBox.Items.Clear();

            foreach (string mangaName in Fooldal.favoriteMangas)
            {
                ListBoxItem item = new ListBoxItem();
                TextBlock textBlock = new TextBlock
                {
                    Text = mangaName,
                    Foreground = System.Windows.Media.Brushes.Black,
                    FontSize = 16,
                    Margin = new Thickness(10)
                };

                item.Content = textBlock;
                FavoritesListBox.Items.Add(item);
            }
        }

        private BitmapImage GetMangaImage(string mangaName)
        {
            string imagePath = mangaName switch
            {
                "My Hero Academia" => "/Images/MHA.png",
                "One Piece" => "/Images/OP.png",
                "Dandadan" => "/Images/DD.png",
                "Demon Slayer" => "/Images/DS.png",
                "Blue Lock" => "/Images/BL.png",
                _ => "/Images/default.png"
            };
            return new BitmapImage(new Uri(imagePath, UriKind.Relative));
        }
    }
}
