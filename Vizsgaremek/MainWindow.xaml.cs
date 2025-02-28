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
    public partial class MainWindow
    {
		public MainWindow()
		{
			InitializeComponent();
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
	
		private void OpenProfileWindow_Click(object sender, RoutedEventArgs e)
		{
			ProfileWindow profileWindow = new ProfileWindow();
			profileWindow.ShowDialog();
		}
	}
}