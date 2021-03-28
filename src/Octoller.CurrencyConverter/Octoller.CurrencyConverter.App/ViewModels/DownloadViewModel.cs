using Octoller.CurrencyConverter.App.Services;
using Octoller.CurrencyConverter.App.ViewModels.Base;
using Octoller.CurrencyConverter.App.Views.Pages;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

namespace Octoller.CurrencyConverter.App.ViewModels
{
    /// <summary>
    /// Представление окна загрузки.
    /// </summary>
    public class DownloadViewModel : ViewModel
    {
        private ParserDailyQuote ParserDailyQuote { get; }
        private LoaderJsonQuote LoaderJsonQuote { get; }

        public DownloadViewModel(
            ParserDailyQuote parserDailyQuote,
            LoaderJsonQuote loaderJsonQuote)
        {
            LoaderJsonQuote = loaderJsonQuote;
            ParserDailyQuote = parserDailyQuote;

            ApplicationView.PreferredLaunchViewSize = new Size(500, 150);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            var view = ApplicationView.GetForCurrentView();
            view.SetPreferredMinSize(new Size(500, 150));
            view.Title = "Загрузка данных...";
        }

        /// <summary>
        /// Указывает, активен ли индикатор загрузки.
        /// </summary>
        private bool isActive;
        public bool IsActive
        {
            get => isActive;
            set => Set(ref isActive, value);
        }

        /// <summary>
        /// Выполняет загрузку данных с последующим переходом в рабочее окно.
        /// </summary>
        /// <param name="o">Параметр команды.</param>
        public async void Load(Frame currentFrame)
        {
            IsActive = true;

            // По причине того, что загрузка данный происвходит довольно быстро,
            // для явной демонстрации окна загрузки, добавил задержку по времени

            await Task.Delay(5000);
            var result = await Task.Run(() =>
            {
                return LoadDataQuotation();
            });

            IsActive = false;

            currentFrame.Navigate(typeof(MainPage), result);
        }

        private QuotationСollection LoadDataQuotation()
        {
            var response = LoaderJsonQuote.Load();
            return ParserDailyQuote.Parse(response);
        }
    }
}
