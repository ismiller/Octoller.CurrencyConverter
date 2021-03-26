namespace Octoller.CurrencyConverter.App.Infrastructure.Data.Interface
{
    public interface IFinancialQuote<TQuote, TValute> 
        where TQuote : IQuote
        where TValute : IValute
    {
        /// <summary>
        /// Объект котировки по валюте
        /// </summary>
        TQuote Quotation { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        TValute Valute { get; set; }
    }
}
