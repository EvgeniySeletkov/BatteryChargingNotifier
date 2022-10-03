using BatteryChargingNotifier.Services.LocalNotification;
using Xamarin.Essentials;

namespace BatteryChargingNotifier.Services.Battery
{
    public class BatteryService : IBatteryService
    {
        private const double CHARGE_LEVEL = 0.01;
        private const double MAX_CHARGE_LEVEL = 0.8;
        private const double MIN_CHARGE_LEVEL = 0.2;

        private readonly ILocalNotificationService _localNotificationService;

        public BatteryService(ILocalNotificationService localNotificationService)
        {
            _localNotificationService = localNotificationService;
        }

        #region -- IBatteryService implementation --

        public void EnableNotifications()
        {
            Xamarin.Essentials.Battery.BatteryInfoChanged += OnBatteryInfoChanged;
        }

        #endregion

        private void OnBatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
#if DEBUG
            if (e.ChargeLevel >= CHARGE_LEVEL)
            {
                _localNotificationService.ShowNotification("Title", "Description");
            }
#else
            if (e.State == BatteryState.Charging && e.ChargeLevel >= MAX_CHARGE_LEVEL)
            {
                _localNotificationService.ShowNotification("Title", "Battery is charged!");
            }
            else if (e.State == BatteryState.NotCharging && e.ChargeLevel <= MIN_CHARGE_LEVEL)
            {
                _localNotificationService.ShowNotification("Title", "Battery low!");
            }
#endif
        }
    }
}
