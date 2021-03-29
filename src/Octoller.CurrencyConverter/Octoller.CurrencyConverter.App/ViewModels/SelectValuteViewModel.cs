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
    /// <summary>
    /// Представление для вывода списка загруженных типов валюты
    /// и для выбора конвертируемой валют
    /// </summary>
    public class SelectValuteViewModel : ViewModel
    {
        /// <summary>
        /// Список валюты и катировок.
        /// </summary>
        public QuotationСollection QuotationСollection { get; set; }

        /// <summary>
        /// Представление главного окна для установки выбранного значения.
        /// </summary>
        public MainViewModel MainView { get; set; }

        /// <summary>
        /// Переключатель, отвечает за установку выбранного элемента в нужное свойство.
        /// </summary>
        public Selector Selector { get; set; }

        public SelectValuteViewModel()
        {
            ApplicationView.PreferredLaunchViewSize = new Size(500, 250);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            var view = ApplicationView.GetForCurrentView();
            view.SetPreferredMinSize(new Size(500, 250));
            view.Title = "Выбор валюты";

            // Установка команд.
            Selected = new TemplateCommand(OnSelected);
        }

        #region Свойства привязки

        private FinancialQuote selectedQuote;

        /// <summary>
        /// Предоставляет или задает выбранный элемент списка.
        /// </summary>
        public FinancialQuote SelectedQuote
        {
            get => selectedQuote;
            set => Set(ref selectedQuote, value);
        }

        #endregion

        #region Команды

        /// <summary>
        /// Предоставляет объект команды выбора.
        /// </summary>
        public ICommand Selected { get; }

        /// <summary>
        /// Обрабатывает событие выбора элемента из списка.
        /// </summary>
        /// <param name="o"></param>
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

        #endregion
    }
}
