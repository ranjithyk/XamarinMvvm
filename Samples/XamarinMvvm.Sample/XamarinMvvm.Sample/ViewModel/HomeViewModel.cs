﻿using PropertyChanged;

namespace XamarinMvvm.Sample.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            Title = "Home";
        }
    }
}