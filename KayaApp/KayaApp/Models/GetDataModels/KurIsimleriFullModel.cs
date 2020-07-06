using SQLite;

namespace KayaApp.Models
{
    public class KurIsimleriFullKurusModel
    {
        [PrimaryKey, AutoIncrement]
        public int local_kur_isimleri_id { get; set; }
        public string KUR_SEMBOLU { get; set; }
        public string KUR_ISMI { get; set; }
        public string KUR_ONDALIK_ISMI { get; set; }
        public string KUR_ONDALIK_SEMBOLU { get; set; }

        public int KUR_NUMARASI { get; set; }

    }
}
