using Octoller.CurrencyConverter.App.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Octoller.CurrencyConverter.App.Views.Pages
{
    public sealed partial class DownloadPage : Page
    {
        public DownloadPage()
        {
            this.InitializeComponent();
        }

        /// <inheritdoc />
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            (DataContext as DownloadViewModel).Load(Frame);
        }
    }
}
