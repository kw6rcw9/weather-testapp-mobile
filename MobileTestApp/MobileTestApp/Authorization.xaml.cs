using MobileTestApp.Data.Models;
using MobileTestApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTestApp
{
	
	public partial class Authorization : ContentPage
	{
		public Authorization ()
		{
			InitializeComponent ();
		}
      
        private async void authButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(loginField.Text)
                || string.IsNullOrEmpty(passwordField.Text))
            {
                await DisplayAlert("", "Data is incorrect", "OK");
                return;
            }


            string login = loginField.Text.Trim();
            string password = passwordField.Text.Trim();

            if (login.Equals("")|| password.Length < 3)
            {
                await DisplayAlert("", "Data is incorrect", "OK");
                return;
            }

            User user = App.Db.GetUserList().Where(x => x.Login == login && x.Password == Hash(password)).FirstOrDefault();
          
            if(user == null)
            {
                await DisplayAlert("", "This user does not exist", "OK");
                return;
            }
            AuthUser auth = new AuthUser(login, user.Email);
            XmlSerializer xml = new XmlSerializer(typeof(AuthUser));
            string path = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "user.xml");
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                xml.Serialize(file, auth);
            }


            await Navigation.PushAsync(new MainPage());
        }

        private async void regButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
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