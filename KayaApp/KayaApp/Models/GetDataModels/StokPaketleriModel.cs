using SQLite;
using System;


namespace KayaApp.Models.GetDataModels
{
   public class StokPaketleriModel
    {
        [PrimaryKey]
        public int pak_RECno { get; set; }
        public int pak_kod { get; set; }
        public int pak_stokkod { get; set; }
        public int pak_miktar { get; set; }
        public int pak_fiyat { get; set; } 
        public int pak_doviz_cins { get; set; }
        public int pak_detay_tip { get; set; }
        public int pak_ve_veya { get; set; }
        public int pak_ismi { get; set; }
        public int pak_vergidahilfl { get; set; } 
        public int pak_master_tip { get; set; }
    }
}
