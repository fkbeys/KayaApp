using SQLite;

namespace KayaApp.Models
{
    public class StokSektorlariModel
    {
        [PrimaryKey, AutoIncrement]
        public int local_sktr_id { get; set; }
        public int sktr_RECno { get; set; }
        public string sktr_kod { get; set; }

        public string sktr_ismi { get; set; }
    }
}
