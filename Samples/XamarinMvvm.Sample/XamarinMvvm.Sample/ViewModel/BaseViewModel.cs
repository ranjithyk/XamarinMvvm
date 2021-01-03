using PropertyChanged;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinMvvm.Sample.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : LifeCycleAwareViewModel
    {
        public BaseViewModel()
        {
            BackCommand = new Command(() => RootNavigation.Navigation().PopAsync());
        }

        public ICommand BackCommand { get; }
        public string Title { get; set; }
        public bool IsLoading { get; set; }
    }
}