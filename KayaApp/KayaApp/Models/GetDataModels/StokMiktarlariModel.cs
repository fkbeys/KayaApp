using SQLite;


namespace KayaApp.Models
{

    public class StokMiktarlariModel
    {
        [PrimaryKey, AutoIncrement]
        public int Local_Stok_Miktarlari_id { get; set; }
        public int sto_RECno { get; set; }
        public string sto_kod { get; set; }
        public double sto_eldeki_miktar { get; set; }

    }
}
