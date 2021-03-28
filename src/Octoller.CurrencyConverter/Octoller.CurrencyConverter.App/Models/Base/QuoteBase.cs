using Octoller.CurrencyConverter.App.Infrastructure.Models.Interface;

namespace Octoller.CurrencyConverter.App.Infrastructure.Models.Base
{
    public abstract class QuoteBase : IQuote
    {
        ///<inheritdoc />
        public string ValuteID { get; set; }

        ///<inheritdoc />
        public int Nominal { get; set; }

        ///<inheritdoc />
        public decimal Value { get; set; }

        /// <summary>
        /// Возвращает катировку за одну единицу валюты, если изначально указана цена за иное колличество валюты.
        /// </summary>
        /// <returns>Катировка единицы валюты.</returns>
        public virtual decimal UnitQuotation()
        {
            return (Nominal > 1) ? Value / Nominal : Value;
            
        }
    }
}
