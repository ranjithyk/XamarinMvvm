using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinMvvm.Sample.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : LifeCycleAwareViewModel
    {
        public BaseViewModel()
        {
            BackCommand = new AsyncCommand(OnNavigateBackAsync);
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