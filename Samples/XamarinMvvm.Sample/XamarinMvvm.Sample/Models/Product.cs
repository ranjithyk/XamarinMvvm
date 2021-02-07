using PropertyChanged;

namespace XamarinMvvm.Sample.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}