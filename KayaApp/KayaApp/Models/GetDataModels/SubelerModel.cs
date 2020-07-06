using SQLite;

namespace KayaApp.Models
{
    public class SubelerModel
    {
        [PrimaryKey, AutoIncrement]

        public int Sube_local_id { get; set; }

        public int Sube_RECno { get; set; }
        public int Sube_no { get; set; }

        public string Sube_adi { get; set; }



    }
}
