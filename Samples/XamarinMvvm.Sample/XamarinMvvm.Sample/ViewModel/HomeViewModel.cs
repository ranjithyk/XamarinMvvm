using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinMvvm.Sample.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            LogoutCommand = new Command(OnLogout);
            TabCommand = new Command(OnTab);
            Title = "Home Page";
        }

        public ICommand LogoutCommand { get; }
        public ICommand TabCommand { get; }
        public string UserName { get; set; }

        protected override Task OnInt(object parameter = null)
        {
            if(parameter != null)
            {
                UserName = parameter.ToString();
            }
            return base.OnInt(parameter);
        }

        private void OnTab()
        {
            var tabbedContainer = new TabbedPageContainer();
            tabbedContainer.AddTab<HomeViewModel>(null, "Home", null);
            tabbedContainer.AddTab<UseRegistrationViewModel>(null, "Register", null);
            tabbedContainer.AddTab<LoginViewModel>(null, "Login", null);
            PageNavigation.NavigateToAsync(tabbedContainer);
        }

        private void OnLogout()
        {
            RootNavigation.SwitchRootWithNavigation<LoginViewModel>();
        }
    }
}
