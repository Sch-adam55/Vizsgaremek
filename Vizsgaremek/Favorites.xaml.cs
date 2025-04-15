using Mysqlx.Crud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using static Vizsgaremek.Fooldal;

namespace Vizsgaremek
{
    public partial class Favorites : Window
    {
        private List<Fooldal.MangaItem> favoriteMangas;
        private Kezdooldal kezdooldal;
        private Fooldal fooldal;
        private List<Fooldal.MangaItem> FavoriteMangas;
        public Favorites(List<Fooldal.MangaItem> favoriteMangas)
        {
            InitializeComponent();
            this.favoriteMangas = favoriteMangas;
            FavoritesList.ItemsSource = this.favoriteMangas;
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
        private void FavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var mangaItem = (Fooldal.MangaItem)button.DataContext;

           
            favoriteMangas.Remove(mangaItem);
            Fooldal.FavoriteItems.Remove(mangaItem);

            
            FavoritesList.Items.Refresh();
        }
        
        private static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(child);
            while (parent != null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as T;
        }
    }
}
