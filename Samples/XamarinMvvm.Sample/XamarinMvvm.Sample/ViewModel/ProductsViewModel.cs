using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using XamarinMvvm.Sample.Models;

namespace XamarinMvvm.Sample.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class ProductsViewModel : BaseViewModel
    {
        public ProductsViewModel()
        {
            ProductDetailsCommand = new AsyncCommand<Product>(OnProductDetails);
        }

        public Category Category { get; set; }
        public Product SelectedProduct { get; set; }
        public ICommand ProductDetailsCommand { get; }

        protected override void OnInit(object parameter = null)
        {
            base.OnInit(parameter);

            if(parameter is Category category)
            {
                Category = category;
                Title = category.Title;
            }
        }

        private async Task OnProductDetails(Product product)
        {
            if (product == null)
                return;

            await PageNavigation.NavigateToAsync<ProductDetailsViewModel>(product);

            SelectedProduct = null;
        }
    }
}
