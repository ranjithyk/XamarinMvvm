using Xamarin.Forms;

namespace XamarinMvvm
{
    /// <summary>
    /// PageContainer, Implement this to have custom page containers
    /// </summary>
    public interface IPageContainer
    {
        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <returns></returns>
        Page GetPage();
    }
}