using Xamarin.Forms;

namespace XamarinMvvm
{
    public interface IViewGenerator
    {
        void RegisterPage<TViewModel, TPage>() where TViewModel : LifeCycleAwareViewModel where TPage : Page;
        Page FindAndCreatePage<TViewModel>() where TViewModel : LifeCycleAwareViewModel;
        void SetViewAndViewModelSuffix(string viewSuffix, string viewModelSuffix);
    }
}