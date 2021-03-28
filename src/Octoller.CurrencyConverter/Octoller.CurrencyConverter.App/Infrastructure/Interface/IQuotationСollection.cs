using Octoller.CurrencyConverter.App.Infrastructure.Data.Interface;

namespace Octoller.CurrencyConverter.App.Infrastructure.Services
{
    /// <summary>
    /// Описывает коллекцию данных котировок
    /// </summary>
    /// <typeparam name="TFinancialQuote"></typeparam>
    /// <typeparam name="TQuote"></typeparam>
    /// <typeparam name="TValute"></typeparam>
    public interface IQuotationСollection<TFinancialQuote, TQuote, TValute> 
        where TQuote : IQuote where TValute : IValute
        where TFinancialQuote : IFinancialQuote<TQuote, TValute>
    {
        /// <summary>
        /// Добовляет объект котировки в коллецию.
        /// </summary>
        /// <param name="quote">Новый объект котировки.</param>
        void Add(TFinancialQuote quote);

        /// <summary>
        /// Предоставляет объект котировки в коллецию по буквенному ключу валюты, если есть.
        /// </summary>
        /// <param name="charCodeValute">Буквенный код валюты.</param>
        /// <param name="quote">Хранит найденный объект котировки.</param>
        /// <returns><see langword="true"/> если есть.</returns>
        bool TryGetQuote(string charCodeValute, out TFinancialQuote quote);

        /// <summary>
        /// Обновляет уже записанный в коллекцию объект котировки.
        /// </summary>
        /// <param name="quote">Новый объект котировки.</param>
        void UpdateQuote(TFinancialQuote quote);
    }
}