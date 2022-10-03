namespace BatteryChargingNotifier.Services.LocalNotification
{
    public interface ILocalNotificationService
    {
        void ShowNotification(string title, string description);
    }
}
