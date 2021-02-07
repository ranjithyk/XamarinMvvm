using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using XamarinMvvm.Sample.Models;
using XamarinMvvm.Sample.Services;

namespace XamarinMvvm.Sample.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class CatalogViewModel : BaseViewModel
    {
        readonly ICatalogService _catalogService;
        public CatalogViewModel(ICatalogService catalogService)
        {
            _catalogService = catalogService;
            Title = "Catalog";

            CategorySelectionCommand = new AsyncCommand<Category>(OnCategorySelectionAsync);
            ProductDetailsCommand = new AsyncCommand<Product>(OnProductDetailsAsync);
        }

        public List<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }
        public ICommand CategorySelectionCommand { get; }
        public ICommand ProductDetailsCommand { get; }

        protected override void OnInit(object parameter = null)
        {
            base.OnInit(parameter);
            Categories = _catalogService.GetAllCategories();
        }

        private async Task OnCategorySelectionAsync(Category category)
        {
            if (category == null)
                return;

            await PageNavigation.NavigateToAsync<ProductsViewModel>(category);

            SelectedCategory = null;
        }

        private async Task OnProductDetailsAsync(Product product)
        {
            await PageNavigation.NavigateToAsync<ProductDetailsViewModel>(product);
        }
    }
}
