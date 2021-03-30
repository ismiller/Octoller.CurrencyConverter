using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Octoller.CurrencyConverter.App.Services.Interface
{
    /// <summary>
    /// Предоставляет методы для загрузки данных.
    /// </summary>
    public interface ILoaderJsonAsync
    {
        /// <summary>
        /// Предоставляет учтановленное текущее для базового адреса адреса.
        /// </summary>
        Uri CurrentBaseUri { get; }

        /// <summary>
        /// Предоставляет учтановленное текущее для относительного адреса адреса.
        /// </summary>
        string CurrentRelativeUri { get; }

        /// <summary>
        /// Выполняет загрузку данныx в асинхронной манере по установленному адресу 
        /// и возвращает в формате <see cref="JsonDocument"/>.
        /// </summary>
        /// <returns>Загруженные данные, <see cref="JsonDocument" />.</returns>
        Task<JsonDocument> LoadAsync();

        /// <summary>
        /// Выполняет загрузку данныx в асинхронной манере по установленному относительному адресу 
        /// и возвращает в формате <see cref="JsonDocument"/>.
        /// </summary>
        /// <param name="relativeUri">Относительный адресс.</param>
        /// <returns>Загруженные данные, <see cref="JsonDocument" />.</returns>
        Task<JsonDocument> LoadAsync(string relativeUri);
    }
}