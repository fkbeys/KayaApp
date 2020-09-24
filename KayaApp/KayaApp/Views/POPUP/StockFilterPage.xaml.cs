using KayaApp.Helpers;
using KayaApp.Models.DataShowModels;
using KayaApp.Views.PURCHASE;
using KayaApp.Views.SALES;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KayaApp.Views.POPUP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockFilterPage : PopupPage
    {
        public StockFilterPage(object binding)
        {
            InitializeComponent();
            //if (SatisFaturasiPage.SATVMZ != null)
            //{
            //    BindingContext = SatisFaturasiPage.SATVMZ;
            //}
            BindingContext = binding;

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            filtrelistesi.SelectedItem = null;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var tt = e.Item as FilterItems;
                List<StockFilterModel> list =  null;

                if (SatisFaturasiPage.SATVMZ != null)
                {
                    list = SatisFaturasiPage.SATVMZ.StockFilter;
                }

                if (AlisFaturasiPage.ALVMZ != null)
                {
                    list = AlisFaturasiPage.ALVMZ.StockFilter;
                }


                if (list.Any())
                {
                    foreach (var item in list)
                    {
                        var bulunan = item.Filter_Items.Where(x => x.filteritem_aciklama == tt.filteritem_aciklama);
                        if (bulunan.Any())
                        {
                            if (bulunan.FirstOrDefault().filteritem_isselected == false)
                            {
                                bulunan.FirstOrDefault().filteritem_isselected = true;
                            }
                            else
                            {
                                bulunan.FirstOrDefault().filteritem_isselected = false;
                            }

                        }

                    }
                } 
            }
            catch (Exception ex)
            {
                await HelpME.MessageShow("Filtre item secim hatasi", ex.Message, "ok");
            }
        } 
    }
}