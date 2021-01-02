using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinMvvm
{
    public interface IPageNavigation
    {
        NavigationPage NavigationPage { get; set; }
        INavigation Navigation { get; }
        Task NavigateToAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel;
        Task NavigateToModalAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel;
        Task NavigateBackAsync();
        Task NavigateBackAsync(object parameter);
        Task NavigateToRootAsync();
        Task StartNewNavigationAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel;
    }
}