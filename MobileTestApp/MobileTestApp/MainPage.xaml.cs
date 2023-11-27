using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;

namespace MobileTestApp
{
    public partial class MainPage : ContentPage
    {
        const string API = "07d1480f18fa6b47d8b43d4817eb60b3";
        public MainPage()
        {
            InitializeComponent();
        }

        private async void getWeatherButton_Clicked(object sender, EventArgs e)
        {
           if(string.IsNullOrEmpty(userInput.Text))
            {
                await DisplayAlert("", "City Error", "OK");
                return;
            }
            string city = userInput.Text.Trim();
            if (city.Length < 2 || string.IsNullOrEmpty(city))
            {
                await DisplayAlert("", "City Error", "OK");
                return;
            }
            string response;
            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API}&units=metric";
            try
            {
                response = await client.GetStringAsync(url);

            }
            catch (HttpRequestException)
            {
                await DisplayAlert("", "Incorrect city", "OK");
                return;
            }

            var json = JObject.Parse(response);
            string temp = json["main"]["temp"].ToString();
            resultLabel.Text = $"In city {city} weather is {temp}";
        }
    }
}
