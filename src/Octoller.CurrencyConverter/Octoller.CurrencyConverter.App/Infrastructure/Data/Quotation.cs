using Octoller.CurrencyConverter.App.Infrastructure.Data.Base;

namespace Octoller.CurrencyConverter.App.Infrastructure.Data
{
    /// <summary>
    /// Котировка
    /// </summary>
    public class Quotation : QuoteBase
    {
        ///<inheritdoc />
        public override decimal UnitQuotation() => 
            base.UnitQuotation();

        ///<inheritdoc />
        public override string ToString() =>
            $"Катировка по валюте {ValuteID} за {Nominal} единиц составляет {Value}";   
    }
}
