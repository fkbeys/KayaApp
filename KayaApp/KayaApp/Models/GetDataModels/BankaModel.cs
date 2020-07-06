using SQLite;

namespace KayaApp.Models
{

    public class BankaModel
    {
        [PrimaryKey, AutoIncrement]
        public int ban_local_id { get; set; }
        public int ban_RECno { get; set; }
        public string ban_kod { get; set; }
        public string ban_ismi { get; set; }
        public string ban_sube { get; set; }
        public string ban_hesapno { get; set; }
        public double ban_bakiye { get; set; }
        public int ban_doviz_cinsi { get; set; }

    }
}
