using Xamarin.Forms;

namespace XamarinMvvm
{
    public class NavigationPageContainer<TViewModel> : NavigationPage, IPageContainer where TViewModel : LifeCycleAwareViewModel
    {
        public NavigationPageContainer(object parameter = null)
        {
            var pageNavigation = MvvmIoc.Container.Resolve<IPageNavigation>();
            pageNavigation.NavigationPage = this;
            pageNavigation.NavigateToAsync<TViewModel>(parameter);
        }

        public Page GetPage()
        {
            return this;
        }
    }
}