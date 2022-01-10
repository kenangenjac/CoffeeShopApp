using CoffeeShopApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoffeeShopApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void Button_Clicked_ShowRegisterPage(object sender, EventArgs e)
        {
            //var registerPage = new ContentPage();
            //Navigation.PushAsync(registerPage);
            //Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(registerPage));
            
             await Navigation.PushAsync(new Register());            
        }
        private void Button_Clicked_ShowLoginPage(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Login());
        }
    }
}
