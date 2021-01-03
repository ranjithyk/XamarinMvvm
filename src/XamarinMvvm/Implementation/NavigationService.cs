using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinMvvm
{
    public class NavigationService : INavigationService
    {
        private IApplication _application;

        public IApplication Application()
        {
            return _application;
        }

        public INavigation Navigation()
        {
            return _application.MainPage.Navigation;
        }

        public void StartApplication(IApplication application)
        {
            _application = application;
        }

        public void StartApplication(IApplication application, IPageContainer pageContainer)
        {
            _application = application;
            SwitchRoot(pageContainer);
        }

        public void StartApplication<TViewModel>(IApplication application, bool navigatable, object parameter = null) where TViewModel : LifeCycleAwareViewModel
        {
            _application = application;
            if (navigatable)
                SwitchRootWithNavigation<TViewModel>(parameter);
            else
                SwitchRoot<TViewModel>(parameter);
        }

        public void SwitchRoot(IPageContainer pageContainer)
        {
            _application.MainPage = pageContainer.GetPage();
        }

        public void SwitchRoot<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel
        {
            var pageNavigation = new PageNavigation(MvvmIoc.Container.Resolve<IViewGenerator>());
            _application.MainPage = pageNavigation.FindAndCreatePage<TViewModel>(parameter);
        }

        public void SwitchRootWithNavigation<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel
        {
            _application.MainPage = new NavigationPageContainer<TViewModel>(parameter);
        }

        public async Task NavigateBackAsync()
        {
            if (Navigation() == null) return;
            await Navigation().PopAsync();
        }
    }
}