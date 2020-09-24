using KayaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.PURCHASE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlisFaturasiPage : TabbedPage
    {
        public static AlisVM ALVMZ;
        public AlisFaturasiPage()
        {
            InitializeComponent();
            BindingContext = ALVMZ = new AlisVM();

            if (ALVMZ.SelectedCustomerModel.cari_kod == "")
            {
                ALVMZ.BtnCariGoster.Execute(this);
            }
        }
    }
}