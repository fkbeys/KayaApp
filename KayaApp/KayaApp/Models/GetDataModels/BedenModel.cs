using SQLite;

namespace KayaApp.Models
{
    public class BedenModel
    {
        [PrimaryKey, AutoIncrement]
        public int bdn_local_id { get; set; }
        public int bdn_RECno { get; set; }
        public string bdn_kodu { get; set; }
        public string bdn_IndicatorName { get; set; }
        public string bdn_IndicatorValue { get; set; }
    }
}
