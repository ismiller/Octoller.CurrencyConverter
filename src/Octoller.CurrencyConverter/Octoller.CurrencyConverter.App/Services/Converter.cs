using Octoller.CurrencyConverter.App.Infrastructure.Models;

namespace Octoller.CurrencyConverter.App.Services
{
    /// <summary>
    /// Предоставляет метод конвертации из одной валюты в другую.
    /// </summary>
    public static class Converter
    {
        private readonly static int decimals = 2;

        /// <summary>
        /// Конвертирует указанное колличество одной валюты в другую. 
        /// </summary>
        /// <param name="convertItem">Количество конвертируеммой валюты.</param>
        /// <param name="from">Катировка по первой валюте.</param>
        /// <param name="there">Катировка по второй валюте.</param>
        /// <returns>Результат конвертации.</returns>
        public static decimal Convert(decimal convertItem, FinancialQuote from, FinancialQuote there)
        {
            if (convertItem == 0)
            {
                return 0;
            }

            var firstC = from.Quotation.UnitQuotation();
            var secondC = there.Quotation.UnitQuotation();

            var summ = firstC * convertItem;

            return decimal.Round(summ / secondC, decimals);
        }
    }
}
