using System;
using System.Globalization;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

using Prism.Mvvm;
using Prism.Unity.Windows;
using Prism.Windows.AppModel;

using Marimo.MappingGames.Uwp.Services;

using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.ViewManagement;
using Windows.Foundation;

namespace Marimo.MappingGames.Uwp
{
    [Windows.UI.Xaml.Data.Bindable]
    public sealed partial class App : PrismUnityApplication
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void ConfigureContainer()
        {
            // register a singleton using Container.RegisterType<IInterface, Type>(new ContainerControlledLifetimeManager());
            base.ConfigureContainer();
            Container.RegisterInstance<IResourceLoader>(new ResourceLoaderAdapter(new ResourceLoader()));
        }

        protected override async Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            await LaunchApplicationAsync(PageTokens.MainPage, null);
        }

        private async Task LaunchApplicationAsync(string page, object launchParam)
        {
            await ThemeSelectorService.SetRequestedThemeAsync();
            NavigationService.Navigate(page, launchParam);
            Window.Current.Activate();
        }

        protected override async Task OnActivateApplicationAsync(IActivatedEventArgs args)
        {
            await Task.CompletedTask;
        }

        protected override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            await base.OnInitializeAsync(args);
            await ThemeSelectorService.InitializeAsync().ConfigureAwait(false);

            Clipboard.SetContent(new DataPackage());

            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;

            ApplicationView.PreferredLaunchViewSize = new Size((int)bounds.Width, (int)bounds.Height);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            // We are remapping the default ViewNamePage and ViewNamePageViewModel naming to ViewNamePage and ViewNameViewModel to
            // gain better code reuse with other frameworks and pages within Windows Template Studio
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewModelTypeName = string.Format(CultureInfo.InvariantCulture, "Marimo.MappingGames.Uwp.ViewModels.{0}ViewModel, Marimo.MappingGames.Uwp", viewType.Name.Substring(0, viewType.Name.Length - 4));
                return Type.GetType(viewModelTypeName);
            });
        }

        protected override IDeviceGestureService OnCreateDeviceGestureService()
        {
            var service = base.OnCreateDeviceGestureService();
            service.UseTitleBarBackButton = false;
            return service;
        }
    }
}
