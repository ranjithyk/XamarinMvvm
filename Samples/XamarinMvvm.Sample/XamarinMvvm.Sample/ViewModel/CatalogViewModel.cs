using PropertyChanged;

namespace XamarinMvvm.Sample.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class CatalogViewModel : BaseViewModel
    {
        public CatalogViewModel()
        {
            Title = "Catalog";
        }
    }
}
