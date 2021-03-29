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

        /// <inheritdoc />
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is QuotationСollection quotations && quotations != null)
            {
               (DataContext as MainViewModel)
                    .QuotationСollection = quotations;
            }
        }
    }
}
