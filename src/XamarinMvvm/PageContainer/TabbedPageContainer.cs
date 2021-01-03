using Xamarin.Forms;

namespace XamarinMvvm
{
    public class TabbedPageContainer : IPageContainer
    {
        readonly TabbedPage tabbedPage;

        public TabbedPageContainer()
        {
            tabbedPage = new TabbedPage();
        }

        public void AddTab<TViewModel>(object parameter, string title, string icon) where TViewModel : LifeCycleAwareViewModel
        {
            tabbedPage.Children.Add(new NavigationPageContainer<TViewModel>() { Title = title, Icon = icon }.CreatePage(parameter));
        }

        public Page CreatePage(object parameter = null)
        {
            return tabbedPage;
        }
    }
}
