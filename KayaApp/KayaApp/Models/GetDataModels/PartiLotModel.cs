using SQLite;


namespace KayaApp.Models
{
    public class PartiLotModel
    {
        [PrimaryKey, AutoIncrement]
        public int pl_local_id { get; set; }
        public int pl_RECno { get; set; }
        public string pl_partikodu { get; set; }
        public int pl_lotno { get; set; }
        public string pl_stokkodu { get; set; }
        public string pl_aciklama { get; set; }

    }
}
