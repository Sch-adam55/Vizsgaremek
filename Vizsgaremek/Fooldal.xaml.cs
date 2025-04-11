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
        public static List<string> FavoriteMangas = new List<string>();
        private Favorites favorites;
        private Kezdooldal Kezdooldal;
        private Dictionary<string, Image> heartImages = new Dictionary<string, Image>();

        public Fooldal()
        {
            InitializeComponent();
            InitializeHeartImages();
            UpdateAllHeartIcons();
        }

        private void UpdateAllHeartIcons()
        {
            throw new NotImplementedException();
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

            var favorites = new Favorites(FavoriteMangas) { Owner = this };
            this.Hide();
            favorites.Closed += (s, args) => this.Show();
            favorites.Show();
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
        private void InitializeHeartImages()
        {
            heartImages.Add("My Hero Academia", Heart_MHA);
            heartImages.Add("One Piece", Heart_OP);
            heartImages.Add("Dandadan", Heart_DN);
            heartImages.Add("Demon Slayer", Heart_DS);
            heartImages.Add("Blue Lock", Heart_BL);
        }
        public void RemoveFavorite(string mangaTitle)
        {
            FavoriteMangas.Remove(mangaTitle);
            UpdateHeartIcons();
        }

        public List<string> GetFavorites()
        {
            return FavoriteMangas;
        }
        private void FavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string mangaName = button.Tag.ToString();
            Image heartImage = (button.Content as Image);

            if (FavoriteMangas.Contains(mangaName))
            {
                FavoriteMangas.Remove(mangaName);
                heartImage.Source = new BitmapImage(new Uri("/Images/heart_empty.png", UriKind.Relative));
            }
            else
            {
                FavoriteMangas.Add(mangaName);
                heartImage.Source = new BitmapImage(new Uri("/Images/heart_filled.png", UriKind.Relative));
            }
        }

        private void UpdateHeartIcons(string mangaName, Image image)
        {
            throw new NotImplementedException();
        }

        private void UpdateHeartIcons()
        {
            foreach (var manga in FavoriteMangas)
            {
                var image = FindName($"Heart{GetMangaIndex(manga.Key)}") as Image;
                if (image != null)
                {
                    image.Source = new BitmapImage(new Uri(manga.Value ?
                        "/Images/heart_filled.png" : "/Images/heart_empty.png", UriKind.Relative));
                }
            }
        }

        private object GetMangaIndex(object key)
        {
            throw new NotImplementedException();
        }

        private int GetMangaIndex(string mangaName)
        {
            return mangaName switch
            {
                "My Hero Academia" => 1,
                "One Piece" => 2,
                "Dandadan" => 3,
                "Demon Slayer" => 4,
                "Blue Lock" => 5,
                _ => 0
            };
        }
    }
}
    

