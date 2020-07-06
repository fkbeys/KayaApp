using SQLite;

namespace KayaApp.Models
{
    public class ProjeModel
    {
        [PrimaryKey, AutoIncrement]
        public int pro_local_id { get; set; }
        public int pro_RECno { get; set; }
        public string pro_kodu { get; set; }
        public string pro_adi { get; set; }

    }
}
