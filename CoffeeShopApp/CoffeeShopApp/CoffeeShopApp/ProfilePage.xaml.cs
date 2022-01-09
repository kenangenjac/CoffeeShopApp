using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoffeeShopApp.Models;

namespace CoffeeShopApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        User user;
        public ProfilePage(User u)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            user = u;
        }

        async void Button_Clicked_ChangeInfo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangeInfoPage());
        }

        async void Button_Clicked_Cart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }

        async void Button_Clicked_ProfileBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }
    }
}