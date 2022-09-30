using System.Threading.Tasks;
using System.Windows.Input;
using BatteryChargingNotifier.Views;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;

namespace BatteryChargingNotifier.ViewModels
{
    public class BatteryPageViewModel : BaseViewModel
    {
        public BatteryPageViewModel(
            INavigationService navigationService)
            : base(navigationService)
        {
        }

        #region -- Public properties --

        private ICommand _goToSettingsCommand;
        public ICommand GoToSettingsCommand => _goToSettingsCommand ??= new AsyncCommand(OnGoToSettingsCommandAsync, allowsMultipleExecutions: false);

        #endregion

        #region -- Private helpers --

        private Task OnGoToSettingsCommandAsync()
        {
            return NavigationService.NavigateAsync(nameof(SettingsPage));
        }

        #endregion
    }
}
