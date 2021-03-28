using System.Text.Json;

namespace Octoller.CurrencyConverter.App.Services.Interface
{
    /// <summary>
    /// Предоставляет интерфейс парсинга <see cref="JsonDocument"/> в указанную коллекцию данных.
    /// </summary>
    /// <typeparam name="TCollection">Коллекция данных.</typeparam>
    public interface IParserQuote<TCollection> where TCollection : new()
    {
        TCollection Parse(JsonDocument jsonQuote);
    }
}