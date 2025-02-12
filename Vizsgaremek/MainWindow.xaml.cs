using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vizsgaremek
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MangaList();
        }

        private void MangaList()
        {
            for (int i = 1; i <= 5; i++)
            {
                var stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(10) };
                var image = new Image
                {
                    Width = 50,
                    Height = 50,
                    Source = new BitmapImage(new Uri("placeholder.jpg", UriKind.Relative))
                };
                var textBlock = new TextBlock
                {
                    Text = $"Manga {i} - Season {i}",
                    Foreground = Brushes.White,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                stackPanel.Children.Add(image);
                stackPanel.Children.Add(textBlock);
                MangaList.Items.Add(stackPanel);
            }
        }
        private void OpenProfileWindow(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
        }
    }
}