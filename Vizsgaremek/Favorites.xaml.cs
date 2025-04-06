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
        public Favorites(HashSet<string> favorites)
        {
            InitializeComponent();

            foreach (var manga in favorites)
            {
                TextBlock tb = new TextBlock
                {
                    Text = manga,
                    Foreground = Brushes.White,
                    FontSize = 18,
                    Margin = new Thickness(10)
                };
                FavoritesPanel.Children.Add(tb);
            }
        }
        private void OpenFooldal_Click(object sender, RoutedEventArgs e)
        {
            Fooldal fooldal = new Fooldal();
            fooldal.ShowDialog();
        }
    }
}
