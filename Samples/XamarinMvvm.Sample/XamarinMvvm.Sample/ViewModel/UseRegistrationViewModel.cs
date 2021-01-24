using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinMvvm.Sample.ViewModel
{
    public class UseRegistrationViewModel : BaseViewModel
    {
        public UseRegistrationViewModel()
        {
            RegisterCommand = new AsyncCommand(OnRegister);
        }

        public ICommand RegisterCommand { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        private async Task OnRegister()
        {
            Message = string.Empty;

            if (string.IsNullOrEmpty(UserName))
            {
                Message = "Please enter user name";
                return;
            }

            if (UserName.Length < 6)
            {
                Message = "Please enter valid user name";
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                Message = "Please enter Password";
                return;
            }

            if (Password.Length < 4)
            {
                Message = "Please enter valid Password";
                return;
            }

            await PageNavigation.NavigateBackAsync($"{UserName} is Registered Succesfully");
        }
    }
}
