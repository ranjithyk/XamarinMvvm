using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinMvvm.Sample.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
            TabCommand = new Command(OnTab);
            RegisterCommand = new Command(async () => await OnRegister());
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand TabCommand { get; }
        public string UserName { get; set; } = "Ranjith";
        public string Password { get; set; }

        private void OnLogin()
        {
            if(string.Equals(Password, "1234"))
            {
                RootNavigation.SwitchRootWithNavigation<HomeViewModel>(UserName);
            }
        }

        private void OnTab()
        {
            var tabbedContainer = new TabbedNoNavContainer();
            tabbedContainer.AddTab<HomeViewModel>(null, "Home", null);
            tabbedContainer.AddTab<UseRegistrationViewModel>(null, "Register", null);
            tabbedContainer.AddTab<LoginViewModel>(null, "Login", null);
            PageNavigation.NavigateToAsync(tabbedContainer);
        }

        private async Task OnRegister()
        {
            await PageNavigation.NavigateToAsync<UseRegistrationViewModel>();
        }
    }
}