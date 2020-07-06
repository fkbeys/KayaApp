using KayaApp.Helpers;
using SQLite;

namespace KayaApp.Models
{
    public class DepoIsimleriModel : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int depo_isimleri_local_id { get; set; }
        //public int dep_no { get; set; }

        public int dep_RECno { get; set; }

        private int _dep_no;

        public int dep_no
        {
            get { return _dep_no; }
            set
            {
                _dep_no = value;
                //   INotifyPropertyChanged();
            }
        }


        private string _dep_adi;

        public string dep_adi
        {
            get
            {
                return _dep_adi;
            }
            set
            {
                _dep_adi = value;
                //  INotifyPropertyChanged();

            }
        }

        public int dep_tipi { get; set; }

    }
}
