using Octoller.CurrencyConverter.App.Infrastructure.Models;

namespace Octoller.CurrencyConverter.App.Services
{
    public static class Converter
    {
        private readonly static int decimals = 2;

        public static decimal Convert(decimal convertItem, FinancialQuote firstQuote, FinancialQuote secondQuote)
        {
            if (convertItem == 0)
            {
                return 0;
            }

            var firstC = firstQuote.Quotation.UnitQuotation();
            var secondC = secondQuote.Quotation.UnitQuotation();

            var summ = firstC * convertItem;

            return decimal.Round(summ / secondC, decimals);
        }
    }
}
