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
    public partial class Fooldal : Window 
    {
        public static List<string> favoriteMangas = new List<string>();
       
        public static ObservableCollection<object> FavoriteItems { get; } = new ObservableCollection<object>();

        private Favorites favorites;
        private Kezdooldal kezdooldal;
        public Fooldal()
        {
            InitializeComponent();
            
        }
        
        public void UpdateUsername(string username)
        {
            UsernameDisplay.Text = username;
            UsernameDisplay.Visibility=Visibility.Visible;
            LoginButton.Visibility=Visibility.Collapsed;

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
            if (Application.Current.Windows.OfType<Favorites>().Any())
            {
                Application.Current.Windows.OfType<Favorites>().First().Focus();
                return;
            }

            var favorites = new Favorites(favoriteMangas) { Owner = this };
            this.Hide();
            favorites.Closed += (s, args) => this.Show();
            favorites.Show();
        }
        private void MHA_Click(object sender, RoutedEventArgs e)
        {
            Chapter chapterPage = new Chapter();
            this.Content = chapterPage; 
        }
        private void OP_Click(object sender, RoutedEventArgs e)
        {
            Chapter1 chapterPage1 = new Chapter1();
            this.Content = chapterPage1;
        }
        private void DN_Click(object sender, RoutedEventArgs e)
        {
            Chapter2 chapterPage2 = new Chapter2();
            this.Content = chapterPage2;
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();
            var items = new[] { Manga1, Manga2, Manga3, Manga4, Manga5 };
            var textBlocks = new[] { MangaName1, MangaName2, MangaName3, MangaName4, MangaName5 };

            for (int i = 0; i < items.Length; i++)
            {
                
                var firstRun = textBlocks[i].Inlines.FirstInline as Run;
                var mangaName = firstRun?.Text.ToLower() ?? "";

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
        private async void FavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.IsEnabled = false; // Gomb letiltása kattintáskor

            await Task.Run(() => // Aszinkron kezelés a UI fagyás megelőzésére
            {
                Dispatcher.Invoke(() => // UI thread-en végrehajtás
                {
                    try
                    {
                        var listBoxItem = FindParent<ListBoxItem>(button);
                        if (listBoxItem != null && listBoxItem.Content != null)
                        {
                            if (FavoriteItems.Contains(listBoxItem.Content))
                            {
                                FavoriteItems.Remove(listBoxItem.Content);
                                ((Image)button.Content).Source = new BitmapImage(
                                    new Uri("/Images/heart_empty.png", UriKind.Relative));
                            }
                            else
                            {
                                FavoriteItems.Add(listBoxItem.Content);
                                ((Image)button.Content).Source = new BitmapImage(
                                    new Uri("/Images/heart_filled.png", UriKind.Relative));
                            }
                        }
                    }
                    finally
                    {
                        button.IsEnabled = true; // Gomb újra engedélyezése
                    }
                });
            });
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
       

        public class MangaItem
        {
            public string Name { get; set; }
            public string ImagePath { get; set; }
            public string ChapterInfo { get; set; }
        }
    }

}

    

