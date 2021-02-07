using Xamarin.Forms;
using XamarinMvvm.Sample.ViewModel;
using XamarinMvvm.Sample.Services;

namespace XamarinMvvm.Sample
{
    public partial class App : Application, IApplication
    {
        public App()
        {
            InitializeComponent();
            MvvmIoc.Container.Register<ICatalogService, CatalogService>();
        }

        protected override void OnStart()
        {
            base.OnStart();
            MvvmIoc.NavigationService.StartApplication<LoginViewModel>(this, true);
        }
    }
}