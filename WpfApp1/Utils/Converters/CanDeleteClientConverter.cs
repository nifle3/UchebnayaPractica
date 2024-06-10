using System.Globalization;
using System.Windows.Data;
using WpfApp1.Model;

namespace WpfApp1.Utils.Converters;

public sealed class CanDeleteClientConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not Client client)
            return false;

        return !client.Suggestions.Any() && client.Needs.Any();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}