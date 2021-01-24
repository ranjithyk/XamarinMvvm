using Xamarin.Forms;

namespace XamarinMvvm
{
    /// <summary>
    /// Application, Implement in Xamarn.Forms Application class
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// Gets or sets the main page.
        /// </summary>
        /// <value>
        /// The main page.
        /// </value>
        Page MainPage { get; set; }
    }
}