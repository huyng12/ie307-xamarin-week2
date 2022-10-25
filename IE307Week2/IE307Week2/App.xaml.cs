using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IE307Week2.Services.Hotel;
using IE307Week2.Services.AnimalWorld;

namespace IE307Week2
{
    public partial class App : Application
    {
        public App()
        {
            #region Register services
            DependencyService.Register<IHotelService, MockHotelService>();
            DependencyService.Register<IAnimalWorldService, MockAnimalWorldService>();
            #endregion

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

