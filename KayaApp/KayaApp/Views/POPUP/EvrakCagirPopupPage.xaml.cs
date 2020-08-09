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
        }
    }
}