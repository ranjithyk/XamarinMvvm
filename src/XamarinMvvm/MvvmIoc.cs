using Xamarin.Forms;
using XamarinIoc;

namespace XamarinMvvm
{
    /// <summary>
    /// MvvmIoc
    /// </summary>
    public static class MvvmIoc
    {
        /// <summary>
        /// The xamarin tiny io c container
        /// </summary>
        static XamarinTinyIoCContainer _xamarinTinyIoCContainer;

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static XamarinTinyIoCContainer Container
        {
            get
            {
                if (_xamarinTinyIoCContainer == null)
                {
                    _xamarinTinyIoCContainer = new XamarinTinyIoCContainer();
                    Init();
                }

                return _xamarinTinyIoCContainer;
            }
        }

        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        /// <value>
        /// The navigation service.
        /// </value>
        public static INavigationService NavigationService => Container.Resolve<INavigationService>();

        /// <summary>
        /// Overrides the container.
        /// </summary>
        /// <param name="overrideContainer">The override container.</param>
        public static void OverrideContainer(XamarinTinyIoCContainer overrideContainer)
        {
            _xamarinTinyIoCContainer = overrideContainer;
            Init();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private static void Init()
        {
            _xamarinTinyIoCContainer.Register<IViewGenerator, ViewGenerator>();
            _xamarinTinyIoCContainer.Register<INavigationService, NavigationService>();
            _xamarinTinyIoCContainer.Register<IPageNavigation, PageNavigation>().AsMultiInstance();
        }

        /// <summary>
        /// Resolves the view model.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="page">The page.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="modal">if set to <c>true</c> [modal].</param>
        /// <returns></returns>
        public static TViewModel ResolveAndBindViewModel<TViewModel>(Page page, object parameter = null, bool modal = false) where TViewModel : LifeCycleAwareViewModel
        {
            return Container.Resolve<IPageNavigation>().ResolveAndWireViewModel<TViewModel>(page, parameter, modal);
        }
    }
}