using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinMvvm
{
    /// <summary>
    /// NavigationService
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Applications this instance.
        /// </summary>
        /// <returns></returns>
        IApplication Application();
        /// <summary>
        /// Navigations this instance.
        /// </summary>
        /// <returns></returns>
        INavigation Navigation();
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="application">The application.</param>
        void StartApplication(IApplication application);
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="pageContainer">The page container.</param>
        void StartApplication(IApplication application, IPageContainer pageContainer);
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="application">The application.</param>
        /// <param name="navigatable">if set to <c>true</c> [navigatable].</param>
        /// <param name="parameter">The parameter.</param>
        void StartApplication<TViewModel>(IApplication application, bool navigatable, object parameter = null) where TViewModel : LifeCycleAwareViewModel;
        /// <summary>
        /// Switches the root.
        /// </summary>
        /// <param name="pageContainer">The page container.</param>
        void SwitchRoot(IPageContainer pageContainer);
        /// <summary>
        /// Switches the root.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        void SwitchRoot<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel;
        /// <summary>
        /// Switches the root with navigation.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        void SwitchRootWithNavigation<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel;
        /// <summary>
        /// Navigates back asynchronously.
        /// </summary>
        /// <returns></returns>
        Task NavigateBackAsync();
    }
}