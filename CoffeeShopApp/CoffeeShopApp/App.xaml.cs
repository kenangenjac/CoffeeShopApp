using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeShopApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new CoffeeShopApp.MainPage());
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new MainPage();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.Transparent;
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
