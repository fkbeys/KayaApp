using SQLite;

namespace KayaApp.Models
{
    public class FirmalarModel
    {
        [PrimaryKey, AutoIncrement]
        public int firma_local_id { get; set; }

        public int fir_RECno { get; set; }
        public int fir_sirano { get; set; }
        public string fir_unvan { get; set; }
    }
}
