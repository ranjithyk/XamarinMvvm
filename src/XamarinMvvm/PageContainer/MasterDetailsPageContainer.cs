using System;
using Xamarin.Forms;

namespace XamarinMvvm
{
    /// <summary>
    /// MasterDetails PageContainer
    /// </summary>
    /// <seealso cref="Xamarin.Forms.MasterDetailPage" />
    /// <seealso cref="XamarinMvvm.IPageContainer" />
    public class MasterDetailsPageContainer : MasterDetailPage, IPageContainer
    {
        /// <summary>
        /// Sets the master.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        public void SetMaster<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel
        {
            var page = MvvmIoc.Container.Resolve<IPageNavigation>().FindAndCreatePage<TViewModel>(parameter);
            Master = page;
        }

        /// <summary>
        /// Sets the details.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="parameter">The parameter.</param>
        public void SetDetails<TViewModel>(object parameter = null) where TViewModel : LifeCycleAwareViewModel
        {
            var page = new NavigationPageContainer<TViewModel>(parameter).GetPage();
            Detail = page;
        }

        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// Master is not set, Set using SetMaster<TViewModel>() method
        /// or
        /// Detail is not set, Set using SetDetails<TViewModel>() method
        /// </exception>
        public Page GetPage()
        {
            if (Master == null)
                throw new Exception("Master is not set, Set using SetMaster<TViewModel>() method");

            if (Detail == null)
                throw new Exception("Detail is not set, Set using SetDetails<TViewModel>() method");

            return this;
        }
    }
}
