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
    }
}