using BatteryChargingNotifier.Services.Battery;
using BatteryChargingNotifier.ViewModels;
using BatteryChargingNotifier.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace BatteryChargingNotifier
{
    public partial class App : PrismApplication
    {
        private IBatteryService _batteryService;
        private IBatteryService BatteryService => _batteryService ??= Container.Resolve<IBatteryService>();

        public App(IPlatformInitializer initializer = null)
            : base(initializer)
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Services.
            containerRegistry.RegisterInstance<IBatteryService>(Container.Resolve<BatteryService>());

            // Navigation.
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<BatteryPage, BatteryPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            BatteryService.EnableNotifications();

            await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(BatteryPage)}");
        }
    }
}
