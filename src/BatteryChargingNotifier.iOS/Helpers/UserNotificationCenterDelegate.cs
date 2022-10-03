using System;
using UserNotifications;

namespace BatteryChargingNotifier.iOS.Helpers
{
    public class UserNotificationCenterDelegate : UNUserNotificationCenterDelegate
    {
        public override void WillPresentNotification(
            UNUserNotificationCenter center,
            UNNotification notification,
            Action<UNNotificationPresentationOptions> completionHandler)
        {
            var presentationOptions = UNNotificationPresentationOptions.Sound
                    | UNNotificationPresentationOptions.Alert
                    | UNNotificationPresentationOptions.Badge;

            completionHandler?.Invoke(presentationOptions);
        }
    }
}
