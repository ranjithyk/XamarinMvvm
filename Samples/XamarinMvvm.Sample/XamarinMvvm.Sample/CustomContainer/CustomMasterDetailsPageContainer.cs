using XamarinMvvm.Sample.ViewModel;

namespace XamarinMvvm.Sample.CustomContainer
{
    public class CustomMasterDetailsPageContainer : MasterDetailsPageContainer
    {
        public CustomMasterDetailsPageContainer(object parameter = null)
        {
            SetMaster<AccountsViewModel>(parameter);
            SetDetails<CatalogViewModel>();

            if (Master.BindingContext is AccountsViewModel accountsViewModel)
                accountsViewModel.OnSwitchDetails += OnSwitchDetails;
        }

        private void OnSwitchDetails(string page)
        {
            switch (page)
            {
                case "Home":
                    SetDetails<CatalogViewModel>();
                    break;

                case "Profile":
                    SetDetails<CatalogViewModel>();
                    break;

                case "Settings":
                    SetDetails<SettingsViewModel>();
                    break;

                case "History":
                    SetDetails<HistoryViewModel>();
                    break;

                case "Address":
                    SetDetails<AddressViewModel>();
                    break;

                case "Payments":
                    SetDetails<PaymentsViewModel>();
                    break;
            }
        }
    }
}