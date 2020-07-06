using KayaApp.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginVM();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LogoImage.ScaleTo(1.1, 1000, Easing.Linear);
            await LogoImage.ScaleTo(1, 1000, Easing.Linear);
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {

        }
    }
}