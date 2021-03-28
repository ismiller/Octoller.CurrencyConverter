using Octoller.CurrencyConverter.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Octoller.CurrencyConverter.App.Infrastructure
{
    public class ServiceLocator
    {
        public DownloadViewModel DownloadView => App.Container.GetRequiredService<DownloadViewModel>();
    }
}
