using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinMvvm
{
    public interface INavigationService
    {
        IApplication Application();
        INavigation  Navigation();
        void StartApplication(IApplication application);
        void StartApplication(IApplication application, IPageContainer pageContainer);
        void StartApplication<TViewModel>(IApplication application, bool navigatable, object parameter = null) where TViewModel : LifeCycleAwareViewModel;
        void SwitchRoot(IPageContainer pageContainer);
        void SwitchRoot<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel;
        void SwitchRootWithNavigation<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel;
        Task NavigateBackAsync();
    }
}