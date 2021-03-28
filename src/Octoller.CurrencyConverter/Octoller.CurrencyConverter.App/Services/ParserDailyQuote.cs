using Octoller.CurrencyConverter.App.Infrastructure;
using Octoller.CurrencyConverter.App.Infrastructure.Models;
using Octoller.CurrencyConverter.App.Infrastructure.Extension;
using Octoller.CurrencyConverter.App.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Octoller.CurrencyConverter.App.Services
{
    /// <summary>
    /// Реализация интерфейса <see cref="IParserQuote{TCollection}" /> 
    /// для коллекции <see cref="QuotationСollection" />.
    /// </summary>
    public class ParserDailyQuote : IParserQuote<QuotationСollection>
    {
        public ParserDailyQuote() { }

        /// <inheritdoc />
        public QuotationСollection Parse(JsonDocument jsonQuote)
        {
            var quotes = new QuotationСollection();

            var root = jsonQuote.RootElement;
            var valutesDocument = root.GetProperty("Valute");

            var financialQuotes = SplitValute(valutesDocument)
                .Select(valute => Cast(valute));

            foreach (var quote in financialQuotes)
            {
                quotes.Add(quote);
            }

            return quotes;
        }

        private IEnumerable<JsonElement> SplitValute(JsonElement jsonValutes) =>
            AppData.ValuteCharCodes.Codes
                .Select(code => jsonValutes.GetElement(code))
                .Where(valute => !string.IsNullOrEmpty(valute))
                .Select(valute => JsonDocument.Parse(valute).RootElement);

        private FinancialQuote Cast(JsonElement jsonValute)
        {
            var id = jsonValute.GetProperty("ID").GetString();

            var valute = new Valute
            {
                ID = id,
                Name = jsonValute.GetProperty("Name").GetString(),
                CharCode = jsonValute.GetProperty("CharCode").GetString(),
                NumCode = jsonValute.GetProperty("NumCode").GetString()
            };

            var quotation = new Quotation 
            {
                ValuteID = id
            };

            if (jsonValute.GetProperty("Nominal").TryGetInt32(out var nominal))
            {
                quotation.Nominal = nominal;
            }

            if (jsonValute.GetProperty("Value").TryGetDecimal(out decimal value))
            {
                quotation.Value = value;
            }

            return new FinancialQuote
            {
                Valute = valute,
                Quotation = quotation
            };
        }
    }
}
