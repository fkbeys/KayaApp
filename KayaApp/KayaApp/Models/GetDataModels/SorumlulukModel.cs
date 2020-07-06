using SQLite;



namespace KayaApp.Models
{
    public class SorumlulukModel
    {
        [PrimaryKey, AutoIncrement]
        public int som_local_id { get; set; }
        public int som_RECno { get; set; }
        public string som_kod { get; set; }
        public string som_isim { get; set; }
    }
}
