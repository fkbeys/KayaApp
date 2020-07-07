using SQLite;

namespace KayaApp.Models
{
    public class StokListeTanimlamalariModel
    {
        [PrimaryKey, AutoIncrement]

        public int stok_liste_tanimlamalari_local_id { get; set; }

        public int sfl_RECno { get; set; }
        public int sfl_sirano { get; set; }
        public string sfl_aciklama { get; set; }

    }
}