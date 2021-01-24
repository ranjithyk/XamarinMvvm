using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinMvvm
{
    /// <summary>
    /// Page Navigation
    /// </summary>
    /// <seealso cref="XamarinMvvm.IPageNavigation" />
    public class PageNavigation : IPageNavigation
    {
        /// <summary>
        /// The view generator
        /// </summary>
        private readonly IViewGenerator _viewGenerator;
        /// <summary>
        /// The navigation page
        /// </summary>
        private NavigationPage _navigationPage;
        /// <summary>
        /// The is modal on top
        /// </summary>
        private bool _isModalOnTop;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageNavigation"/> class.
        /// </summary>
        /// <param name="viewGenerator">The view generator.</param>
        public PageNavigation(IViewGenerator viewGenerator)
        {
            _viewGenerator = viewGenerator;
        }

        /// <summary>
        /// Gets or sets the navigation page.
        /// </summary>
        /// <value>
        /// The navigation page.
        /// </value>
        public NavigationPage NavigationPage
        {
            get => _navigationPage;
            set
            {
                if (_navigationPage != null)
                {
                    _navigationPage.Popped -= OnPagePopped;
                }

                if (value != null)
                {
                    _navigationPage = value;
                    _navigationPage.Popped += OnPagePopped;
                }
            }
        }

        /// <summary>
        /// Gets the navigation.
        /// </summary>
        /// <value>
        /// The navigation.
        /// </value>
        public INavigation Navigation => NavigationPage?.Navigation ?? MvvmIoc.NavigationService.Navigation();

        /// <summary>
        /// Navigates asynchronously.
        /// </summary>
        /// <param name="pageContainer">The page container.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        public async Task NavigateToAsync(IPageContainer pageContainer, bool animate = true)
        {
            if (Navigation == null) return;

            var page = pageContainer.GetPage();
            await Navigation.PushAsync(page, animate);
            _isModalOnTop = false;
        }

        /// <summary>
        /// Navigates asynchronously.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        public async Task NavigateToAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel
        {
            if (Navigation == null) return;

            var page = FindAndCreatePage<TViewModel>(parameter);
            await Navigation.PushAsync(page, animate);
            _isModalOnTop = false;
        }

        /// <summary>
        /// Navigates to modal asynchronously.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        public async Task NavigateToModalAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel
        {
            if (Navigation == null) return;

            var page = FindAndCreatePage<TViewModel>(parameter, true);
            await Navigation.PushModalAsync(page, animate);
            _isModalOnTop = true;
        }

        /// <summary>
        /// Navigates the back asynchronously.
        /// </summary>
        public async Task NavigateBackAsync()
        {
            if (Navigation == null) return;

            if (_isModalOnTop)
                await Navigation.PopModalAsync();
            else
                await Navigation.PopAsync();
        }

        /// <summary>
        /// Navigates the back asynchronously.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public async Task NavigateBackAsync(object parameter)
        {
            if (Navigation == null) return;

            var currentViewModel = GetCurrentViewModel();
            if (currentViewModel?.PreviousViewModel != null)
            {
                currentViewModel.PreviousViewModel.OnReverseInit(parameter);
                await currentViewModel.PreviousViewModel.OnReverseInitAsync(parameter);
            }

            await NavigateBackAsync();
        }

        /// <summary>
        /// Navigates to root asynchronously.
        /// </summary>
        public async Task NavigateToRootAsync()
        {
            if (Navigation == null) return;

            var pagesToPop = Navigation.NavigationStack.Skip(1);
            await Navigation.PopToRootAsync();
            PopPages(pagesToPop);
        }

        /// <summary>
        /// Starts the new navigation asynchronously.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        public async Task StartNewNavigationAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel
        {
            var navigationPage = new NavigationPageContainer<TViewModel>(parameter);
            var page = navigationPage.GetPage();
            await Navigation.PushAsync(page, animate);
        }

        /// <summary>
        /// Finds and create page.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="modal">if set to <c>true</c> [modal].</param>
        /// <returns></returns>
        internal Page FindAndCreatePage<TViewModel>(object parameter = null, bool modal = false) where TViewModel : LifeCycleAwareViewModel
        {
            var bindingContext = MvvmIoc.Container.Resolve<TViewModel>();
            bindingContext.RootNavigation = MvvmIoc.Container.Resolve<INavigationService>();
            bindingContext.PageNavigation = this;
            bindingContext.PreviousViewModel = GetCurrentViewModel();
            bindingContext.IsModal = modal;
            bindingContext.OnInit(parameter);
            bindingContext.OnInitAsync(parameter);
            var page = _viewGenerator.FindAndCreatePage<TViewModel>();
            WireViewLifeCycleEvents(page, bindingContext);
            page.BindingContext = bindingContext;
            return page;
        }

        /// <summary>
        /// Called when [page popped].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        private void OnPagePopped(object sender, NavigationEventArgs e)
        {
            PagePopped(e.Page);
        }

        /// <summary>
        /// Pops the pages.
        /// </summary>
        /// <param name="pages">The pages.</param>
        private void PopPages(IEnumerable<Page> pages)
        {
            foreach (Page page in pages)
            {
                PagePopped(page);
            }
        }

        /// <summary>
        /// Pages popped.
        /// </summary>
        /// <param name="page">The page.</param>
        private void PagePopped(Page page)
        {
            if (page?.BindingContext is LifeCycleAwareViewModel lifeCycleAwareViewModel)
            {
                UnWireViewLifeCycleEvents(page, lifeCycleAwareViewModel);
                page.BindingContext = null;
                _isModalOnTop = lifeCycleAwareViewModel.PreviousViewModel?.IsModal ?? false;
                lifeCycleAwareViewModel.OnDisose();
            }
        }

        /// <summary>
        /// Wires the view life cycle events.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="bindingContext">The binding context.</param>
        private void WireViewLifeCycleEvents(Page page, LifeCycleAwareViewModel bindingContext)
        {
            page.Appearing += new WeakEventHandler<EventArgs>(bindingContext.ViewIsAppearing).Handler;
            page.Disappearing += new WeakEventHandler<EventArgs>(bindingContext.ViewIsDisappearing).Handler;
        }

        /// <summary>
        /// Un wire the view life cycle events.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="bindingContext">The binding context.</param>
        private void UnWireViewLifeCycleEvents(Page page, LifeCycleAwareViewModel bindingContext)
        {
            page.Appearing -= bindingContext.ViewIsAppearing;
            page.Disappearing -= bindingContext.ViewIsDisappearing;
        }

        /// <summary>
        /// Gets the current view model.
        /// </summary>
        /// <returns></returns>
        private LifeCycleAwareViewModel GetCurrentViewModel()
        {
            if (Navigation == null) return null;

            var lastPage = _isModalOnTop ? Navigation.ModalStack.LastOrDefault() : Navigation.NavigationStack.LastOrDefault();
            if (lastPage?.BindingContext is LifeCycleAwareViewModel lifeCycleAwareViewModel)
            {
                return lifeCycleAwareViewModel;
            }

            return null;
        }
    }
}