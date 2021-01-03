using XamarinIoc;

namespace XamarinMvvm
{
    public static class MvvmIoc
    {
        static XamarinTinyIoCContainer _xamarinTinyIoCContainer;

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

        public static INavigationService NavigationService => Container.Resolve<INavigationService>();

        public static void OverrideContainer(XamarinTinyIoCContainer overrideContainer)
        {
            _xamarinTinyIoCContainer = overrideContainer;
            Init();
        }

        private static void Init()
        {
            _xamarinTinyIoCContainer.Register<IViewGenerator, ViewGenerator>();
            _xamarinTinyIoCContainer.Register<INavigationService, NavigationService>();
            _xamarinTinyIoCContainer.Register<IPageNavigation, PageNavigation>().AsMultiInstance();
        }
    }
}