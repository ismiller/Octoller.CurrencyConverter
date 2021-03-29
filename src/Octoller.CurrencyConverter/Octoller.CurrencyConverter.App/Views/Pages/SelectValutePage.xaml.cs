using Octoller.CurrencyConverter.App.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Octoller.CurrencyConverter.App.Views.Pages
{
    public sealed partial class SelectValutePage : Page
    {
        public SelectValutePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var content = e.Parameter as SelectValuteViewModel;
            DataContext = content;
        }
    }
}
