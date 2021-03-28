using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

namespace Octoller.CurrencyConverter.App.Views.Pages
{
    public sealed partial class DownloadPage : Page
    {
        public DownloadPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(500, 150);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            
            var view = ApplicationView.GetForCurrentView();
            view.SetPreferredMinSize(new Size(500, 150));
            view.Title = "Загрузка данных...";
        }
    }
}
