using Xamarin.Forms;

namespace XamarinMvvm.Sample
{
    public class App : Application, IApplication
    {
        public App()
        {
            InitIoc();

            var navigation = MvvmIoc.Container.Resolve<INavigationService>();
            navigation.StartApplication(this);
            navigation.SwitchRootNavigation<>();
        }

        void InitIoc()
        {

        }
    }
}