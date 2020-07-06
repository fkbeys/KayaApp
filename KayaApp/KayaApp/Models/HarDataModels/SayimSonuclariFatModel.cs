using SQLite;
using System;

namespace KayaApp.Models
{
    public class SayimSonuclariFatModel
    {
        [PrimaryKey, AutoIncrement]
        public int sym_local_id { get; set; }

        public DateTime sym_tarih { get; set; }
        public int sym_depo { get; set; }
        public string sym_evrak_seri { get; set; }
        public string sym_stokkod { get; set; }
        public double sym_miktar { get; set; }
        public int sym_reyonkodu { get; set; }
        public int sym_koridorkodu { get; set; }
        public int sym_rafkodu { get; set; }
        public string sym_barkod { get; set; }
        public int sym_renkno { get; set; }
        public int sym_bedenno { get; set; }
        public bool sym_is_sent { get; set; }
        public int sym_islemkodu { get; set; }
        public string sym_islem_baglanti { get; set; }
        public string sym_birim_ad { get; set; }

        public int mikro_user_id { get; set; }


    }
}
