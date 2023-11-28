using MobileTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTestApp
{
	
	public partial class Registration : ContentPage
	{
		public Registration ()
		{
			InitializeComponent ();
		}

        private async void authButton_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new Authorization());
        }

        private async void regButton_Clicked(object sender, EventArgs e)
        {
			string login = loginField.Text.Trim();
			string email = emailField.Text.Trim();
			string password = passwordField.Text.Trim();

            if (login.Equals("") || !email.Contains("@") || password.Length < 3)
            {
                await DisplayAlert("", "Something went wrong", "OK");
                return;
            }

            /*if (App.Db.GetUserList() != null)
            {
                User authUser = App.Db.GetUserByLogin(login);
                if (authUser != null)
                {
                    await DisplayAlert("", "This user already exists", "OK");
                    return;
                }

            }*/

            User user = new User()
            {
                Login = login,
                Email = email,
                Password = Hash(password)
            
			};
            App.Db.Create(user);

            loginField.Text = "";
            emailField.Text = "";
            passwordField.Text = "";

            await Navigation.PushAsync(new Authorization());


        }
        private string Hash(string input)
        {
            byte[] temp = Encoding.UTF8.GetBytes(input);
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(temp);
                return Convert.ToBase64String(hash);
            }
        }
    }
}