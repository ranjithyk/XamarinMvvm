using Xamarin.Forms;

namespace XamarinMvvm
{
    public interface IViewGenerator
    {
        Page FindAndCreatePage<TViewModel>(object parameter) where TViewModel : ViewLifeCycleAwareViewModel;
        Page FindAndCreatePage(ViewLifeCycleAwareViewModel bindingContext, object parameter);
    }
}