using System.Collections.Generic;
using XamarinMvvm.Sample.Models;

namespace XamarinMvvm.Sample.Services
{
    public interface ICatalogService
    {
        List<Category> GetAllCategories();
        List<Product> GetProductsByCategory(int categoryId);
        Product GetProductDetails(int productId);
    }
}