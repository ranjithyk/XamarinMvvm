using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMvvm.Sample.ViewModel;

namespace XamarinMvvm.Sample.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTabbedPage : TabbedPage
    {
        public HomeTabbedPage()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext is HomeTabbedViewModel homeTabbedViewModel)
            {
                MvvmIoc.ResolveAndBindViewModel<HomeViewModel>(Children[0]);
                MvvmIoc.ResolveAndBindViewModel<HomeViewModel>(Children[1]);

                AccountsViewModel accountsViewModel = MvvmIoc.ResolveAndBindViewModel<AccountsViewModel>(Children[2]);
                accountsViewModel.UserName = homeTabbedViewModel.UserName;
            }
        }
    }
}