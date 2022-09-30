using BatteryChargingNotifier.Services.LocalNotification;
using Xamarin.Essentials;

namespace BatteryChargingNotifier.Services.Battery
{
    public class BatteryService : IBatteryService
    {
        private const double CHARGE_LEVEL = 0.01;

        private readonly ILocalNotificationService _localNotificationService;

        public BatteryService(ILocalNotificationService localNotificationService)
        {
            _localNotificationService = localNotificationService;
        }

        #region -- Public properties --

        public void EnableNotifications()
        {
            Xamarin.Essentials.Battery.BatteryInfoChanged += OnBatteryInfoChanged;
        }

        #endregion

        private void OnBatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            if (e.ChargeLevel >= CHARGE_LEVEL)
            {
                _localNotificationService.ShowNotification("Title", "Description");
            }
        }
    }
}
