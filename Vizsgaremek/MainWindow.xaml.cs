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
using Vizsgaremek;

namespace Vizsgaremek
{
    public partial class MainWindow : Window
    {
		public MainWindow()
		{
			InitializeComponent();
			OpenProfileWindow();
			OpenProfileWindow_Click();
		}

		public void OpenProfileWindow_Click()
		{
			throw new NotImplementedException();
		}

		public void InitializeComponent()
		{
			throw new NotImplementedException();
		}

		public void OpenProfileWindow()
		{
			ProfileWindow profileWindow = new ProfileWindow();
			profileWindow.Show();
		}
		private void OpenProfileWindow_Click(object sender, RoutedEventArgs e)
		{
			OpenProfileWindow();
		}
	}
}