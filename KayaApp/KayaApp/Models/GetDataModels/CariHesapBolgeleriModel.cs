using SQLite;

namespace KayaApp.Models
{
    public class CariHesapBolgeleriModel
    {
        [PrimaryKey, AutoIncrement]
        public int local_bol_id { get; set; }
        public string bol_kod { get; set; }

        public string bol_ismi { get; set; }
    }
}
