using BatteryChargingNotifier.iOS.Services;
using BatteryChargingNotifier.Services.LocalNotification;
using Prism;
using Prism.Ioc;

namespace BatteryChargingNotifier.iOS
{
    public class IOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILocalNotificationService, LocalNotificationService>();
        }
    }
}
