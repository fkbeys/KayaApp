using KayaApp.Helpers;

namespace KayaApp.Models
{
    public class OdemeYontemiModel : BaseViewModel
    {
        public int Odeme_Id { get; set; }


        private string _Odeme_Hesap_Kodu;

        public string Odeme_Hesap_Kodu
        {
            get { return _Odeme_Hesap_Kodu; }
            set
            {
                _Odeme_Hesap_Kodu = value;
                INotifyPropertyChanged();
            }
        }

        private string _Odeme_Hesap_Ismi;
        public string Odeme_Hesap_Ismi
        {
            get { return _Odeme_Hesap_Ismi; }
            set
            {
                _Odeme_Hesap_Ismi = value;
                INotifyPropertyChanged();
            }
        }
        //public string Odeme_Hesap_Kodu  { get; set; } // KAS-001 veya BANK-001  Mikrodaki kasa veya banka kodu
        // public string Odeme_Hesap_Ismi { get; set; } // Nakit Kasa?  Deniz Bank ? Cek Kasa  
        //public string Odeme_Hesap_Aciklama { get; set; }  //nakit ? banka? cek? sened?
    }
}
