using SQLite;

namespace KayaApp.Models
{
    public class OlusanRenkBedenSeriHareketleriModel
    {
        [PrimaryKey, AutoIncrement]
        public int Olusan_local_id { get; set; }
        public int Olusan_Har_Tip { get; set; }
        public string Olusan_Stok_kodu { get; set; }
        public string Olusan_Renk_Indicatoru { get; set; }
        public string Olusan_Beden_Indicatoru { get; set; }
        public string Olusan_RenkBeden_Miktar { get; set; }
        public string Olusan_Serino { get; set; }
        public string Olusan_Serino_Miktar { get; set; }
        public string Olusan_Baglantisi_sth { get; set; }
        public string Olusan_Baglantisi_fat { get; set; }
        public int Olusan_SiraNo { get; set; }
        public string Olusan_Parti { get; set; }
        public int Olusan_Lot { get; set; }
    }
}
