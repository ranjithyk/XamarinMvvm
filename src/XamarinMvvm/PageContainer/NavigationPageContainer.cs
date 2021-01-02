using Xamarin.Forms;

namespace XamarinMvvm
{
    public class NavigationPageContainer<TViewModel> : IPageContainer where TViewModel : LifeCycleAwareViewModel
    {
        public Page CreatePage(object parameter = null)
        {
            var pageNavigation = new PageNavigation(MvvmIoc.Container.Resolve<IViewGenerator>());
            var page = pageNavigation.FindAndCreatePage<TViewModel>(parameter);
            pageNavigation.NavigationPage = new NavigationPage(page);
            return pageNavigation.NavigationPage;
        }
    }
}