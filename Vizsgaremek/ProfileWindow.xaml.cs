using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    public class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            Title = "Profil";
            Width = 400;
            Height = 300;
            Background = Brushes.DarkGray;

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            grid.RowDefinitions.Add(new RowDefinition());

            var topBar = new TextBlock
            {
                Text = "Profil",
                Foreground = Brushes.Black,
                Background = Brushes.White,
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetRow(topBar, 0);
            grid.Children.Add(topBar);

            var loginText = new TextBlock
            {
                Text = "Bejelentkezés / Profil létrehozása",
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10)
            };
            Grid.SetRow(loginText, 1);
            grid.Children.Add(loginText);

            Content = grid;
        }
        private void OpenProfileWindow(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.ShowDialog();
        }
    }
}


