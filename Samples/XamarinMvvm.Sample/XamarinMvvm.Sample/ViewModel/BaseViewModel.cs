using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinMvvm.Sample.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : LifeCycleAwareViewModel
    {
        public BaseViewModel()
        {
            BackCommand = new Command(async () => await OnNavigateBackAsync());
        }

        public ICommand BackCommand { get; }
        public string Title { get; set; }
        public bool IsLoading { get; set; }

        protected virtual async Task OnNavigateBackAsync(object parameter = null)
        {
            await PageNavigation.NavigateBackAsync();
        }
    }
}