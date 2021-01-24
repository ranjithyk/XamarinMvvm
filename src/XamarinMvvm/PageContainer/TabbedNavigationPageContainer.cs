using Xamarin.Forms;

namespace XamarinMvvm
{
    /// <summary>
    /// Tabbed page contaier with navigation page
    /// </summary>
    /// <seealso cref="Xamarin.Forms.TabbedPage" />
    /// <seealso cref="XamarinMvvm.IPageContainer" />
    public class TabbedNavigationPageContainer : TabbedPage, IPageContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabbedNavigationPageContainer"/> class.
        /// </summary>
        public TabbedNavigationPageContainer()
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }

        /// <summary>
        /// Adds the tab.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        public void AddTab<TViewModel>(object parameter, string title, string icon) where TViewModel : LifeCycleAwareViewModel
        {
            Children.Add(new NavigationPageContainer<TViewModel>(parameter) { Title = title, IconImageSource = icon }.GetPage());
        }

        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <returns></returns>
        public Page GetPage()
        {
            return this;
        }
    }
}