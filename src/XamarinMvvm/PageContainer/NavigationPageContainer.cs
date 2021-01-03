using Xamarin.Forms;

namespace XamarinMvvm
{
    public class NavigationPageContainer<TViewModel> : IPageContainer where TViewModel : LifeCycleAwareViewModel
    {
        public string Title { get; set; }
        public string Icon { get; set; }

        public Page CreatePage(object parameter = null)
        {
            var pageNavigation = new PageNavigation(MvvmIoc.Container.Resolve<IViewGenerator>());
            var page = pageNavigation.FindAndCreatePage<TViewModel>(parameter);
            page.Title = Title;
            pageNavigation.NavigationPage = new NavigationPage(page);
            return pageNavigation.NavigationPage;
        }
    }
}