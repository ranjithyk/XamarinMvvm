using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace XamarinMvvm
{
    /// <summary>
    /// Complete view life cycle aware viewmodel
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class LifeCycleAwareViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Gets the page navigation.
        /// </summary>
        /// <value>
        /// The page navigation.
        /// </value>
        public IPageNavigation PageNavigation { get; internal set; }
        /// <summary>
        /// Gets the root navigation.
        /// </summary>
        /// <value>
        /// The root navigation.
        /// </value>
        public INavigationService RootNavigation { get; internal set; }
        /// <summary>
        /// Gets the previous view model.
        /// </summary>
        /// <value>
        /// The previous view model.
        /// </value>
        public LifeCycleAwareViewModel PreviousViewModel { get; internal set; }
        /// <summary>
        /// Gets a value indicating whether this instance is modal.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is modal; otherwise, <c>false</c>.
        /// </value>
        public bool IsModal { get; internal set; }

        #region View life cycle events

        /// <summary>
        /// Called when [init].
        /// Called only once for initialization.
        /// Developers can override this and implement for Initialization.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        protected internal virtual void OnInit(object parameter = null)
        {
            // Developers can override this and implement.
        }

        /// <summary>
        /// Called when [init asynchronous].
        /// Called asynchronously only once for initialization.
        /// Developers can override this and implement.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        protected internal virtual Task OnInitAsync(object parameter = null)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when [reverse init]. 
        /// Called  when returinig back with parameter programaticaly.
        /// Developers can override this and implement.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        protected internal virtual void OnReverseInit(object parameter = null)
        {
            // Developers can override this and implement.
        }

        /// <summary>
        /// Called when [reverse init asynchronous]. 
        /// Called asynchronously when returinig back with parameter programaticaly.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        protected internal virtual Task OnReverseInitAsync(object parameter = null)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when [appearing].
        /// Called everytime when view appears.
        /// Developers can override this and implement.
        /// </summary>
        /// <returns></returns>
        protected internal virtual void OnAppearing()
        {
            //Developers can override this and implement.
        }

        /// <summary>
        /// Called when [appearing asynchronous].
        /// Called asynchronously everytime when view appears.
        /// </summary>
        /// <returns></returns>
        protected internal virtual Task OnAppearingAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when [disappearing].
        /// Called everytime when view disaapers.
        /// Developers can override this and implement.
        /// </summary>
        /// <returns></returns>
        protected internal virtual void OnDisappearing()
        {
            //Developers can override this and implement.
        }

        /// <summary>
        /// Called when [disappearing asynchronous].
        /// Called asynchronously everytime when view disaapers.
        /// Developers can override this and implement.
        /// </summary>
        /// <returns></returns>
        protected internal virtual Task OnDisappearingAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when [disose]. Called when view popped to dispose.
        /// Developers can override this and implement.
        /// </summary>
        /// <returns></returns>
        protected internal virtual Task OnDisose()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// View is appearing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        internal void ViewIsAppearing(object sender, EventArgs e)
        {
            OnAppearing();
            OnAppearingAsync();
        }

        /// <summary>
        /// View is disappearing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        internal void ViewIsDisappearing(object sender, EventArgs e)
        {
            OnDisappearing();
            OnDisappearingAsync();
        }

        #endregion

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}