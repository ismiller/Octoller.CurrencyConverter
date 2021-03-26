namespace Octoller.CurrencyConverter.App.Infrastructure.Data.Interface
{
    public interface IValute
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        string ID { get; set; }

        /// <summary>
        /// Цифровой код
        /// </summary>
        string NumCode { get; set; }

        /// <summary>
        /// Буквенный код
        /// </summary>
        string CharCode { get; set; }

        /// <summary>
        /// Имя валюты
        /// </summary>
        string Name { get; set; }
    }
}
