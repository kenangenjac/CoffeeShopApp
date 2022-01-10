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
    public partial class CappuccinoPage : ContentPage
    {
        int amountCounter;
        User user;
        double itemPrice;

        public CappuccinoPage(User u)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            amountCounter = Int32.Parse(amountLabel.Text);

            user = u;
        }

        async void Button_Clicked_CappuccinoBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Button_Clicked_Plus(object sender, EventArgs e)
        {
            amountCounter++;
            amountLabel.Text = amountCounter.ToString();
            itemPrice = (rb_Small.IsChecked ? 1.50 : (rb_Medium.IsChecked ? 2.00 : 2.50)) * int.Parse(amountLabel.Text);
            price.Text = itemPrice.ToString("0.00") + " BAM";
        }

        private void Button_Clicked_Minus(object sender, EventArgs e)
        {
            if (amountCounter <= 0)
            {
                DisplayAlert("Warning", "Pogresan unos", "OK");
            }
            else
            {
                amountCounter--;
                amountLabel.Text = amountCounter.ToString();
                itemPrice = (rb_Small.IsChecked ? 1.50 : (rb_Medium.IsChecked ? 2.00 : 2.50)) * int.Parse(amountLabel.Text);
                price.Text = itemPrice.ToString("0.00") + " BAM";
            }
        }

        private void rb_Small_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            itemPrice = 1.50 * int.Parse(amountLabel.Text);
            price.Text = itemPrice.ToString("0.00") + " BAM";
        }

        private void rb_Medium_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            itemPrice = 2.00 * int.Parse(amountLabel.Text);
            price.Text = itemPrice.ToString("0.00") + " BAM";
        }

        private void rb_Large_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            itemPrice = 2.50 * int.Parse(amountLabel.Text);
            //price.Text = coffeePrice.ToString() + " BAM";
            price.Text = string.Format("{0:0.00}", itemPrice) + " BAM";
        }

        private void Button_Clicked_Cart(object sender, EventArgs e)
        {
            if (itemPrice <= 0)
            {
                DisplayAlert("Warning", "Niste odabrali proizvod", "OK");
            }
            else
            {
                user.prices.Add(itemPrice);
                itemPrice = 0;
                amountLabel.Text = "0";
                DisplayAlert("Cart", "Items added to cart. Thank You!", "OK");
                price.Text = string.Format("{0:0.00}", itemPrice) + " BAM";
            }
        }
    }
}