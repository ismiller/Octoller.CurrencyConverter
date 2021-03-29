using Octoller.CurrencyConverter.App.Infrastructure.Models;
using Octoller.CurrencyConverter.App.Services.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Octoller.CurrencyConverter.App.Services
{
    /// <inheritdoc />
    public class QuotationСollection : IEnumerable<FinancialQuote>, IQuotationСollection<FinancialQuote, Quotation, Valute>
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

        /// <inheritdoc />
        public IEnumerator<FinancialQuote> GetEnumerator() =>
            quotes.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();
    }
}
