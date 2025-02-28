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
using Vizsgaremek;

namespace Vizsgaremek
{
    public class ProfileWindow : MainWindow
    {
		public ProfileWindow()
		{
			OpenRegistrationWindow();
		}

		public void OpenRegistrationWindow()
		{
			throw new NotImplementedException();
		}
		public void OpenRegistrationWindow(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }

		internal void ShowDialog()
		{
			throw new NotImplementedException();
		}
	}
}


