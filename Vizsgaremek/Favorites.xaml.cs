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
    public partial class Favorites : Window
    {
        private List<string> favoriteManga;

        public Favorites(List<string> favorites)
        {
            InitializeComponent();
			favoriteManga = favorites;
       
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
                 
                }
            }
        }
    }
}
