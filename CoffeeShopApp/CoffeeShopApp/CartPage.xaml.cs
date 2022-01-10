using CoffeeShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeShopApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        User user;
        public CartPage(User u)
        {
            InitializeComponent();
            user = u;

            double sum = sumPrices(user.prices);
            priceLabel.Text = sum.ToString() + " BAM";
        }

        async private void Button_Clicked_CartBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        double sumPrices(List<double> prices)
        {
            double sum = 0;

            foreach(double price in prices)
            {
                sum += price;
            }

            return sum;
        }

        async private void Button_Clicked_Checkout(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Your Reciept", "Ukupno: " + sumPrices(user.prices).ToString() + " BAM", "Accept", "Cancel");
            
            if (answer)
            {
                if(user.prices.Count == 0)
                {
                    await DisplayAlert("Warning", "You don't have any items in the cart", "OK");
                }
                else
                {
                    priceLabel.Text = "0.00 BAM";
                    user.prices.Clear();
                    await DisplayAlert("Thank You!", "Your order will soon be ready\nThank you for trusting us!", "OK");
                    await Navigation.PopAsync();
                }
            }
        }

        async private void Button_Clicked_DeleteCart(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Cart", "Da li želite da izbrišete proizvode iz korpe?", "Yes", "Cancel");

            if (answer)
            {
                user.prices.Clear();
                priceLabel.Text = "0.00 BAM";
            }
        }
    }
}