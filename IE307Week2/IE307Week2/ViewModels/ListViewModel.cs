using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using IE307Week2.Models;
using IE307Week2.Services.Hotel;
using IE307Week2.Services.AnimalWorld;


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
            var AnimalWorldService = DependencyService.Get<IAnimalWorldService>();

            if (!item.IsLeaf)
            {
                var title = appType == AppType.Hotel ? "Hotels" : "Species";
                var items = appType == AppType.Hotel
                    ? HotelService.GetHotelsByCityId(item.Id)
                    : AnimalWorldService.GetSpeciesByGroupId(item.Id);
                var HotelView = new IE307Week2.Views.ListView(appType, title, items);
                await Navigation.PushAsync(HotelView);
            }
            else
            {
                var detailItem = appType == AppType.Hotel
                    ? HotelService.GetHotelDetailById(item.Id)
                    : AnimalWorldService.GetSpeciesDetailById(item.Id);
                var DetailView = new IE307Week2.Views.DetailView(detailItem);
                await Navigation.PushAsync(DetailView);
            }
        }
    }
}
