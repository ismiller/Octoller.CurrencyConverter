using Octoller.CurrencyConverter.App.Infrastructure.Commands;
using Octoller.CurrencyConverter.App.Services;
using Octoller.CurrencyConverter.App.ViewModels.Base;
using Octoller.CurrencyConverter.App.Views.Pages;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
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
        public Frame CurrentFrame { get; set; }

        public DownloadViewModel(
            ParserDailyQuote parserDailyQuote,
            LoaderJsonQuote loaderJsonQuote)
        {
            LoaderJsonQuote = loaderJsonQuote;
            ParserDailyQuote = parserDailyQuote;
            CurrentFrame = (Frame)Window.Current.Content;

            Load = new TemplateCommand(OnLoad, OnCanLoad);
        }


        #region FrameProperties

        /// <summary>
        /// Указывает, активен ли индикатор загрузки.
        /// </summary>
        private bool isActive;
        public bool IsActive
        {
            get => isActive;
            set => Set(ref isActive, value);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Предоставляет команду загрузки данных.
        /// </summary>
        public ICommand Load { get; }

        /// <summary>
        /// Выполняет загрузку данных с последующим переходом в рабочее окно.
        /// </summary>
        /// <param name="o">Параметр команды.</param>
        public async void OnLoad(object o)
        {
            if (o is Frame currentFrame)
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
        }

        /// <summary>
        /// Выполняет проверку доступности выполнения команды.
        /// </summary>
        /// <param name="o">Параметр команды.</param>
        /// <returns><see langword="true" /> если возможно выполнить команду.</returns>
        public bool OnCanLoad(object o) =>
            o is Frame currentFrame && currentFrame != null;

        #endregion

        private QuotationСollection LoadDataQuotation()
        {
            var response = LoaderJsonQuote.Load();
            return ParserDailyQuote.Parse(response);
        }
    }
}
