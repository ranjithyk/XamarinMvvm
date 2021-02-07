using System;
using XamarinMvvm.Sample.Models;

namespace XamarinMvvm.Sample.ViewModel
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        public ProductDetailsViewModel()
        {
        }

        public Product Product { get; set; }

        protected override void OnInit(object parameter = null)
        {
            base.OnInit(parameter);
            if(parameter is Product product)
            {
                Product = product;
            }
        }
    }
}