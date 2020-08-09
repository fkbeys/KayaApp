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
    public partial class EvrakCagirPopupPage : PopupPage
    {
        public EvrakCagirPopupPage()
        {
            InitializeComponent();
            if (SatisFaturasiPage.SATVMZ!=null)
            {
                BindingContext = SatisFaturasiPage.SATVMZ;
            }
            StokPaketleriList.IsVisible = false;
            StokPaketleriList.IsVisible = false;
            StokPaketleriList.IsVisible = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            StokPaketleriList.IsVisible = true;
            SipariSatirlariList.IsVisible = false;
            SipariEvraklariList.IsVisible = false;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            StokPaketleriList.IsVisible = false;
            SipariSatirlariList.IsVisible = true;
            SipariEvraklariList.IsVisible = false;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            StokPaketleriList.IsVisible = false;
            SipariSatirlariList.IsVisible = false;
            SipariEvraklariList.IsVisible = true;
        }
    }
}