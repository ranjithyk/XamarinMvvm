using System;
using Xamarin.Forms;

namespace XamarinMvvm
{
    public class ViewGenerator : IViewGenerator
    {
        public Page FindAndCreatePage<TViewModel>(object parameter) where TViewModel : ViewLifeCycleAwareViewModel
        {
            var bindingContext = MvvmIoc.Container.Resolve<TViewModel>();
            return FindAndCreatePage(bindingContext, parameter);
        }

        public Page FindAndCreatePage(ViewLifeCycleAwareViewModel bindingContext, object parameter)
        {
            bindingContext.OnInt(parameter);
            var pageType = FindPageForViewModel(bindingContext.GetType());
            var page = (Page)Activator.CreateInstance(pageType);
            WireViewLifeCycleEvents(page, bindingContext);
            page.BindingContext = bindingContext;
            return page;
        }

        protected virtual Type FindPageForViewModel(Type viewModelType)
        {
            var pageTypeName = viewModelType
                .AssemblyQualifiedName
                .Replace("ViewModel", "View");

            var pageType = Type.GetType(pageTypeName);
            if (pageType == null)
                throw new ArgumentException(pageTypeName + " type does not exist");

            return pageType;
        }

        public void WireViewLifeCycleEvents(Page page, ViewLifeCycleAwareViewModel bindingContext)
        {
            page.Appearing += new WeakEventHandler<EventArgs>(bindingContext.OnAppearing).Handler;
            page.Disappearing += new WeakEventHandler<EventArgs>(bindingContext.OnDisappearing).Handler;
        }
    }
}
