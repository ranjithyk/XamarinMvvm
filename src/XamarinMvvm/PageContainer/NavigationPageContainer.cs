using Xamarin.Forms;

namespace XamarinMvvm
{
    /// <summary>
    /// Navigation container which supprts navigation
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <seealso cref="Xamarin.Forms.NavigationPage" />
    /// <seealso cref="XamarinMvvm.IPageContainer" />
    public class NavigationPageContainer<TViewModel> : NavigationPage, IPageContainer where TViewModel : LifeCycleAwareViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationPageContainer{TViewModel}"/> class.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public NavigationPageContainer(object parameter = null)
        {
            var pageNavigation = MvvmIoc.Container.Resolve<IPageNavigation>();
            pageNavigation.NavigationPage = this;
            pageNavigation.NavigateToAsync<TViewModel>(parameter);
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