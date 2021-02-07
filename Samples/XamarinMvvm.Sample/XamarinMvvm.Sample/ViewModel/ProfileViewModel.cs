using System;
namespace XamarinMvvm.Sample.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel()
        {
            Title = "Profile";
        }

        public string UserName { get; set; }

        protected override void OnInit(object parameter = null)
        {
            if (parameter != null)
            {
                UserName = parameter.ToString();
            }
        }
    }
}
