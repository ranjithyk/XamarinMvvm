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

        public void SwitchRoot<TViewModel>(object parameter = null) where TViewModel : ViewLifeCycleAwareViewModel
        {
            var page = _viewGenerator.FindAndCreatePage<TViewModel>(parameter);
            _application.MainPage = page;
        }

        public void SwitchRootNavigation<TViewModel>(object parameter = null) where TViewModel : ViewLifeCycleAwareViewModel
        {
            var navigationPage = CreateNavigationPage<TViewModel>(parameter);
            _application.MainPage = navigationPage;
        }

        private NavigationPage CreateNavigationPage<TViewModel>(object parameter) where TViewModel : ViewLifeCycleAwareViewModel
        {
            var pageNavigation = MvvmIoc.Container.Resolve<IPageNavigation>();
            pageNavigation.NavigationPage = new NavigationPage();
            pageNavigation.NavigateToAsync<TViewModel>(parameter);
            return pageNavigation.NavigationPage;

            //var page = _viewGenerator.FindAndCreatePage<TViewModel>(parameter);
            //var navigationPage = new NavigationPage(page);
            //if (page.BindingContext is ViewLifeCycleAwareViewModel bindingContext)
            //{
            //    var pageNavigation = MvvmIoc.Container.Resolve<IPageNavigation>();
            //    pageNavigation.NavigationPage = navigationPage;
            //    bindingContext.PageNavigation = pageNavigation;
            //}
            //return navigationPage;
        }
    }
}