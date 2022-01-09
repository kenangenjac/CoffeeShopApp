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
    public partial class CoffeeList : ContentPage
    {
        public CoffeeList()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private User user = new User();
        public CoffeeList(User u)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            user = u;

            userLabel.Text = u.UserFirstName;
        }

        async void Button_Clicked_VisitProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(user));
        }

        async void Button_Clicked_Espresso(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EspressoPage());
        }

        async void Button_Clicked_Cappuccino(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CappuccinoPage());
        }

        async void Button_Clicked_Macchiato(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MacchiatoPage());
        }

        async void Button_Clicked_Mocha(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MochaPage());
        }

        async void Button_Clicked_Latte(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LattePage());
        }
    }
}