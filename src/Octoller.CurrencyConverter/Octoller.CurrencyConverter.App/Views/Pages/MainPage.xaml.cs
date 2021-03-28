using Octoller.CurrencyConverter.App.Services;
using Octoller.CurrencyConverter.App.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Octoller.CurrencyConverter.App.Views.Pages
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is QuotationСollection quotations && quotations != null)
            {
                var context = DataContext as MainViewModel;
                context.QuotationСollection = quotations;
            }
        }
    }
}
