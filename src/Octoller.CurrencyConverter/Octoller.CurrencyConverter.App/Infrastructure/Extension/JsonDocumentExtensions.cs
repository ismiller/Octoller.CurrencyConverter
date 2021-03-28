using System.Text.Json;

namespace Octoller.CurrencyConverter.App.Infrastructure.Extension
{
    /// <summary>
    /// Расширение парсинга для <see cref="JsonElement"/>.
    /// </summary>
    public static class JsonDocumentExtensions
    {
        /// <summary>
        /// Получает строковое значение указанного свойства <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="element"><see cref="JsonElement"/>.</param>
        /// <param name="key">Имя свойства.</param>
        /// <returns>Значение свойства.</returns>
        public static string GetElement(this JsonElement element, string key)
        {
            if (element.TryGetProperty(key, out JsonElement property) && property.ValueKind != JsonValueKind.Null)
            {
                return property.ToString();
            }

            return string.Empty;
        }
    }
}
