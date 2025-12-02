public class BoolToFavoriteTextConverter {}
using System.Globalization;

namespace FindYourHome.Converters;

public class BoolToFavoriteTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isFavorite = (bool)value;
        return isFavorite ? "Retirer des favoris" : "Ajouter aux favoris";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return false;
    }
}
