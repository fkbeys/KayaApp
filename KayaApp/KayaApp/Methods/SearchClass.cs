using KayaApp.GetData;
using KayaApp.Helpers;
using KayaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;


namespace KayaApp.Methods
{
    public class SearchClass
    {
        static LISTMANAGER _LSTMANAGER;

        public static void GetInstanceMaker()
        {
            if (_LSTMANAGER == null)
            {
                _LSTMANAGER = DataClass._LSTMANAGER;
            }

        }

        public static ObservableCollection<CustomerModel> SearchCustomerCls(string SearchCustomerText)
        {

            if (SearchCustomerText == null)
            {
                SearchCustomerText = "";
            }
            GetInstanceMaker();

            List<CustomerModel> data1 = new List<CustomerModel>();
            try
            {
                if (!String.IsNullOrEmpty(SearchCustomerText))
                {
                    data1 = _LSTMANAGER.CUSTOMERLIST.Where(x => x.cari_unvan1.ToLower().Contains(SearchCustomerText.ToLower()) || x.cari_unvan2.ToString().Contains(SearchCustomerText.ToLower())).ToList();

                }
                else
                {
                    return _LSTMANAGER.CUSTOMERLIST;

                }

            }
            catch (System.Exception ex)
            {

                Application.Current.MainPage.DisplayAlert("Error", "Exception:" + ex.Message, "Ok");


            }
            return new ObservableCollection<CustomerModel>(data1);

        }

        public static ObservableCollection<StockModel> SearchStockCls(string SearchStockText)
        {
            if (SearchStockText == null)
            {
                SearchStockText = "";
            }
            GetInstanceMaker();



            List<StockModel> data2 = new List<StockModel>();
            try
            {

                if (!String.IsNullOrEmpty(SearchStockText))
                {

                    data2 = _LSTMANAGER.STOCKLIST.Where(x => x.sto_isim.ToLower().Contains(SearchStockText.ToLower()) || x.sto_kod.ToString().Contains(SearchStockText.ToLower())).Take(20).ToList();
                }
                else
                {
                    return _LSTMANAGER.STOCKLIST;

                }

            }
            catch (System.Exception ex)
            {

                Application.Current.MainPage.DisplayAlert("Error", "Exception:" + ex.Message, "Ok");

            }
            return new ObservableCollection<StockModel>(data2);


        }
        public static ObservableCollection<MasrafModel> SearchMasrafCls(string SearchMasrafText)
        {
            GetInstanceMaker();

            List<MasrafModel> data3 = new List<MasrafModel>();

            try
            {
                if (!String.IsNullOrEmpty(SearchMasrafText))
                {

                    data3 = _LSTMANAGER.MASRAFLIST.Where(x => x.his_isim.ToLower().Contains(SearchMasrafText.ToLower())).Take(20).ToList();
                }
                else
                {
                    return _LSTMANAGER.MASRAFLIST;
                }
            }
            catch (System.Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Exception:" + ex.Message, "Ok");
            }
            return new ObservableCollection<MasrafModel>(data3);
        }
    }

}

