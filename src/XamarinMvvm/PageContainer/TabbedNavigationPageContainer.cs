using Xamarin.Forms;

namespace XamarinMvvm
{
    public class TabbedNavigationPageContainer : TabbedPage, IPageContainer
    {
        public TabbedNavigationPageContainer()
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
