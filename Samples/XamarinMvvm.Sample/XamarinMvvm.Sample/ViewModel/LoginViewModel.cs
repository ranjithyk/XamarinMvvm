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
            RegisterCommand = new AsyncCommand(OnRegister);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public bool IsNonContainerNavigation { get; set; }

        protected override void OnInit(object parameter = null)
        {
            if (parameter != null)
            {
                Message = parameter.ToString();
            }
        }

        protected override void OnAppearing()
        {
            UserName = "Ranjith";
        }

        protected override async Task OnAppearingAsync()
        {
            await Task.Delay(2000);
            Password = "1234";
        }

        protected override void OnReverseInit(object parameter = null)
        {
            if (parameter != null)
            {
                Message = parameter.ToString();
            }
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
                TabPage();
            }

            Message = "Incorrect password \n Hint: 1234";
        }

        private void TabPage()
        {
            var tabbedContainer = new TabbedNavigationPageContainer();
            tabbedContainer.AddTab<CatalogViewModel>(null, "Catalog", null);
            tabbedContainer.AddTab<CartViewModel>(true, "Cart", null);
            tabbedContainer.AddTab<AccountsViewModel>(UserName, "Accounts", null);
            RootNavigation.SwitchRoot(tabbedContainer);

            // Un comment this code to test Master details page
            //var masterDetails = new MasterDetailsPageContainer();
            //masterDetails.SetMaster<AccountsViewModel>(UserName);
            //masterDetails.SetDetails<CatalogViewModel>();
            //RootNavigation.SwitchRoot(masterDetails);

            // Uncomment this code to test custom master details page
            //var container = new CustomContainer.CustomMasterDetailsPageContainer(UserName);
            //RootNavigation.SwitchRoot(container);
        }

        private async Task OnRegister()
        {
            await PageNavigation.NavigateToAsync<RegistrationViewModel>();
        }

        protected override void OnDisappearing()
        {
            Message = string.Empty;
        }
    }
}