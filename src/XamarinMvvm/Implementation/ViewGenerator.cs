using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinMvvm
{
    public class ViewGenerator : IViewGenerator
    {
        readonly Dictionary<Type, Type> _viewodelPage;
        string _viewSuffix = "View";
        string _viewModelSuffix = "ViewModel";

        public ViewGenerator()
        {
            _viewodelPage = new Dictionary<Type, Type>();
        }

        public void RegisterPage<TViewModel, TPage>() where TViewModel : LifeCycleAwareViewModel where TPage : Page
        {
            if (_viewodelPage.ContainsKey(typeof(TViewModel)))
                _viewodelPage[typeof(TViewModel)] = typeof(TPage);
            else
                _viewodelPage.Add(typeof(TViewModel), typeof(TPage));
        }

        public Page FindAndCreatePage<TViewModel>() where TViewModel : LifeCycleAwareViewModel
        {
            var pageType = FindPageForViewModel(typeof(TViewModel));
            var page = (Page)Activator.CreateInstance(pageType);
            return page;
        }

        public void SetViewAndViewModelSuffix(string viewSuffix, string viewModelSuffix)
        {
            _viewSuffix = viewSuffix;
            _viewModelSuffix = viewModelSuffix;
        }

        protected virtual Type FindPageForViewModel(Type viewModelType)
        {
            if (_viewodelPage.ContainsKey(viewModelType))
                return _viewodelPage[viewModelType];

            var pageTypeName = viewModelType
                .AssemblyQualifiedName
                .Replace(_viewModelSuffix, _viewSuffix);

            var pageType = Type.GetType(pageTypeName);
            if (pageType == null)
                throw new ArgumentException(pageTypeName + " type does not exist");

            return pageType;
        }
    }
}
