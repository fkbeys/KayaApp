using SQLite;


namespace KayaApp.Models
{
    public class OdemePlanlariModel
    {
        [PrimaryKey, AutoIncrement]
        public int LocalOdemePlaniID { get; set; }
        public int odp_RECno { get; set; }
        public int odp_no { get; set; }
        public string odp_adi { get; set; }
    }
}