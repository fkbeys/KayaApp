using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KayaApp.Models
{
    public class KampanyalarModel
    {
        [PrimaryKey,AutoIncrement]
        public int KAMP_LOCALID { get; set; }
        public int KAMP_ID { get; set; }
        public string KAMP_ADI { get; set; }
        public string KAMP_USERS { get; set; }
        public DateTime KAMP_BASLA { get; set; }
        public DateTime KAMP_BIT { get; set; }
        public string KAMP_CARI_KODLAR { get; set; }
        public string KAMP_CARI_GRUPLAR { get; set; }
        public string KAMP_CARI_SEKTORLAR { get; set; }
        public string KAMP_CARI_BOLGELER { get; set; }
        public string KAMP_CARI_TEMSILCI { get; set; }
        public string KAMP_CARI_ODEMEPLANI { get; set; }
        public string KAMP_CARI_PROJE { get; set; }
        public string KAMP_CARI_SRM { get; set; }
        public string KAMP_CARI_ODEMEYONTEMI { get; set; }
        public double KAMP_CARI_MINIMUM { get; set; }
        public string KAMP_UYGULANACAK_FATLAR { get; set; }
        public double KAMP_YUZDESEL { get; set; }
        public double KAMP_TUTAR { get; set; }
        public string KAMP_STOKLAR { get; set; }
        public string KAMP_STOKLAR_KATEGORI { get; set; }
        public string KAMP_STOKLAR_ANAGRUP { get; set; }
        public string KAMP_STOKLAR_ALTGRUP { get; set; }
        public string KAMP_STOKLAR_URETICI { get; set; }
        public string KAMP_STOKLAR_SEKTOR { get; set; }
        public string KAMP_STOKLAR_REYON { get; set; }
        public string KAMP_STOKLAR_AMBALAJ { get; set; }
        public string KAMP_STOKLAR_MARKA { get; set; }
        public double KAMP_MIMINUM_MIKTAR { get; set; }
        public double KAMP_MINUMUM_TUTAR { get; set; }
        public double KAMP_IF_MIKTAR1 { get; set; }
        public double KAMP_THEN_MIKTAR1 { get; set; }
        public double KAMP_IF_MIKTAR2 { get; set; }
        public double KAMP_THEN_MIKTAR2 { get; set; }
        public double KAMP_IF_MIKTAR3 { get; set; }
        public double KAMP_THEN_MIKTAR3 { get; set; }
        public double KAMP_IF_MIKTAR4 { get; set; }
        public double KAMP_THEN_MIKTAR4 { get; set; }
        public double KAMP_IF_MIKTAR5 { get; set; }
        public double KAMP_THEN_MIKTAR5 { get; set; }
        public string KAMP_BEDAVA_VERSTOK1 { get; set; }
        public string KAMP_BEDAVA_VERSTOK2 { get; set; }
        public string KAMP_BEDAVA_VERSTOK3 { get; set; }
        public string KAMP_BEDAVA_VERSTOK4 { get; set; }
        public string KAMP_BEDAVA_VERSTOK5 { get; set; }
    }

}
