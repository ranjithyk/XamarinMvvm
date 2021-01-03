using Xamarin.Forms;

namespace XamarinMvvm
{
    public class TabbedPageContainer : TabbedPage, IPageContainer
    {
        public TabbedPageContainer()
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void AddTab<TViewModel>(object parameter, string title, string icon) where TViewModel : LifeCycleAwareViewModel
        {
            Children.Add(new NavigationPageContainer<TViewModel>(parameter) { Title = title, IconImageSource = icon }.GetPage());
        }

        public Page GetPage()
        {
            return this;
        }
    }
}
