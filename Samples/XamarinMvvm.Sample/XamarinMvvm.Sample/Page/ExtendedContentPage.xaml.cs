using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMvvm.Sample.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExtendedContentPage : ContentPage
    {
        public static readonly BindableProperty LoadingTextProperty = BindableProperty.Create(nameof(LoadingText), typeof(string), typeof(ExtendedContentPage), "Loading...");
        public static readonly BindableProperty AppendingTextProperty = BindableProperty.Create(nameof(AppendingText), typeof(string), typeof(ExtendedContentPage), string.Empty);
        public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(ExtendedContentPage));
        public static readonly BindableProperty EmptyTextProperty = BindableProperty.Create(nameof(EmptyText), typeof(string), typeof(ExtendedContentPage), "No Data");
        public static readonly BindableProperty LoadingImageProperty = BindableProperty.Create(nameof(LoadingImage), typeof(FileImageSource), typeof(ExtendedContentPage));
        public static readonly BindableProperty ErrorImageProperty = BindableProperty.Create(nameof(ErrorImage), typeof(FileImageSource), typeof(ExtendedContentPage), "bg_emptytemplate_kpi.svg");
        public static readonly BindableProperty EmptyImageProperty = BindableProperty.Create(nameof(EmptyImage), typeof(FileImageSource), typeof(ExtendedContentPage), "bg_emptytemplate_kpi.svg");
        public static readonly BindableProperty LoadingBackgroundColorProperty = BindableProperty.Create(nameof(LoadingBackgroundColor), typeof(Color), typeof(ExtendedContentPage), Color.White);
        public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(ExtendedContentPage), true);
        public static readonly BindableProperty IsErrorProperty = BindableProperty.Create(nameof(IsError), typeof(bool), typeof(ExtendedContentPage), false);
        public static readonly BindableProperty ShowRetryProperty = BindableProperty.Create(nameof(ShowRetry), typeof(bool), typeof(ExtendedContentPage), true);
        public static readonly BindableProperty IsEmptyProperty = BindableProperty.Create(nameof(IsEmpty), typeof(bool), typeof(ExtendedContentPage), false);
        public static readonly BindableProperty RetryCommandProperty = BindableProperty.Create(nameof(RetryCommand), typeof(ICommand), typeof(ExtendedContentPage), null);
        public static readonly BindableProperty RetryCommandParameterProperty = BindableProperty.Create(nameof(RetryCommandParameter), typeof(object), typeof(ExtendedContentPage), null);
        public static readonly BindableProperty TroubleshootUrlProperty = BindableProperty.Create(nameof(TroubleshootUrl), typeof(string), typeof(ExtendedContentPage), string.Empty);
        public static readonly BindableProperty TroubleshootCommandProperty = BindableProperty.Create(nameof(TroubleshootCommand), typeof(ICommand), typeof(ExtendedContentPage), null);

        public ExtendedContentPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// LoadingText
        /// </summary>
        public string LoadingText
        {
            get { return (string)GetValue(LoadingTextProperty); }
            set { SetValue(LoadingTextProperty, value); }
        }
        /// <summary>
        /// AppendingText
        /// </summary>
        public string AppendingText
        {
            get { return (string)GetValue(AppendingTextProperty); }
            set { SetValue(AppendingTextProperty, value); }
        }
        /// <summary>
        /// ErrorText
        /// </summary>
        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }
        /// <summary>
        /// EmptyText
        /// </summary>
        public string EmptyText
        {
            get { return (string)GetValue(EmptyTextProperty); }
            set { SetValue(EmptyTextProperty, value); }
        }
        /// <summary>
        /// LoadingImage
        /// </summary>
        public FileImageSource LoadingImage
        {
            get { return (FileImageSource)GetValue(LoadingImageProperty); }
            set { SetValue(LoadingImageProperty, value); }
        }
        /// <summary>
        /// ErrorImage
        /// </summary>
        public FileImageSource ErrorImage
        {
            get { return (FileImageSource)GetValue(ErrorImageProperty); }
            set { SetValue(ErrorImageProperty, value); }
        }
        /// <summary>
        /// EmptyImage
        /// </summary>
        public FileImageSource EmptyImage
        {
            get { return (FileImageSource)GetValue(EmptyImageProperty); }
            set { SetValue(EmptyImageProperty, value); }
        }
        /// <summary>
        /// LoadingBackgroundColor
        /// </summary>
        public Color LoadingBackgroundColor
        {
            get { return (Color)GetValue(LoadingBackgroundColorProperty); }
            set { SetValue(LoadingBackgroundColorProperty, value); }
        }
        /// <summary>
        /// IsLoading
        /// </summary>
        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }
        /// <summary>
        /// IsError
        /// </summary>
        public bool IsError
        {
            get { return (bool)GetValue(IsErrorProperty); }
            set { SetValue(IsErrorProperty, value); }
        }
        /// <summary>
        /// ShowRetry
        /// </summary>
        public bool ShowRetry
        {
            get { return (bool)GetValue(ShowRetryProperty); }
            set { SetValue(ShowRetryProperty, value); }
        }
        /// <summary>
        /// ShowRetry
        /// </summary>
        public bool IsEmpty
        {
            get { return (bool)GetValue(IsEmptyProperty); }
            set { SetValue(IsEmptyProperty, value); }
        }
        /// <summary>
        /// RetryCommand
        /// </summary>
        public ICommand RetryCommand
        {
            get { return (ICommand)GetValue(RetryCommandProperty); }
            set { SetValue(RetryCommandProperty, value); }
        }
        /// <summary>
        /// RetryCommandParameter
        /// </summary>
        public object RetryCommandParameter
        {
            get { return GetValue(RetryCommandParameterProperty); }
            set { SetValue(RetryCommandParameterProperty, value); }
        }
        /// <summary>
        /// Troubleshoot url
        /// </summary>
        public string TroubleshootUrl
        {
            get { return (string)GetValue(TroubleshootUrlProperty); }
            set { SetValue(TroubleshootUrlProperty, value); }
        }
        /// <summary>
        /// Troubleshoot command
        /// </summary>
        public ICommand TroubleshootCommand
        {
            get { return (ICommand)GetValue(TroubleshootCommandProperty); }
            set { SetValue(TroubleshootCommandProperty, value); }
        }
    }
}