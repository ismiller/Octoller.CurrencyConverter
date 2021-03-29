using System;
using Windows.UI.Xaml.Data;

namespace Octoller.CurrencyConverter.App.Infrastructure.Converters
{
    public class DecimalConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, string language) =>
            (value is decimal d) ? d.ToString("F4") : string.Empty;

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, string language) =>
            (value is string s && decimal.TryParse(s, out var d)) ? d : 0;
    }
}
