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

            firstNameLabel.Text = user.UserFirstName;
            lastNameLabel.Text = user.UserLastName;
            mailLabel.Text = user.UserEmail;
            dateLabel.Text = (user.UserBirthDAte.Date).ToString("d");
        }

        async void Button_Clicked_Cart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage(user));
        }

        async void Button_Clicked_ProfileBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async private void Button_Clicked_Logout(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Logout", "Are You sure You want to Log Out?", "Yes", "No");

            if (answer)
            {
                await Navigation.PopToRootAsync();
                //await Navigation.PushAsync(new Login(user));
            }
        }
    }
}