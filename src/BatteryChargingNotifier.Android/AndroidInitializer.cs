using BatteryChargingNotifier.Droid.Services;
using BatteryChargingNotifier.Services.LocalNotification;
using Prism;
using Prism.Ioc;

namespace BatteryChargingNotifier.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILocalNotificationService, LocalNotificationService>();
        }
    }
}
