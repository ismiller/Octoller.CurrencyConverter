using Octoller.CurrencyConverter.App.Infrastructure;
using Octoller.CurrencyConverter.App.Infrastructure.Commands;
using Octoller.CurrencyConverter.App.Infrastructure.Models;
using Octoller.CurrencyConverter.App.Services;
using Octoller.CurrencyConverter.App.ViewModels.Base;
using Octoller.CurrencyConverter.App.Views.Pages;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Octoller.CurrencyConverter.App.ViewModels
{
    /// <summary>
    /// Представление главного окна приложения, предоставляет доступ к интерфейсу конвертации валюты.
    /// </summary>
    public class MainViewModel : ViewModel
    {
        public QuotationСollection QuotationСollection { get; set; }

        public MainViewModel()
        {
            ApplicationView.PreferredLaunchViewSize = new Size(500, 150);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            var view = ApplicationView.GetForCurrentView();
            view.SetPreferredMinSize(new Size(500, 150));
            view.Title = "Конвертер валюты";

            // Установка команд
            SelectFirst = new TemplateCommand(OnSelectFirst);
            SelectSecond = new TemplateCommand(OnSelectSecond);
        }

        #region Свойства для привязки

        private FinancialQuote firstFinancialQuote;

        /// <summary>
        /// Предоставляет или задает занчение катировки первой выбранной валюты.
        /// </summary>
        public FinancialQuote FirstFinancialQuote
        {
            get
            {
                if (firstFinancialQuote is null)
                {
                    QuotationСollection.TryGetQuote("RUB", out var quote);
                    firstFinancialQuote = quote;
                }
                return firstFinancialQuote;
            }
            set => Set(ref firstFinancialQuote, value);
        }

        private FinancialQuote secondFinancialQuote;

        /// <summary>
        /// Предоставляет или задает занчение катировки первой выбранной валюты.
        /// </summary>
        public FinancialQuote SecondFinancialQuote
        {
            get
            {
                if (secondFinancialQuote is null)
                {
                    QuotationСollection.TryGetQuote("EUR", out var quote);
                    secondFinancialQuote = quote;
                }
                return secondFinancialQuote;
            }
            set => Set(ref secondFinancialQuote, value);
        }

        private decimal firstConversionValue;

        /// <summary>
        /// Предоставляет или задает колличество для первой выбранной валюты.
        /// </summary>
        public decimal FirstConversionValue
        {
            get => firstConversionValue;
            set
            {
                if (value != firstConversionValue)
                {
                    Set(ref firstConversionValue, value);
                    SecondConversionValue = Converter.Convert(value, FirstFinancialQuote, SecondFinancialQuote);
                }
            }
        }

        private decimal secondConversionValue;

        /// <summary>
        /// Предоставляет или задает колличество для второй выбранной валюты.
        /// </summary>
        public decimal SecondConversionValue
        {
            get => secondConversionValue;
            set
            {
                if (value != secondConversionValue)
                {
                    Set(ref secondConversionValue, value);
                    FirstConversionValue = Converter.Convert(value, SecondFinancialQuote, FirstFinancialQuote);
                }
            }
        }

        #endregion


        #region Команды

        public ICommand SelectFirst { get; }
        public ICommand SelectSecond { get; }

        /// <summary>
        /// Отображает окно выбора первой конвертируемой валюты.
        /// </summary>
        public void OnSelectFirst(object o) => (Window.Current.Content as Frame)
                .Navigate(typeof(SelectValutePage), new SelectValuteViewModel()
                {
                    QuotationСollection = QuotationСollection,
                    SelectedQuote = FirstFinancialQuote,
                    Selector = Selector.First,
                    MainView = this
                });

        /// <summary>
        /// Отображает окно выбора второй конвертируемой валюты.
        /// </summary>
        public void OnSelectSecond(object o) =>
            (Window.Current.Content as Frame)
                .Navigate(typeof(SelectValutePage), new SelectValuteViewModel()
                {
                    QuotationСollection = QuotationСollection,
                    SelectedQuote = SecondFinancialQuote,
                    Selector = Selector.Second,
                    MainView = this
                }); 

        #endregion
    }
}
