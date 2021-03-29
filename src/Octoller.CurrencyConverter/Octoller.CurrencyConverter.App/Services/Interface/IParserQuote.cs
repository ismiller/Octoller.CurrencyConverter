using System.Text.Json;

namespace Octoller.CurrencyConverter.App.Services.Interface
{
    /// <summary>
    /// Предоставляет интерфейс парсинга <see cref="JsonDocument"/> 
    /// с записью в указанную коллекцию.
    /// </summary>
    /// <typeparam name="TCollection">Коллекция данных.</typeparam>
    public interface IParserQuote<TCollection> where TCollection : new()
    {
        /// <summary>
        /// Производит парсинг <see cref="JsonDocument">.
        /// </summary>
        /// <param name="jsonQuote"><see cref="JsonDocument">.</param>
        /// <returns>Заданную коллекцию полученных объектов.</returns>
        TCollection Parse(JsonDocument jsonQuote);
    }
}