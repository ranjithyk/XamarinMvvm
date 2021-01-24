using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinMvvm.Sample.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            LogoutCommand = new AsyncCommand(OnLogout);
            TabCommand = new AsyncCommand(OnTab);
            Title = "Home Page";
        }

        public ICommand LogoutCommand { get; }
        public ICommand TabCommand { get; }
        public string UserName { get; set; }
        public bool IsInNavTab { get; set; }

        protected override Task OnInt(object parameter = null)
        {
            if(parameter != null)
            {
                if (parameter is bool root)
                    IsInNavTab = root;
                else
                    UserName = parameter.ToString();
            }
            return base.OnInt(parameter);
        }

        private void OnTab()
        {
            if (IsInNavTab)
            {
                PageNavigation.NavigateToAsync<HomeTabbedViewModel>();
            }
            else
            {
                var tabbedContainer = new TabbedPageContainer();
                tabbedContainer.AddTab<HomeViewModel>(null, "Home", null);
                tabbedContainer.AddTab<UseRegistrationViewModel>(null, "Register", null);
                tabbedContainer.AddTab<LoginViewModel>(null, "Login", null);
                PageNavigation.NavigateToAsync(tabbedContainer);
            }
        }

        protected override async Task OnNavigateBackAsync(object parameter = null)
        {
            if (IsInNavTab)
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
