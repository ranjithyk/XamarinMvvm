using Xamarin.Forms;

namespace XamarinMvvm
{
    public class TabbedNoNavContainer : TabbedPage, IPageContainer
    {
        readonly PageNavigation pageNavigation = new PageNavigation(MvvmIoc.Container.Resolve<IViewGenerator>());

        public void AddTab<TViewModel>(object parameter, string title, string icon) where TViewModel : LifeCycleAwareViewModel
        {
            var page = pageNavigation.FindAndCreatePage<TViewModel>(parameter);
            page.Title = title;
            page.IconImageSource = icon;
            Children.Add(page);
        }

        public Page GetPage()
        {
            return this;
        }
    }
}
