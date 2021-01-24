using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinMvvm.Sample.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new AsyncCommand(OnLogin);
            TabCommand = new AsyncCommand(OnTab);
            RegisterCommand = new AsyncCommand(async () => await OnRegister());
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand TabCommand { get; }
        public string UserName { get; set; } = "Ranjith";
        public string Password { get; set; }
        public string Message { get; set; }

        protected override Task OnInt(object parameter = null)
        {
            if (parameter != null)
            {
                Message = parameter.ToString();
            }

            return base.OnInt(parameter);
        }

        protected override Task OnReverseInt(object parameter = null)
        {
            if (parameter != null)
            {
                Message = parameter.ToString();
            }

            return base.OnReverseInt(parameter);
        }

        private void OnLogin()
        {
            Message = string.Empty;

            if (string.IsNullOrEmpty(UserName))
            {
                Message = "Please enter user name";
                return;
            }

            if (UserName.Length < 6)
            {
                Message = "Please enter valid user name";
                return;
            }

            if (string.Equals(Password, "1234"))
            {
                RootNavigation.SwitchRootWithNavigation<HomeViewModel>(UserName);
            }

            Message = "Incorrect password \n Hint: 1234";
        }

        private void OnTab()
        {
            var tabbedContainer = new TabbedNavigationPageContainer();
            tabbedContainer.AddTab<HomeViewModel>(true, "Home", null);
            tabbedContainer.AddTab<UseRegistrationViewModel>(null, "Register", null);
            tabbedContainer.AddTab<LoginViewModel>(null, "Login", null);
            PageNavigation.NavigateToAsync(tabbedContainer);
        }

        private async Task OnRegister()
        {
            await PageNavigation.NavigateToAsync<UseRegistrationViewModel>();
        }

        protected override Task OnDisappearing()
        {
            Message = string.Empty;
            return base.OnDisappearing();
        }
    }
}