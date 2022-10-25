using System;
using System.Collections.Generic;

using Xamarin.Forms;

using IE307Week2.ViewModels;
using IE307Week2.Models;

namespace IE307Week2.Views
{
    public partial class ListView : ContentPage
    {
        readonly ListViewModel vm;

        public ListView(AppType appType, string title, List<ListViewItem> items)
        {
            BindingContext = vm = new ListViewModel(Navigation, appType, title, items);
            InitializeComponent();
        }

        public void OnItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var item = e.Item as ListViewItem;
            vm.OnItemTapped(item);
        }
    }
}
