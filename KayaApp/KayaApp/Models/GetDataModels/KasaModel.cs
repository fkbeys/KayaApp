using SQLite;

namespace KayaApp.Models
{
    public class KasaModel
    {
        [PrimaryKey, AutoIncrement]
        public int kas_local_id { get; set; }
        public int kas_RECno { get; set; }
        public string kas_kod { get; set; }
        public string kas_isim { get; set; }
        public double kas_bakiye { get; set; }
        public int kas_doviz_cinsi { get; set; }
        public int kas_tip { get; set; }


    }
}
