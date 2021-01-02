namespace XamarinMvvm
{
    public interface INavigationService
    {
        void StartApplication(IApplication application);
        void SwitchRoot(IPageContainer pageContainer, object parameter = null);
        void SwitchRoot<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel;
        void SwitchRootWithNavigation<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel;
    }
}