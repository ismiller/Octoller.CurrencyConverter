using Octoller.CurrencyConverter.App.Infrastructure.Data;
using System;
using System.Collections.Generic;

namespace Octoller.CurrencyConverter.App.Infrastructure.Services
{
    /// <inheritdoc />
    public class QuotationСollection : IQuotationСollection<FinancialQuote, Quotation, Valute>
    {
        private IDictionary<string, FinancialQuote> quotes
            = new Dictionary<string, FinancialQuote>();

        /// <inheritdoc />
        public void Add(FinancialQuote quote)
        {
            var valuteCode = quote.Valute.CharCode;

            if (quotes.ContainsKey(valuteCode))
            {
                throw new ArgumentException(nameof(quote));
            }

            quotes.Add(valuteCode, quote);
        }

        /// <inheritdoc />
        public void UpdateQuote(FinancialQuote quote)
        {
            var valuteCode = quote.Valute.CharCode;

            if (!quotes.ContainsKey(valuteCode))
            {
                quotes.Remove(valuteCode);
            }

            quotes.Add(valuteCode, quote);
        }

        /// <inheritdoc />
        public bool TryGetQuote(string charCodeValute, out FinancialQuote quote) =>
            quotes.TryGetValue(charCodeValute, out quote);
    }
}
