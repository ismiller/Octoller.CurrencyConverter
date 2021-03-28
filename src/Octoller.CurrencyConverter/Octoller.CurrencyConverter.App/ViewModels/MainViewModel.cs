using Octoller.CurrencyConverter.App.ViewModels.Base;
using Windows.UI.ViewManagement;

namespace Octoller.CurrencyConverter.App.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            ApplicationView.GetForCurrentView().Title = "Bar";
            
        }
    }
}
