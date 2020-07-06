using SQLite;

namespace KayaApp.Models
{
    public class RenkModel
    {
        [PrimaryKey, AutoIncrement]
        public int rnk_local_id { get; set; }
        public int pro_RECno { get; set; }
        public string rnk_kodu { get; set; }
        public string rnk_IndicatorName { get; set; }
        public string rnk_IndicatorValue { get; set; }

    }
}
