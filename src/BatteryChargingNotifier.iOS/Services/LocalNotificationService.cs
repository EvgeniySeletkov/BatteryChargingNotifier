using System.Diagnostics;
using BatteryChargingNotifier.Services.LocalNotification;
using UserNotifications;

namespace BatteryChargingNotifier.iOS.Services
{
    public class LocalNotificationService : ILocalNotificationService
    {
        #region -- ILocalNotificationService implementation --

        public void ShowNotification(string title, string description)
        {
            var notification = new UNMutableNotificationContent
            {
                Title = title,
                Body = description,
                Sound = UNNotificationSound.Default,
                InterruptionLevel = UNNotificationInterruptionLevel.Critical,
            };

            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(1, false);

            var requestID = "sampleRequest";
            var request = UNNotificationRequest.FromIdentifier(requestID, notification, trigger);

            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) => {
                if (err != null)
                {
                    Debug.WriteLine(err);
                }
            });
        }

        #endregion
    }
}
