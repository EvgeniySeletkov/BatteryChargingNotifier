using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;
using BatteryChargingNotifier.Services.LocalNotification;

namespace BatteryChargingNotifier.Droid.Services
{
    public class LocalNotificationService : ILocalNotificationService
    {
        private const string CHANNEL_ID = "DefaultID";
        private const string CHANNEL_NAME = "General";
        private const string CHANNEL_DESCRIPTION = "All notifications";

        private bool _isNotificationChannelCreated;

        #region -- ILocalNotificationService implementation --

        public void ShowNotification(string title, string description)
        {
            if (!_isNotificationChannelCreated)
            {
                _isNotificationChannelCreated = CreateNotificationChannel();
            }

            if (_isNotificationChannelCreated)
            {
                var intent = new Intent(Application.Context, typeof(MainActivity));
                var pendingIntent = PendingIntent.GetActivity(Application.Context, 0, intent, PendingIntentFlags.OneShot);

                var notificationBuilder = new NotificationCompat.Builder(Application.Context, CHANNEL_ID);

                notificationBuilder.SetSmallIcon(GetIcon())
                    .SetContentTitle(title)
                    .SetContentText(description)
                    .SetShowWhen(true)
                    .SetAutoCancel(true)
                    .SetContentIntent(pendingIntent)
                    .SetPriority((int)NotificationPriority.Max)
                    .SetVisibility((int)NotificationVisibility.Public)
                    .SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate);

                var notificationManager = NotificationManagerCompat.From(Application.Context);
                notificationManager.Notify(0, notificationBuilder.Build());
            }
        }

        #endregion

        #region -- Private helpers --

        private bool CreateNotificationChannel()
        {
            var result = false;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(CHANNEL_ID, CHANNEL_NAME, NotificationImportance.Max)
                {
                    Description = CHANNEL_DESCRIPTION,
                    LockscreenVisibility = NotificationVisibility.Public,
                };

                if (Application.Context.GetSystemService(Context.NotificationService) is NotificationManager notificationManager)
                {
                    notificationManager.CreateNotificationChannel(channel);

                    result = true;
                }
            }

            return result;
        }

        private int GetIcon()
        {
            return Application.Context.ApplicationInfo.Icon;
        }

        #endregion
    }
}
