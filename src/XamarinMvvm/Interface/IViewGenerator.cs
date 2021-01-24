using Xamarin.Forms;

namespace XamarinMvvm
{
    /// <summary>
    /// ViewGenerator.
    /// Generates view for viewmodels
    /// </summary>
    public interface IViewGenerator
    {
        /// <summary>
        /// Registers the page.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TPage">The type of the page.</typeparam>
        void RegisterPage<TViewModel, TPage>() where TViewModel : LifeCycleAwareViewModel where TPage : Page;
        /// <summary>
        /// Finds the and create page.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <returns></returns>
        Page FindAndCreatePage<TViewModel>() where TViewModel : LifeCycleAwareViewModel;
        /// <summary>
        /// Sets the view and view model suffix.
        /// </summary>
        /// <param name="viewSuffix">The view suffix.</param>
        /// <param name="viewModelSuffix">The view model suffix.</param>
        void SetViewAndViewModelSuffix(string viewSuffix, string viewModelSuffix);
    }
}