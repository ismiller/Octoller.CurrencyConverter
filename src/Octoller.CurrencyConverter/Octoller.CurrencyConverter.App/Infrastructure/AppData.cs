using System.Collections.Generic;

namespace Octoller.CurrencyConverter.App.Infrastructure
{
    public static class AppData
    {
        public static class ValuteCharCodes
        {
            public static IEnumerable<string> Codes = new List<string>
            {
                "AUD", "AZN", "GBP", "AMD", "BYN", "BGN", "BRL",
                "HUF", "HKD", "DKK", "USD", "EUR", "INR", "KZT",
                "CAD", "KGS", "CNY", "MDL", "NOK", "PLN", "RON",
                "XDR", "SGD", "TJS", "TRY", "TMT", "UZS", "UAH",
                "CZK", "SEK", "CHF", "ZAR", "KRW", "JPY"
            };
        }
    }
}
