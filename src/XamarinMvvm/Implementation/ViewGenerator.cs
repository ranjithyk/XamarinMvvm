using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinMvvm
{
    /// <summary>
    /// ViewGenerator.
    /// Generates view for viewmodels
    /// </summary>
    /// <seealso cref="XamarinMvvm.IViewGenerator" />
    public class ViewGenerator : IViewGenerator
    {
        /// <summary>
        /// The viewodel page
        /// </summary>
        readonly Dictionary<Type, Type> _viewodelPage;
        /// <summary>
        /// The view suffix
        /// </summary>
        string _viewSuffix = "Page";
        /// <summary>
        /// The view model suffix
        /// </summary>
        string _viewModelSuffix = "ViewModel";

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewGenerator"/> class.
        /// </summary>
        public ViewGenerator()
        {
            _viewodelPage = new Dictionary<Type, Type>();
        }

        /// <summary>
        /// Registers the page.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TPage">The type of the page.</typeparam>
        public void RegisterPage<TViewModel, TPage>() where TViewModel : LifeCycleAwareViewModel where TPage : Page
        {
            if (_viewodelPage.ContainsKey(typeof(TViewModel)))
                _viewodelPage[typeof(TViewModel)] = typeof(TPage);
            else
                _viewodelPage.Add(typeof(TViewModel), typeof(TPage));
        }

        /// <summary>
        /// Finds the and create page.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <returns></returns>
        public Page FindAndCreatePage<TViewModel>() where TViewModel : LifeCycleAwareViewModel
        {
            var pageType = FindPageForViewModel(typeof(TViewModel));
            var page = (Page)Activator.CreateInstance(pageType);
            return page;
        }

        /// <summary>
        /// Sets the view and view model suffix.
        /// </summary>
        /// <param name="viewSuffix">The view suffix.</param>
        /// <param name="viewModelSuffix">The view model suffix.</param>
        public void SetViewAndViewModelSuffix(string viewSuffix, string viewModelSuffix)
        {
            _viewSuffix = viewSuffix;
            _viewModelSuffix = viewModelSuffix;
        }

        /// <summary>
        /// Finds the page for view model.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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