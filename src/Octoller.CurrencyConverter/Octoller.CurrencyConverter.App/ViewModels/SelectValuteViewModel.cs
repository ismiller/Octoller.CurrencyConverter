using Octoller.CurrencyConverter.App.Infrastructure;
using Octoller.CurrencyConverter.App.Infrastructure.Commands;
using Octoller.CurrencyConverter.App.Infrastructure.Models;
using Octoller.CurrencyConverter.App.Services;
using Octoller.CurrencyConverter.App.ViewModels.Base;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Octoller.CurrencyConverter.App.ViewModels
{
    public class SelectValuteViewModel : ViewModel
    {
        public QuotationСollection QuotationСollection { get; set; }
        public MainViewModel MainView { get; set; }
        public Selector Selector { get; set; }

        public SelectValuteViewModel()
        {
            ApplicationView.PreferredLaunchViewSize = new Size(500, 250);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            var view = ApplicationView.GetForCurrentView();
            view.SetPreferredMinSize(new Size(500, 250));
            view.Title = "Выбор валюты";

            Selected = new TemplateCommand(OnSelected);
        }

        private FinancialQuote selectedQuote;
        public FinancialQuote SelectedQuote 
        { 
            get => selectedQuote;
            set => Set(ref selectedQuote, value); 
        }

        public ICommand Selected { get; }
        public void OnSelected(object o)
        {
            if (Selector == Selector.First)
            {
                MainView.FirstFinancialQuote = SelectedQuote;
            }
            else
            {
                MainView.SecondFinancialQuote = SelectedQuote;
            }

            (Window.Current.Content as Frame)?.GoBack();
        }
    }
}
