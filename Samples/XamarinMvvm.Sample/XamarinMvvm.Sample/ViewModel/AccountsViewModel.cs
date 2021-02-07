using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinMvvm.Sample.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class AccountsViewModel : BaseViewModel
    {
        public AccountsViewModel()
        {
            LogoutCommand = new AsyncCommand(OnLogout);
            NavigationCommand = new AsyncCommand<string>(OnNavigationAsync);
            Title = "Accounts";
        }

        public ICommand LogoutCommand { get; }
        public ICommand NavigationCommand { get; }
        public string UserName { get; set; }

        protected override void OnInit(object parameter = null)
        {
            if (parameter != null)
            {
                UserName = parameter.ToString();
            }
        }

        private async Task OnNavigationAsync(string page)
        {
            switch(page)
            {
                case "Profile":
                    await PageNavigation.NavigateToAsync<ProfileViewModel>(UserName);
                    break;

                case "Settings":
                    await PageNavigation.NavigateToAsync<SettingsViewModel>();
                    break;

                case "History":
                    await PageNavigation.NavigateToAsync<HistoryViewModel>();
                    break;

                case "Address":
                    await PageNavigation.NavigateToAsync<AddressViewModel>();
                    break;

                case "Payments":
                    await PageNavigation.NavigateToAsync<PaymentsViewModel>();
                    break;
            }
        }

        private void OnLogout()
        {
            RootNavigation.SwitchRootWithNavigation<LoginViewModel>("Logged out");
        }
    }
}