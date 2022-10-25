using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using IE307Week2.Models;
using IE307Week2.Services.Hotel;
using System.Runtime.CompilerServices;

namespace IE307Week2.ViewModels
{
    public class ListViewModel
    {
        readonly INavigation Navigation;

        private readonly AppType appType;

        public string Title { get; set; }

        public List<ListViewItem> Items { get; set; }

        public ListViewModel(INavigation navigation, AppType appType, string title, List<ListViewItem> items)
        {
            this.appType = appType;
            Title = title;
            Items = items;
            Navigation = navigation;
        }

        public async void OnItemTapped(ListViewItem item)
        {
            var HotelService = DependencyService.Get<IHotelService>();

            if (!item.IsLeaf)
            {
                var HotelView = new IE307Week2.Views.ListView(
                    appType, "Hotels", HotelService.GetHotelsByCityId(item.Id));
                await Navigation.PushAsync(HotelView);
            }
            else
            {
                var detailItem = HotelService.GetHotelDetailById(item.Id);
                var DetailView = new IE307Week2.Views.DetailView(detailItem);
                await Navigation.PushAsync(DetailView);
            }
        }
    }
}
