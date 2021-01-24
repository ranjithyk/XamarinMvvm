using Xamarin.Forms;

namespace XamarinMvvm
{
    /// <summary>
    /// Tabbed page contaier with out navigation page
    /// </summary>
    /// <seealso cref="Xamarin.Forms.TabbedPage" />
    /// <seealso cref="XamarinMvvm.IPageContainer" />
    public class TabbedPageContainer : TabbedPage, IPageContainer
    {
        /// <summary>
        /// The page navigation
        /// </summary>
        readonly PageNavigation pageNavigation = new PageNavigation(MvvmIoc.Container.Resolve<IViewGenerator>());

        /// <summary>
        /// Adds the tab.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        public void AddTab<TViewModel>(object parameter, string title, string icon) where TViewModel : LifeCycleAwareViewModel
        {
            var page = pageNavigation.FindAndCreatePage<TViewModel>(parameter);
            page.Title = title;
            page.IconImageSource = icon;
            Children.Add(page);
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