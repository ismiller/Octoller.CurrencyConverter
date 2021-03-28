using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Octoller.CurrencyConverter.App.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using Octoller.CurrencyConverter.App.ViewModels;
using Octoller.CurrencyConverter.App.Services;

namespace Octoller.CurrencyConverter.App
{
    sealed partial class App : Application
    {
        private static IServiceProvider container;
        public static IServiceProvider Container
        {
            get
            {
                if (container is null)
                {
                    container = App.CreateServices();
                }
                return container;
            }
        }

        private static IServiceProvider CreateServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<LoaderJsonQuote>();
            services.AddScoped<ParserDailyQuote>();
            services.AddScoped<DownloadViewModel>();

            return services.BuildServiceProvider();
        }


        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame is null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content is null)
                {
                    rootFrame.Navigate(typeof(DownloadPage), e.Arguments);
                }

                Window.Current.Activate();
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
