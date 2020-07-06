using SQLite;

namespace KayaApp.Models
{
    public class BarcodeModel
    {
        [PrimaryKey, AutoIncrement]
        public int local_bar_id { get; set; }
        public int bar_RECno { get; set; }
        public string bar_kodu { get; set; }
        public string bar_stokkodu { get; set; }
    }
}
