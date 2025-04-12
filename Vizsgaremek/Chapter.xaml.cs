using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Vizsgaremek
{
    public partial class Chapter : Page
    {
        private Fooldal Fooldal;
        public Chapter()
        {
            InitializeComponent();
            
        }
        private void OpenFooldal_Click(object sender, RoutedEventArgs e)
        {
            Fooldal fooldal = Application.Current.Windows.OfType<Fooldal>().FirstOrDefault();

            if (fooldal != null)
            {
                fooldal.WindowState = WindowState.Normal;
                fooldal.Activate();
                fooldal.Focus();
            }

            Window currentWindow = Window.GetWindow(this);
            currentWindow?.Close();
        }
        private void Manga_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string mangaType = clickedButton.Tag.ToString();

            // Létrehozzuk a Chapter oldalt
            Chapter chapterPage = new Chapter();

            // Beállítjuk a megfelelő tartalmat
            switch (mangaType)
            {
                case "MHA":
                    chapterPage.LoadMangaContent(
                        "My Hero Academia",
                        new List<string> { "/Chapter/MHA/1.png", "/Chapter/MHA/2.png", "/Chapter/MHA/3.png" });
                    break;
                case "OP":
                    chapterPage.LoadMangaContent(
                        "One Piece",
                        new List<string> { "/Chapter/OP/1.png", "/Chapter/OP/2.png", "/Chapter/OP/3.png" });
                    break;
            }

            // Navigálás
            this.NavigationService.Navigate(chapterPage);
        }

        private void LoadMangaContent(string v, List<string> list)
        {
            throw new NotImplementedException();
        }
    }
}
