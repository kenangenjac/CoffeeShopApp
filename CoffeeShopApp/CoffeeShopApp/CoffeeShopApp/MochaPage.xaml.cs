﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeShopApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MochaPage : ContentPage
    {
        int amountCounter;
        public MochaPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            amountCounter = Int32.Parse(amountLabel.Text);
        }

        async void Button_Clicked_MochaBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Button_Clicked_Plus(object sender, EventArgs e)
        {
            amountCounter++;
            amountLabel.Text = amountCounter.ToString();
            double itemPrice = (rb_Small.IsChecked ? 2.00 : (rb_Medium.IsChecked ? 2.50 : 3.00)) * int.Parse(amountLabel.Text);
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
                double itemPrice = (rb_Small.IsChecked ? 2.00 : (rb_Medium.IsChecked ? 2.50 : 3.00)) * int.Parse(amountLabel.Text);
                price.Text = itemPrice.ToString("0.00") + " BAM";
            }
        }

        private void rb_Small_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            double itemPrice = 2.00 * int.Parse(amountLabel.Text);
            price.Text = itemPrice.ToString("0.00") + " BAM";
        }

        private void rb_Medium_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            double itemPrice = 2.50 * int.Parse(amountLabel.Text);
            price.Text = itemPrice.ToString("0.00") + " BAM";
        }

        private void rb_Large_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            double itemPrice = 3.00 * int.Parse(amountLabel.Text);
            //price.Text = coffeePrice.ToString() + " BAM";
            price.Text = string.Format("{0:0.00}", itemPrice) + " BAM";
        }
    }
}