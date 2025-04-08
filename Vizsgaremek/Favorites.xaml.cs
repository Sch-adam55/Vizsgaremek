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
        public Favorites()
        {
            InitializeComponent();
            RefreshList();
            Fooldal.FavoriteMangaTitles.CollectionChanged += (s, e) => RefreshList();
        }

        public void RefreshList()
        {
            Dispatcher.Invoke(() =>
            {
                FavoritesList.ItemsSource = null;
                FavoritesList.ItemsSource = Fooldal.FavoriteMangaTitles;
            });
        }

        protected override void OnClosed(EventArgs e)
        {
            ((Fooldal)Owner)?._openFavoritesWindows?.Remove(this);
            base.OnClosed(e);
        }
    }
}
