using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinMvvm
{
    /// <summary>
    /// Application NavigationService
    /// </summary>
    /// <seealso cref="XamarinMvvm.INavigationService" />
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// The application
        /// </summary>
        private IApplication _application;

        /// <summary>
        /// Application instance.
        /// </summary>
        /// <returns></returns>
        public IApplication Application()
        {
            return _application;
        }

        /// <summary>
        /// Navigation instance.
        /// </summary>
        /// <returns></returns>
        public INavigation Navigation()
        {
            return _application.MainPage?.Navigation;
        }

        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="application">The application.</param>
        public void StartApplication(IApplication application)
        {
            _application = application;
        }

        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="pageContainer">The page container.</param>
        public void StartApplication(IApplication application, IPageContainer pageContainer)
        {
            _application = application;
            SwitchRoot(pageContainer);
        }

        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="application">The application.</param>
        /// <param name="navigatable">if set to <c>true</c> [navigatable].</param>
        /// <param name="parameter">The parameter.</param>
        public void StartApplication<TViewModel>(IApplication application, bool navigatable, object parameter = null) where TViewModel : LifeCycleAwareViewModel
        {
            _application = application;
            if (navigatable)
                SwitchRootWithNavigation<TViewModel>(parameter);
            else
                SwitchRoot<TViewModel>(parameter);
        }

        /// <summary>
        /// Switches the root.
        /// </summary>
        /// <param name="pageContainer">The page container.</param>
        public void SwitchRoot(IPageContainer pageContainer)
        {
            DiposePages();
            _application.MainPage = pageContainer.GetPage();
        }

        /// <summary>
        /// Switches the root.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        public void SwitchRoot<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel
        {
            DiposePages();
            _application.MainPage = MvvmIoc.Container.Resolve<IPageNavigation>().FindAndCreatePage<TViewModel>(parameter);
        }

        /// <summary>
        /// Switches the root with navigation.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        public void SwitchRootWithNavigation<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel
        {
            DiposePages();
            _application.MainPage = new NavigationPageContainer<TViewModel>(parameter);
        }

        /// <summary>
        /// Navigates back asynchronously.
        /// </summary>
        public async Task NavigateBackAsync()
        {
            if (Navigation() == null) return;
            await Navigation().PopAsync();
        }

        private void DiposePages()
        {
            if (Navigation() == null) return;
        }
    }
}