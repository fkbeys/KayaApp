using KayaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.SALES
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SatisFaturasiPage : TabbedPage
    {
        public static SatisVM SATVMZ;
        public SatisFaturasiPage()
        {
            InitializeComponent();
             
            BindingContext = SATVMZ = new SatisVM();

            //cari goster butonu 
            SATVMZ.BtnCariGoster.Execute(this);
        }
    }
}