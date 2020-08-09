using KayaApp.Helpers;
using SQLite;


namespace KayaApp.Models.GetDataModels
{
    public class StokPaketleriModel
    {
        [PrimaryKey]
        public int pak_RECno { get; set; }
        public string pak_kod { get; set; }
        public string pak_stokkod { get; set; }
        public double pak_miktar { get; set; }
        public double pak_fiyat { get; set; }
        public int pak_doviz_cins { get; set; }
        public int pak_detay_tip { get; set; }
        public int pak_ve_veya { get; set; }
        public string pak_ismi { get; set; }
        public int pak_vergidahilfl { get; set; }
        public int pak_master_tip { get; set; }
    }

    public class StokPaketleriHeaders : BaseViewModel
    {
        public string pak_kod { get; set; }
        public double pak_fiyat { get; set; }
        public string pak_ismi { get; set; }



        public string pak_doviz_cins { get; set; }


        private string _pak_carpan;

        public string pak_carpan
        {
            get { return _pak_carpan; }
            set
            {
                _pak_carpan = value;
                INotifyPropertyChanged();
            }
        }


        //private double _pak_carpan;
        //public double pak_carpan
        //{
        //    get
        //    {


        //        return _pak_carpan;
        //    }
        //    set
        //    {
        //        _pak_carpan = value;
        //        INotifyPropertyChanged();
        //    }
        //}

    }

}
