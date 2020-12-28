using System.Threading.Tasks;

namespace XamarinMvvm
{
    public class ViewLifeCycleAwareViewModel : IViewLifeCycleAwareViewModel
    {
        public IPageNavigation PageNavigation { get; internal set; }
        public INavigationService RootNavigation { get; internal set; }

        public virtual Task OnInt(object parameter = null)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnReverseInt(object parameter = null)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnAppearing()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnDisappearing()
        {
            return Task.CompletedTask;
        }
    }
}