using System.Collections.Generic;
using PropertyChanged;

namespace XamarinMvvm.Sample.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
