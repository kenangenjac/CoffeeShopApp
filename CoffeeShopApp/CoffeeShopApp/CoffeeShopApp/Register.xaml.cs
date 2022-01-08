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
    public partial class Register : ContentPage
    {
        public IList<User> users = new List<User>();

        public Register()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public Register(List<User> u)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            users = u;
        }

        private bool CheckEntry()
        {
            string firstName = firstName_Register.Text;
            string lastName = lastName_Register.Text;
            string email = email_Register.Text;
            DateTime birthDate = dateOfBirth.Date;
            string password = password_Register.Text;

            if (firstName == null || lastName == null || email == null || birthDate == null || password == null)
            {
                return false;
            }

            return true;
        }

        private User createUser()
        {
            string firstName = firstName_Register.Text;
            string lastName = lastName_Register.Text;
            string email = email_Register.Text;
            DateTime birthDate = dateOfBirth.Date;
            string password = password_Register.Text;

            return new User(firstName, lastName, email, birthDate, password);
        }

        async void Button_Clicked_Register(object sender, EventArgs e)
        {
            if (CheckEntry())
            {
                users.Add(createUser());
                await Navigation.PushAsync(new Login(users));
            }
            else
            {
                await DisplayAlert("Warning", "Molimo unesite podatke", "OK");
            }
        }

        async void Button_Clicked_LoginPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login(users));
        }
    }
}

