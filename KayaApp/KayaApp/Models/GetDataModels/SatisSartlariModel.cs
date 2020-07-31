using SQLite;
using System;

namespace KayaApp.Models.GetDataModels
{
    public class SatisSartlariModel
    {
        [PrimaryKey]
        public int sat_RECno { get; set; }
        public string sat_cari_kod { get; set; }
        public string sat_stok_kod { get; set; }
        public DateTime sat_basla_tarih { get; set; }
        public DateTime sat_bitis_tarih { get; set; }
        public int sat_depo_no { get; set; }
        public int sat_doviz_cinsi { get; set; }
        public int sat_odeme_plan { get; set; }
        public double sat_brut_fiyat { get; set; }
        public double sat_sonfiyat { get; set; }

    }
}
