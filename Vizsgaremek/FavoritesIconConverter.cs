using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Vizsgaremek
{
    public class FavoriteIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isFavorite)
            {
                return isFavorite
                    ? new BitmapImage(new Uri("/Images/heart_filled.png", UriKind.Relative))
                    : new BitmapImage(new Uri("/Images/heart_empty.png", UriKind.Relative));
            }
            return new BitmapImage(new Uri("/Images/heart_empty.png", UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
