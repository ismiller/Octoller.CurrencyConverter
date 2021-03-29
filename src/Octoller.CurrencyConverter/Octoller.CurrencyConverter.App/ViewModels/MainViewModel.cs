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

            SelectFirst = new TemplateCommand(OnSelectFirst);
            SelectSecond = new TemplateCommand(OnSelectSecond);
        }

        private FinancialQuote firstFinancialQuote;
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

        public ICommand SelectFirst { get; }
        public ICommand SelectSecond { get; }

        public void OnSelectFirst(object o) => (Window.Current.Content as Frame)
                .Navigate(typeof(SelectValutePage), new SelectValuteViewModel()
                {
                    QuotationСollection = QuotationСollection,
                    SelectedQuote = FirstFinancialQuote,
                    Selector = Selector.First,
                    MainView = this
                });

        public void OnSelectSecond(object o) =>
            (Window.Current.Content as Frame)
                .Navigate(typeof(SelectValutePage), new SelectValuteViewModel()
                {
                    QuotationСollection = QuotationСollection,
                    SelectedQuote = SecondFinancialQuote,
                    Selector = Selector.Second,
                    MainView = this
                });
    }
}
