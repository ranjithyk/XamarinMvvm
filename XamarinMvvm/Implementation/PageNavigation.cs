using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinMvvm
{
    public class PageNavigation : IPageNavigation
    {
        private readonly IViewGenerator _viewLocator;
        private NavigationPage _navigationPage;

        public PageNavigation(IViewGenerator viewLocator)
        {
            _viewLocator = viewLocator;
        }

        public NavigationPage NavigationPage 
        {
            get => _navigationPage;
            set
            {
                if(value != null)
                {
                    _navigationPage = value;
                    _navigationPage.Popped += OnPagePopped; 
                }
            }
        }

        public INavigation Navigation => NavigationPage?.Navigation;

        public async Task NavigateToAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : ViewLifeCycleAwareViewModel
        {
            var page = _viewLocator.FindAndCreatePage<TViewModel>(parameter);
            await Navigation.PushAsync(page, animate);
        }

        public async Task NavigateToModalAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : ViewLifeCycleAwareViewModel
        {
            var page = _viewLocator.FindAndCreatePage<TViewModel>(parameter);
            await Navigation.PushModalAsync(page, animate);
        }

        public async Task NavigateToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }

        public async Task NavigateBackAsync()
        {
            if (Navigation.ModalStack.Any())
                await Navigation.PopModalAsync();
            else
                await Navigation.PopAsync();
        }

        private void OnPagePopped(object sender, NavigationEventArgs e)
        {
            
        }
    }
}