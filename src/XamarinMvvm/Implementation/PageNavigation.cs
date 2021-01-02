using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinMvvm
{
    public class PageNavigation : IPageNavigation
    {
        private readonly IViewGenerator _viewGenerator;
        private NavigationPage _navigationPage;
        private bool _isModalOnTop;

        public PageNavigation(IViewGenerator viewGenerator)
        {
            _viewGenerator = viewGenerator;
        }

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

        public INavigation Navigation => NavigationPage?.Navigation;

        public async Task NavigateToAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel
        {
            if (Navigation != null) return;

            var page = FindAndCreatePage<TViewModel>(parameter);
            await Navigation.PushAsync(page, animate);
            _isModalOnTop = false;
        }

        public async Task NavigateToModalAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel
        {
            if (Navigation != null) return;

            var page = FindAndCreatePage<TViewModel>(parameter, true);
            await Navigation.PushModalAsync(page, animate);
            _isModalOnTop = true;
        }

        public async Task NavigateBackAsync()
        {
            if (Navigation != null) return;

            if (_isModalOnTop)
                await Navigation.PopModalAsync();
            else
                await Navigation.PopAsync();
        }

        public async Task NavigateBackAsync(object parameter)
        {
            if (Navigation != null) return;

            if (_isModalOnTop)
            {
                if (Navigation.ModalStack.FirstOrDefault()?.BindingContext is LifeCycleAwareViewModel lifeCycleAwareViewModel)
                {
                    await lifeCycleAwareViewModel.PreviousViewModel?.OnReverseInt(parameter);
                }
            }
            else
            {
                if (Navigation.NavigationStack.FirstOrDefault()?.BindingContext is LifeCycleAwareViewModel lifeCycleAwareViewModel)
                {
                    await lifeCycleAwareViewModel.PreviousViewModel?.OnReverseInt(parameter);
                }
            }

            await NavigateBackAsync(parameter);
        }

        public async Task NavigateToRootAsync()
        {
            if (Navigation != null) return;

            var pagesToPop = Navigation.NavigationStack.Skip(1);
            await Navigation.PopToRootAsync();
            PopPages(pagesToPop);
        }

        public async Task StartNewNavigationAsync<TViewModel>(object parameter = null, bool animate = true) where TViewModel : LifeCycleAwareViewModel
        {
            var navigationPage = new NavigationPageContainer<TViewModel>();
            var page = navigationPage.CreatePage(parameter);
            await Navigation.PushAsync(page, animate);
        }

        internal Page FindAndCreatePage<TViewModel>(object parameter = null, bool modal = false) where TViewModel : LifeCycleAwareViewModel
        {
            var bindingContext = MvvmIoc.Container.Resolve<TViewModel>();
            bindingContext.RootNavigation = MvvmIoc.Container.Resolve<INavigationService>();
            bindingContext.PageNavigation = this;
            bindingContext.IsModal = modal;
            bindingContext.OnInt(parameter);
            var page = _viewGenerator.FindAndCreatePage<TViewModel>();
            WireViewLifeCycleEvents(page, bindingContext);
            page.BindingContext = bindingContext;
            return page;
        }

        private void OnPagePopped(object sender, NavigationEventArgs e)
        {
            PagePopped(e.Page);
        }

        private void PopPages(IEnumerable<Page> pages)
        {
            foreach (Page page in pages)
            {
                PagePopped(page);
            }
        }

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

        private void WireViewLifeCycleEvents(Page page, LifeCycleAwareViewModel bindingContext)
        {
            page.Appearing += new WeakEventHandler<EventArgs>(bindingContext.ViewIsAppearing).Handler;
            page.Disappearing += new WeakEventHandler<EventArgs>(bindingContext.ViewIsDisappearing).Handler;
        }

        private void UnWireViewLifeCycleEvents(Page page, LifeCycleAwareViewModel bindingContext)
        {
            page.Appearing -= bindingContext.ViewIsAppearing;
            page.Disappearing -= bindingContext.ViewIsDisappearing;
        }
    }
}