using Xamarin.Forms;
using XamarinMvvm.Sample.ViewModel;

namespace XamarinMvvm.Sample
{
    public partial class App : Application, IApplication
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            MvvmIoc.NavigationService.StartApplication<LoginViewModel>(this, true);
        }
    }
}
