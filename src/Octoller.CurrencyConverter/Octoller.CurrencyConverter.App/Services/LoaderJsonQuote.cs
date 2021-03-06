using System;
using System.Text.Json;
using System.Net.Http;
using Octoller.CurrencyConverter.App.Services.Interface;
using System.Threading.Tasks;

namespace Octoller.CurrencyConverter.App.Services
{
    /// <summary>
    /// Выполняет загрузку данный по заданному адресу.
    /// </summary>
    public class LoaderJsonQuote : ILoaderJsonAsync, ILoaderJson
    {
        /// <summary>
        /// Предоставляет значение по умолчанию для базового адреса.
        /// </summary>
        public static Uri DefaultBaseUri => new Uri("https://www.cbr-xml-daily.ru");

        /// <summary>
        /// Предоставляет значение по умолчанию для относительного адреса адреса.
        /// </summary>
        public static string DefaultRelativeUri => "daily_json.js";

        /// <inheritdoc />
        public Uri CurrentBaseUri { get; private set; }

        /// <inheritdoc />
        public string CurrentRelativeUri { get; private set; }

        private HttpClient Client { get; set; }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public LoaderJsonQuote()
            : this(LoaderJsonQuote.DefaultBaseUri, LoaderJsonQuote.DefaultRelativeUri) { }

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

        /// <inheritdoc />
        public async Task<JsonDocument> LoadAsync() =>
            await LoadAsync(CurrentRelativeUri);
        
        /// <inheritdoc />
        public async Task<JsonDocument> LoadAsync(string relativeUri)
        {
            var dailyString = await Client.GetStringAsync(relativeUri);
            var dailyJson = JsonDocument.Parse(dailyString);

            return dailyJson;
        }

        /// <inheritdoc />
        public async Task<JsonDocument> Load() =>
            await Load(CurrentRelativeUri);

        /// <inheritdoc />
        public async Task<JsonDocument> Load(string relativeUri)
        {
            var dailyString = Client.GetStringAsync(relativeUri).Result;
            var dailyJson = JsonDocument.Parse(dailyString);

            return dailyJson;
        }
    }
}
