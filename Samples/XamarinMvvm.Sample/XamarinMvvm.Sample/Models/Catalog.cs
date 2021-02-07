using System.Collections.Generic;

namespace XamarinMvvm.Sample.Models
{
    public class Catalog
    {
        public int Version { get; set; }
        public List<Category> Categories { get; set; }

        private static string placeholderImage = "ic_placeholder.png";
        private static Catalog catalog;
        public static Catalog GetCatalog()
        {
            if (catalog != null)
                return catalog;

            catalog = new Catalog
            {
                Version = 1,
                Categories = new List<Category>
                {
                    new Category
                    {
                        Id = 1,
                        Title = "Electronics",
                        Description = "Buy all electrnic item",
                        Image = placeholderImage,
                        Products = new List<Product>
                        {
                            new Product { Id = 1, Title = "Phone", Description = "Mobile Phones", Image = placeholderImage, Price = 18000 },
                            new Product { Id = 2, Title = "Refrigirator", Description = "Store your food", Image = placeholderImage, Price = 25000 },
                            new Product { Id = 3, Title = "TV", Description = "Watch on big screen", Image = placeholderImage, Price = 56000 },
                            new Product { Id = 4, Title = "Iron Box", Description = "Iron your cloths", Image = placeholderImage, Price = 4000 },
                        }
                    },
                    new Category
                    {
                        Id = 2,
                        Title = "Cloths",
                        Description = "Mens, Womens, Kids clothing",
                        Image = placeholderImage,
                        Products = new List<Product>
                        {
                            new Product { Id = 5, Title = "Pants", Description = "Pants", Image = placeholderImage, Price = 450 },
                            new Product { Id = 6, Title = "T-Shirts", Description = "Half sleev T-Shirts", Image = placeholderImage, Price = 300 },
                            new Product { Id = 7, Title = "Ladies T-Shirts", Description = "Half sleev T-Shirts", Image = placeholderImage, Price = 250 },
                            new Product { Id = 8, Title = "Kids Cloths", Description = "For kids", Image = placeholderImage, Price = 600 },
                        }
                    },
                    new Category
                    {
                        Id = 3,
                        Title = "Women",
                        Description = "Womens",
                        Image = placeholderImage,
                        Products = new List<Product>
                        {
                            new Product { Id = 9, Title = "Pants", Description = "Pants", Image = placeholderImage, Price = 450 },
                            new Product { Id = 10, Title = "T-Shirts", Description = "Half sleev T-Shirts", Image = placeholderImage, Price = 300 },
                            new Product { Id = 11, Title = "Ladies T-Shirts", Description = "Half sleev T-Shirts", Image = placeholderImage, Price = 250 },
                            new Product { Id = 12, Title = "Kids Cloths", Description = "For kids", Image = placeholderImage, Price = 600 },
                        }
                    },
                    new Category
                    {
                        Id = 4,
                        Title = "Mens",
                        Description = "Men",
                        Image = placeholderImage,
                        Products = new List<Product>
                        {
                            new Product { Id = 13, Title = "Pants", Description = "Pants", Image = placeholderImage, Price = 450 },
                            new Product { Id = 14, Title = "T-Shirts", Description = "Half sleev T-Shirts", Image = placeholderImage, Price = 300 },
                            new Product { Id = 15, Title = "Ladies T-Shirts", Description = "Half sleev T-Shirts", Image = placeholderImage, Price = 250 },
                            new Product { Id = 16, Title = "Kids Cloths", Description = "For kids", Image = placeholderImage, Price = 600 },
                        }
                    }
                }
            };

            return catalog;
        }
    }
}
