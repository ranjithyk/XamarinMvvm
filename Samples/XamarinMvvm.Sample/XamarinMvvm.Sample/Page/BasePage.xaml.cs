﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMvvm.Sample.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePage : ContentPage
    {
        public BasePage()
        {
            InitializeComponent();
        }
    }
}