using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace BatteryChargingNotifier
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null)
            : base(initializer)
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Navigation.
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainPage)}");
        }
    }
}
