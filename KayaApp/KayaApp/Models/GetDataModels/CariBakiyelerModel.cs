using SQLite;

namespace KayaApp.Models
{
    class CariBakiyelerModel
    {
        [PrimaryKey, AutoIncrement]
        public int local_cari_bakiye_id { get; set; }
        public int cari_RECno { get; set; }
        public string cari_kod { get; set; }
        public double cari_bakiye { get; set; }


    }
}
