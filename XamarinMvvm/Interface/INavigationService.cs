namespace XamarinMvvm
{
    public interface INavigationService
    {
        void StartApplication(IApplication application);
        void SwitchRoot<TViewModel>(object parameter = null) where TViewModel : ViewLifeCycleAwareViewModel;
        void SwitchRootNavigation<TViewModel>(object parameter = null) where TViewModel : ViewLifeCycleAwareViewModel;
    }
}