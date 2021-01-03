using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace XamarinMvvm
{
    public abstract class LifeCycleAwareViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IPageNavigation PageNavigation { get; internal set; }
        public INavigationService RootNavigation { get; internal set; }
        public LifeCycleAwareViewModel PreviousViewModel { get; internal set; }
        public bool IsModal { get; internal set; }

        #region View life cycle events

        protected internal virtual Task OnInt(object parameter = null)
        {
            return Task.CompletedTask;
        }

        protected internal virtual Task OnReverseInt(object parameter = null)
        {
            return Task.CompletedTask;
        }

        protected internal virtual Task OnAppearing()
        {
            return Task.CompletedTask;
        }

        protected internal virtual Task OnDisappearing()
        {
            return Task.CompletedTask;
        }

        protected internal virtual Task OnDisose()
        {
            return Task.CompletedTask;
        }

        internal void ViewIsAppearing(object sender, EventArgs e)
        {
            OnAppearing();
        }

        internal void ViewIsDisappearing(object sender, EventArgs e)
        {
            OnDisappearing();
        }

        #endregion

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}