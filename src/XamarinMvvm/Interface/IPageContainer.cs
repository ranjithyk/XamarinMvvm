using Xamarin.Forms;

namespace XamarinMvvm
{
    public interface IPageContainer
    {
        Page CreatePage(object parameter = null);
    }
}