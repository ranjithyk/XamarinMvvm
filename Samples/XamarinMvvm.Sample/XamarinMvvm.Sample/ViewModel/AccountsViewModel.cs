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
            TabCommand = new AsyncCommand(OnTab);
            Title = "Accounts";
        }

        public ICommand LogoutCommand { get; }
        public ICommand TabCommand { get; }
        public string UserName { get; set; }
        public bool IsNonContainerNavigation { get; set; }

        protected override void OnInit(object parameter = null)
        {
            if (parameter != null)
            {
                if (parameter is bool root)
                    IsNonContainerNavigation = root;
                else
                    UserName = parameter.ToString();
            }
        }

        private void OnTab()
        {
            if (IsNonContainerNavigation)
            {
                PageNavigation.NavigateToAsync<HomeTabbedViewModel>(UserName);
            }
            else
            {
                var tabbedContainer = new TabbedPageContainer();
                tabbedContainer.AddTab<HomeViewModel>(null, "Home", null);
                tabbedContainer.AddTab<CatalogViewModel>(null, "Catalog", null);
                tabbedContainer.AddTab<AccountsViewModel>(UserName, "Accounts", null);
                PageNavigation.NavigateToAsync(tabbedContainer);
            }
        }

        protected override async Task OnNavigateBackAsync(object parameter = null)
        {
            if (IsNonContainerNavigation)
                await RootNavigation.NavigateBackAsync();
            else
                await base.OnNavigateBackAsync(parameter);
        }

        private void OnLogout()
        {
            RootNavigation.SwitchRootWithNavigation<LoginViewModel>("Logged out");
        }
    }
}