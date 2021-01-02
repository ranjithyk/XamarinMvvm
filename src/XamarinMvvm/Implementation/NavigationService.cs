using Xamarin.Forms;

namespace XamarinMvvm
{
    public class NavigationService : INavigationService
    {
        private readonly IViewGenerator _viewGenerator;
        private IApplication _application;

        public NavigationService(IViewGenerator viewGenerator)
        {
            _viewGenerator = viewGenerator;
        }

        public void StartApplication(IApplication application)
        {
            _application = application;
        }

        public void SwitchRoot(IPageContainer pageContainer, object parameter = null)
        {
            var page = pageContainer.CreatePage(parameter);
            _application.MainPage = page;
        }

        public void SwitchRoot<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel
        {
            var pageNavigation = new PageNavigation(MvvmIoc.Container.Resolve<IViewGenerator>());
            var page = pageNavigation.FindAndCreatePage<TViewModel>(parameter);
            _application.MainPage = page;
        }

        public void SwitchRootWithNavigation<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel
        {
            var navigationPage = new NavigationPageContainer<TViewModel>();
            var page = navigationPage.CreatePage(parameter);
            _application.MainPage = page;
        }
    }
}