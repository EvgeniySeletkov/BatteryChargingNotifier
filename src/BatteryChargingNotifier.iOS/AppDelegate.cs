using BatteryChargingNotifier.iOS.Helpers;
using Foundation;
using UIKit;
using UserNotifications;

namespace BatteryChargingNotifier.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            var settings = UIUserNotificationSettings.GetSettingsForTypes(
                        UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                        new NSSet());

            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

            UNUserNotificationCenter.Current.Delegate = new UserNotificationCenterDelegate();

            LoadApplication(new App(new IOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }
}
