using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinMvvm
{
    /// <summary>
    /// PageNavigation, Used for page navigation through viewmodels
    /// </summary>
    public interface IPageNavigation
    {
        /// <summary>
        /// Gets or sets the navigation page.
        /// </summary>
        /// <value>
        /// The navigation page.
        /// </value>
        NavigationPage NavigationPage { get; set; }
        /// <summary>
        /// Gets the navigation.
        /// </summary>
        /// <value>
        /// The navigation.
        /// </value>
        INavigation Navigation { get; }
        /// <summary>
        /// Navigates asynchronously.
        /// </summary>
        /// <param name="pageContainer">The page container.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        /// <returns></returns>
        Task NavigateToAsync(IPageContainer pageContainer, bool animate = true);
        /// <summary>
        /// Navigates asynchronously.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        /// <returns></returns>
        Task NavigateToAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel;
        /// <summary>
        /// Navigates to modal asynchronously.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        /// <returns></returns>
        Task NavigateToModalAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel;
        /// <summary>
        /// Navigates the back asynchronously.
        /// </summary>
        /// <returns></returns>
        Task NavigateBackAsync();
        /// <summary>
        /// Navigates the back asynchronously.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        Task NavigateBackAsync(object parameter);
        /// <summary>
        /// Navigates to root asynchronously.
        /// </summary>
        /// <returns></returns>
        Task NavigateToRootAsync();
        /// <summary>
        /// Starts the new navigation asynchronously.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        /// <returns></returns>
        Task StartNewNavigationAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel;
        /// <summary>
        /// Finds and create page.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="modal">if set to <c>true</c> [modal].</param>
        /// <returns></returns>
        Page FindAndCreatePage<TViewModel>(object parameter = null, bool modal = false) where TViewModel : LifeCycleAwareViewModel;
        /// <summary>
        /// Resolves the view model.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="modal">if set to <c>true</c> [modal].</param>
        /// <returns></returns>
        TViewModel ResolveViewModel<TViewModel>(object parameter = null, bool modal = false) where TViewModel : LifeCycleAwareViewModel;
        /// <summary>
        /// Resolves the and wire view model.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="page">The page.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="modal">if set to <c>true</c> [modal].</param>
        /// <returns></returns>
        TViewModel ResolveAndWireViewModel<TViewModel>(Page page, object parameter = null, bool modal = false) where TViewModel : LifeCycleAwareViewModel;
    }
}