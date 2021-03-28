using System;
using System.Text.Json;

namespace Octoller.CurrencyConverter.App.Infrastructure.Interface
{
    public interface ILoaderJson
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
        /// Выполняет загрузку данныx по установленному адресу и возвращает в формате <see cref="JsonDocument"/>.
        /// </summary>
        /// <returns>Загруженные данные, <see cref="JsonDocument" />.</returns>
        JsonDocument Load();

        /// <summary>
        /// Выполняет загрузку данныx по установленному относительному адресу 
        /// и возвращает в формате <see cref="JsonDocument"/>.
        /// </summary>
        /// <param name="relativeUri">Относительный адресс.</param>
        /// <returns>Загруженные данные, <see cref="JsonDocument" />.</returns>
        JsonDocument Load(string relativeUri);
    }
}