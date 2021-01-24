namespace XamarinMvvm.Sample.ViewModel
{
    public class HomeTabbedViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        protected override void OnInit(object parameter = null)
        {
            base.OnInit(parameter);
            if (parameter != null)
            {
                UserName = parameter.ToString();
            }
        }
    }
}
