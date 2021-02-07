using System.Collections.Generic;
using System.Linq;
using XamarinMvvm.Sample.Models;

namespace XamarinMvvm.Sample.Services
{
    public class CatalogService : ICatalogService
    {
        public List<Category> GetAllCategories()
        {
            return Catalog.GetCatalog()?.Categories;
        }

        public Product GetProductDetails(int productId)
        {
            return Catalog.GetCatalog()?.Categories?.SelectMany(c => c.Products)?.FirstOrDefault(p => p.Id == productId);
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return Catalog.GetCatalog()?.Categories?.FirstOrDefault(c => c.Id == categoryId)?.Products;
        }
    }
}
