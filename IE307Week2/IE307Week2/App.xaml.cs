using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IE307Week2.Services.Hotel;

namespace IE307Week2
{
    public partial class App : Application
    {
        public App()
        {
            #region Register services
            DependencyService.Register<IHotelService, MockHotelService>();
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

