using KayaApp.Helpers;
using System.Collections.ObjectModel;

namespace KayaApp.Models.DataShowModels
{
    public class StockFilterModel : BaseViewModel
    {

        public string FilterHeaderName { get; set; }  // Ada gore filtrele Tum Stoklar,Ana-alt gruba gore ,Ureticilere gore,Reyonlara gore,Markalara Gore
        /*  public bool FilterHeaderIsVisible { get; set; } *///Bu hide olayini saglicak. ilerde gorcez

        private bool _FilterHeaderIsVisible;

        public bool FilterHeaderIsVisible
        {
            get { return _FilterHeaderIsVisible; }
            set
            {
                _FilterHeaderIsVisible = value;
                INotifyPropertyChanged();
            }
        }
        //public ObservableCollection<FilterItems> Filter_Items { get; set; }

        private ObservableCollection<FilterItems> _Filter_Items;

        public ObservableCollection<FilterItems> Filter_Items
        {
            get
            {
                if (_Filter_Items == null)
                {
                    _Filter_Items = new ObservableCollection<FilterItems>();
                }
                return _Filter_Items;
            }
            set { _Filter_Items = value; }
        }


        // Secilen headername e gore, icerik getirecek, coklu secim yapilabilecek. En son Uygula tusuna basinca 
        //Secilen checkbox lara gore stok listi guncelliyecek.
        //selected item ozelligi kapatilacak.
    }

    public class FilterItems:BaseViewModel
    {
        //public bool filteritem_isselected { get; set; }

        private bool _filteritem_isselected;

        public bool filteritem_isselected
        {
            get { return _filteritem_isselected; }
            set
            {
                _filteritem_isselected = value;
                INotifyPropertyChanged();
            }
        }

        public string filteritem_aciklama { get; set; }
        public int filteritem_nereyeait { get; set; }
    }
}
