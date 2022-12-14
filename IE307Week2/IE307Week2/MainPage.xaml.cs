using System;
using System.Collections.Generic;
using System.Windows.Input;

using Xamarin.Forms;

using IE307Week2.Models;
using IE307Week2.Views;
using IE307Week2.Services.Hotel;
using IE307Week2.Services.AnimalWorld;

namespace IE307Week2
{
    public partial class MainPage : ContentPage
    {
        public IHotelService HotelService = DependencyService.Get<IHotelService>();
        public IAnimalWorldService AnimalWorldService = DependencyService.Get<IAnimalWorldService>();

        public MainPage()
        {
            InitializeComponent();
        }

        async void HotelButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var CityView = new IE307Week2.Views.ListView(AppType.Hotel, "Cities", HotelService.GetCities());
            await Navigation.PushAsync(CityView);
        }

        async void AnimalWorldButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var GroupView = new IE307Week2.Views.ListView(AppType.AnimalWorld, "Groups", AnimalWorldService.GetGroups());
            await Navigation.PushAsync(GroupView);
        }
    }
}
