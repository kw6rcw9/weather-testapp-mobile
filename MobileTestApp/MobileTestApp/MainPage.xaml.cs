using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileTestApp
{
    public partial class MainPage : ContentPage
    {
        private Button button;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            /*StackLayout stackLayout = new StackLayout();
            Label label = new Label();
            label.Text = "Hello";
            label.TextTransform = TextTransform.Uppercase;
            label.FontSize = 25;

            button = new Button();
            button.Text = "Push me";
            button.FontSize = 25;
            button.TextColor = Color.Red;
            button.Clicked += ButtonClick;

            stackLayout.Children.Add(label);
            stackLayout.Children.Add(button);

            Content = stackLayout;*/
        }
        
        private async void ButtonClick(object sender, EventArgs e)
        {
           
        }
    }
}
