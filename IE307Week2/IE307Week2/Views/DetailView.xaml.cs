using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IE307Week2.ViewModels;
using IE307Week2.Models;

namespace IE307Week2.Views
{
    public partial class DetailView : ContentPage
    {
        public DetailView(DetailItem item)
        {
            BindingContext = new DetailViewModel(item);
            InitializeComponent();
        }
    }
}
