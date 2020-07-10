using KayaApp.Helpers;
using KayaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.CUSTOMERS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerListPage : ContentPage
    {
        ShowDataVM showDataVM = new ShowDataVM();
        public CustomerListPage()
        {
            InitializeComponent();
            BindingContext = showDataVM;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await HelpME.SayfaAc(new CustomerAddPage());
        }
    }
}