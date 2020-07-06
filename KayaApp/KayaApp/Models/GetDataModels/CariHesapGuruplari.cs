using SQLite;

namespace KayaApp.Models
{
    public class CariHesapGruplariModel
    {
        [PrimaryKey, AutoIncrement]
        public int local_crg_id { get; set; }

        public int crg_RECno { get; set; }
        public string crg_kod { get; set; }

        public string crg_isim { get; set; }
    }
}
