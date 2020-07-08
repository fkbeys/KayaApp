using KayaApp.GetData;
using KayaApp.Helpers;
using KayaApp.Methods;
using KayaApp.Models;
using System.Collections.ObjectModel;

namespace KayaApp.ViewModels
{

    public class ShowDataVM : BaseViewModel
    {
        public ShowDataVM()
        {
            LoadData();
        }

        public StockModel PreviousStockModel { get; set; }


        private StockModel _SelectedStockModel;

        public StockModel SelectedStockModel
        {
            get
            {
                if (_SelectedStockModel == null)
                {
                    SelectedStockModel = new StockModel();
                }
                return _SelectedStockModel;
            }
            set
            {
                if (_SelectedStockModel != value)
                {
                    _SelectedStockModel = value;


                    if (SelectedStockModel != null)
                    {

                        // Application.Current.MainPage.Navigation.PushPopupAsync(new StockDetailPopUp(SelectedStockModel), false);
                        _SelectedStockModel = null;
                    }
                }
            }
        }
        private string _StockSearchText;

        public string StockSearchText
        {
            get { return _StockSearchText; }
            set
            {
                _StockSearchText = value;
                INotifyPropertyChanged();
                STOCKLIST = new ObservableCollection<StockModel>(SearchClass.SearchStockCls(_StockSearchText));

            }
        }

        private ObservableCollection<StockModel> _STOCKLIST;
        public ObservableCollection<StockModel> STOCKLIST
        {
            get { return _STOCKLIST; }
            set
            {
                _STOCKLIST = value;
                INotifyPropertyChanged();
            }
        }

        private ObservableCollection<CustomerModel> _CUSTOMERLIST;
        public ObservableCollection<CustomerModel> CUSTOMERLIST
        {
            get { return _CUSTOMERLIST; }
            set
            {
                _CUSTOMERLIST = value;
                INotifyPropertyChanged();
            }
        }

        void LoadData()
        {
            if (STOCKLIST == null)
            {
                STOCKLIST = new ObservableCollection<StockModel>();
            }
            STOCKLIST.Clear();

            STOCKLIST = DataClass._LSTMANAGER.STOCKLIST;

            if (CUSTOMERLIST == null)
            {
                CUSTOMERLIST = new ObservableCollection<CustomerModel>();
            }
            CUSTOMERLIST.Clear();

            CUSTOMERLIST = DataClass._LSTMANAGER.CUSTOMERLIST;
        }
        public CustomerModel PreviousCustomerModel { get; set; }


        private CustomerModel _SelectedCustomerModel;

        public CustomerModel SelectedCustomerModel
        {
            get
            {
                if (_SelectedCustomerModel == null)
                {
                    SelectedCustomerModel = new CustomerModel();
                }
                return _SelectedCustomerModel;
            }
            set
            {
                if (_SelectedCustomerModel != value)
                {
                    _SelectedCustomerModel = value;


                    if (SelectedCustomerModel != null)
                    {
                        //    Application.Current.MainPage.Navigation.PushPopupAsync(new CustomerDetailPopUp(SelectedCustomerModel), false);
                        _SelectedCustomerModel = null;
                    }
                }

            }
        }

        private string _CustomerSearchText;

        public string CustomerSearchText
        {
            get { return _CustomerSearchText; }
            set
            {
                _CustomerSearchText = value;
                INotifyPropertyChanged();
                CUSTOMERLIST = new ObservableCollection<CustomerModel>(SearchClass.SearchCustomerCls(_CustomerSearchText));
            }
        }
    }

}
