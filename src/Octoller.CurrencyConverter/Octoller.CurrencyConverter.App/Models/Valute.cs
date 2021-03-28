using Octoller.CurrencyConverter.App.Infrastructure.Models.Interface;

namespace Octoller.CurrencyConverter.App.Infrastructure.Models
{
    /// <summary>
    /// Валюта
    /// </summary>
    public class Valute : IValute
    {
        ///<inheritdoc />
        public string ID { get; set; }

        ///<inheritdoc />
        public string NumCode { get; set; }

        ///<inheritdoc />
        public string CharCode { get; set; }

        ///<inheritdoc />
        public string Name { get; set; }

        ///<inheritdoc />
        public override string ToString() =>
            $"\n{Name} " +
            $"\n\t(ID: {ID}, NumCode: {NumCode}, CharCode: {CharCode})";
    }
}
