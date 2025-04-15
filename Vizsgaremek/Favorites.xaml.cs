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
            Dispatcher.BeginInvoke(new Action(() =>
            {
                FavoritesList.ItemsSource = Fooldal.FavoriteItems;
            }), System.Windows.Threading.DispatcherPriority.Background);

            FavoritesList.DataContext = Fooldal.FavoriteItems;

            FavoritesList.Loaded += (s, e) =>
            {
                foreach (var item in FavoritesList.Items)
                {
                    var container = FavoritesList.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                    if (container != null)
                    {
                        var border = VisualTreeHelper.GetChild(container, 0) as Border;
                        if (border != null)
                        {
                            var contentPresenter = VisualTreeHelper.GetChild(border, 0) as ContentPresenter;
                            if (contentPresenter != null)
                            {
                                var grid = VisualTreeHelper.GetChild(contentPresenter, 0) as Grid;
                                if (grid != null)
                                {
                                    foreach (var child in grid.Children)
                                    {
                                        if (child is Button button && button.Tag != null)
                                        {
                                            button.Click += FavoriteButton_Click;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
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
            // Ugyanaz a logika, mint a főoldalon
            Button button = (Button)sender;
            var listBoxItem = FindParent<ListBoxItem>(button);

            if (listBoxItem != null && listBoxItem.Content != null)
            {
                Fooldal.FavoriteItems.Remove(listBoxItem.Content);
                ((Image)button.Content).Source = new BitmapImage(new Uri("/Images/heart_empty.png", UriKind.Relative));
            }
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
