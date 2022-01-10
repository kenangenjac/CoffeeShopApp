using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoffeeShopApp.Models;
using CoffeeShopApp;

namespace CoffeeShopApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        List<User> users = new List<User>();
        User user;
        bool isSingleUser;
        public Login(IList<User> u)
        {
            InitializeComponent();
            users = (List<User>)u;
            isSingleUser = false;
        }

        public Login(User u, bool isUser)
        {
            InitializeComponent();
            user = u;
            //users.Add(user);
            isSingleUser = isUser;
        }

        private bool CheckEntry()
        {
            string email = email_Login.Text;
            string password = password_Login.Text;

            if (email == null || password == null)
            {
                return false;
            }

            return true;
        }

        async void Button_Clicked_Login(object sender, EventArgs e)
        {
            if (CheckEntry())
            {
                bool isFound = false;
                int index = 0;
                //bool isList = false;

                if(isSingleUser)
                {
                    if (user.UserEmail == email_Login.Text && user.UserPassword == password_Login.Text)
                    {
                        isFound = true;
                    }

                    if (!isFound)
                    {
                        await DisplayAlert("Warning", "Netačan email ili password", "OK");
                    }
                    else
                    {
                        await Navigation.PushAsync(new CoffeeList(user));
                    }
                }
                else
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (email_Login.Text == users[i].UserEmail && password_Login.Text == users[i].UserPassword)
                        {
                            isFound = true;
                            index = i;
                            break;
                        }
                    }

                    if (!isFound)
                    {
                        await DisplayAlert("Warning", "Netačan email ili password", "OK");
                    }
                    else
                    {
                        await Navigation.PushAsync(new CoffeeList(users[index]));
                    }
                }
            }
            else
            {
                await DisplayAlert("Warning", "Molimo unesite podatke", "OK");
            }
        }

        async void Button_Clicked_ShowRegisterPage(object sender, EventArgs e)
        {
            users.Add(user);
            await Navigation.PushAsync(new Register(users));
        }
    }
}