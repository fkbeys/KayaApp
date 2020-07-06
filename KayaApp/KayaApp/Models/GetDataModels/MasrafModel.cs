using KayaApp.Helpers;
using SQLite;
namespace KayaApp.Models
{
    public class MasrafModel : BaseViewModel
    {

        [PrimaryKey, AutoIncrement]
        public int masraf_local_id { get; set; }
        public int his_RECno { get; set; }
        public string his_kod { get; set; }

        private string _his_isim;

        public string his_isim
        {
            get { return _his_isim; }
            set
            {
                _his_isim = value;
                INotifyPropertyChanged();
            }
        }

        public double his_tutar { get; set; }
    }
}
