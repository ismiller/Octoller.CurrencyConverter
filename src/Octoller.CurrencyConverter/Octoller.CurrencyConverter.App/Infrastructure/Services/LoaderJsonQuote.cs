using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace Octoller.CurrencyConverter.App.Infrastructure.Services
{
    /// <summary>
    /// Выполняет загрузку данный по заданному адресу.
    /// </summary>
    public class LoaderJsonQuote
    {
        /// <summary>
        /// Предоставляет значение по умолчанию для базового адреса.
        /// </summary>
        public static Uri DefaultBaseUri => new Uri("https://www.cbr-xml-daily.ru");

        /// <summary>
        /// Предоставляет значение по умолчанию для относительного адреса адреса.
        /// </summary>
        public static string DefaultRelativeUri => "daily_json.js";

        /// <summary>
        /// Предоставляет учтановленное текущее для базового адреса адреса.
        /// </summary>
        public Uri CurrentBaseUri { get; private set; }

        /// <summary>
        /// Предоставляет учтановленное текущее для относительного адреса адреса.
        /// </summary>
        public string CurrentRelativeUri { get; private set; }

        private HttpClient Client { get; set; }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public LoaderJsonQuote() 
            : this (LoaderJsonQuote.DefaultBaseUri, LoaderJsonQuote.DefaultRelativeUri) { }

        /// <summary>
        /// Конструктор, устанавливающий базовый адресс запроса.
        /// </summary>
        /// <param name="baseAddress">Базовый адресс запроса, <see cref="Uri" />.</param>
        public LoaderJsonQuote(Uri baseAddress) 
            : this(baseAddress, LoaderJsonQuote.DefaultRelativeUri) { }

        /// <summary>
        /// Конструктор, устанавливающий базовый и относительный адресс запроса.
        /// </summary>
        /// <param name="baseAddress">Базовый адресс запроса, <see cref="Uri" />.</param>
        /// <param name="relativeAddress">Относительный адресс запроса, <see cref="string" />.</param>
        public LoaderJsonQuote(Uri baseAddress, string relativeAddress)  
        {
            CurrentBaseUri = baseAddress;
            CurrentRelativeUri = relativeAddress;

            Client = new HttpClient();
            Client.BaseAddress = CurrentBaseUri;
        }

        /// <summary>
        /// Выполняет загрузку данныx по установленному адресу и возвращает в формате <see cref="JsonDocument"/>.
        /// </summary>
        /// <returns>Загруженные данные, <see cref="JsonDocument" />.</returns>
        public JsonDocument Load()
        {
            var dailyString = Client.GetStringAsync(CurrentRelativeUri).Result;
            var dailyJson = JsonDocument.Parse(dailyString);

            return dailyJson;
        }

        /// <summary>
        /// Выполняет загрузку данныx по установленному относительному адресу 
        /// и возвращает в формате <see cref="JsonDocument"/>.
        /// </summary>
        /// <param name="relativeUri">Относительный адресс.</param>
        /// <returns>Загруженные данные, <see cref="JsonDocument" />.</returns>
        public JsonDocument Load(string relativeUri)
        {
            var dailyString = Client.GetStringAsync(relativeUri).Result;
            var dailyJson = JsonDocument.Parse(dailyString);

            return dailyJson;
        }
    }
}
