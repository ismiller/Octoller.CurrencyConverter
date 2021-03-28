using Octoller.CurrencyConverter.App.Infrastructure.Models.Interface;

namespace Octoller.CurrencyConverter.App.Infrastructure.Models
{
    /// <summary>
    /// Объект катировки по заданной валюте
    /// </summary>
    public class FinancialQuote : IFinancialQuote<Quotation, Valute> 
    {
        ///<inheritdoc />
        public Quotation Quotation { get; set; }

        ///<inheritdoc />
        public Valute Valute { get; set; }
    }
}
