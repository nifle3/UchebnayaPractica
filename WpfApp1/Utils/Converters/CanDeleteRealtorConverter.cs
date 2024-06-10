using System.Globalization;
using System.Windows.Data;
using WpfApp1.Model;

namespace WpfApp1.Utils.Converters;

public sealed class CanDeleteRealtorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not Realtor realtor)
            return false;
        
        return !realtor.Suggestions.Any() && !realtor.Needs.Any();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}