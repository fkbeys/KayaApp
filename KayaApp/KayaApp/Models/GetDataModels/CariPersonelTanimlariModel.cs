using SQLite;

namespace KayaApp.Models
{
    public class CariPersonelTanimlariModel
    {
        [PrimaryKey, AutoIncrement]
        public int local_cari_per_id { get; set; }
        public int cari_per_RECno { get; set; }
        public string cari_per_kod { get; set; }

        public string cari_per_adi { get; set; }

    }
}
