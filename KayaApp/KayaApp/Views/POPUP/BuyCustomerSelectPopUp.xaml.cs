using KayaApp.Helpers;
using KayaApp.Views.SALES;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.POPUP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuyCustomerSelectPopUp : PopupPage
    {
        public BuyCustomerSelectPopUp(object GelenPage)
        {
            InitializeComponent();

            try
            {
                BindingContext = GelenPage;
            }
            catch (Exception ex)
            {
                Hatamesaji("Customer Instance Error", "Hata:" + ex.Message);
            }
            //if (GelenPage == "SATIS")
            //{
            //    try
            //    {
            //        if (SatisFaturasiPage.SATVMZ!=null)
            //        {
            //            BindingContext = SatisFaturasiPage.SATVMZ;
            //        } 
            //    }
            //    catch (Exception ex)
            //    {
            //        Hatamesaji("Buy Customer Instance Error", "Hata:" + ex.Message); 
            //    }

            //}

            //else if (ModelName == "BUY")
            //{
            //    try
            //    {
            //        BindingContext = BuyPage.BUYVMzz;
            //    }
            //    catch (Exception ex)
            //    {

            //        HelpME.MessageShow("Buy Customer Instance Error", "Hata:" + ex.Message, "Ok");
            //    }

            //}
          
        }

        private async void Hatamesaji(string baslik,string mesaj)
        { 
            await HelpME.MessageShow(baslik, mesaj, "OK");
        }


    }
}