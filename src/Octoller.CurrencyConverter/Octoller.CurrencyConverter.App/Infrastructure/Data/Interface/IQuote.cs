namespace Octoller.CurrencyConverter.App.Infrastructure.Data.Interface
{

    public interface IQuote
    {
        /// <summary>
        /// Идентификатор валюты, к которой относиться катировка
        /// </summary>
        string ValuteID { get; set; }

        /// <summary>
        /// Номаинал конвертации
        /// </summary>
        int Nominal { get; set; }

        /// <summary>
        /// Текущее значение курса по отношению к 
        /// </summary>
        decimal Value { get; set; }
    }
}
