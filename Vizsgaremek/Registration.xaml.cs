﻿using System;
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
	public partial class Registration : Window
	{
		private Database database;
        private HashSet<string> favoriteMangas = new HashSet<string>();
        public Registration()
		{
			InitializeComponent();
			database = new Database();
		}

		private void OpenFooldal_Click(object sender, RoutedEventArgs e)
		{
			Fooldal fooldal = new Fooldal();
			fooldal.ShowDialog();
		}
        private void FavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            string mangaTitle = button.Tag.ToString();
            Image? img = button.Content as Image;

            if (favoriteMangas.Contains(mangaTitle))
            {
                favoriteMangas.Remove(mangaTitle);
                img.Source = new BitmapImage(new Uri("Images/heart_empty.png", UriKind.Relative));
            }
            else
            {
                favoriteMangas.Add(mangaTitle);
                img.Source = new BitmapImage(new Uri("Images/heart_filled.png", UriKind.Relative));
            }
        }
    }
}
