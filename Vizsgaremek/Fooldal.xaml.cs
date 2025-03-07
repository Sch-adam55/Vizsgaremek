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
		private List<string> favoriteManga = new List<string>();
		public Fooldal()
		{
			InitializeComponent();
			OpenProfile_Click();
		}
		public void OpenProfile_Click()
		{
			throw new NotImplementedException();
		}

		private void OpenProfile_Click(object sender, RoutedEventArgs e)
		{
			Profile profileWindow = new Profile();
			profileWindow.ShowDialog();
		}
		private void FavoriteButton_Click(object sender, RoutedEventArgs e)
		{
			if (sender is Button button && button.Content is Image heartImage)
			{
				string currentSource = heartImage.Source.ToString();
				var textBlock = ((StackPanel)button.Parent).Children.OfType<TextBlock>().FirstOrDefault();
				if (textBlock != null)
				{
					string title = textBlock.Text;

					if (currentSource.Contains("heart_empty.png"))
					{
						heartImage.Source = new BitmapImage(new Uri("Images/heart_filled.png", UriKind.Relative));
						favoriteManga.Add(title);
					}
					else
					{
						heartImage.Source = new BitmapImage(new Uri("Images/heart_empty.png", UriKind.Relative));
						favoriteManga.Remove(title);
					}
				}
			}
		}
	}
}
