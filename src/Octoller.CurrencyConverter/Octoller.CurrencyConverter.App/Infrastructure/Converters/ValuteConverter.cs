using Octoller.CurrencyConverter.App.Infrastructure.Models;
using System;
using Windows.UI.Xaml.Data;

namespace Octoller.CurrencyConverter.App.Infrastructure.Converters
{
    public class ValuteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language) =>
            (value is Valute valute) ? $"{valute.Name} \n {valute.CharCode}" : string.Empty;

        public object ConvertBack(object value, Type targetType, object parameter, string language) =>
            default;
    }
}
