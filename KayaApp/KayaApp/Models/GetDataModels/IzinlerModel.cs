using SQLite;

namespace KayaApp.Models.GetDataModels
{
   public class IzinlerModel
    {
        [PrimaryKey]
        public int izin_id { get; set; }
        public int izin_userid { get; set; }
        public short izin_faturaid { get; set; }
        public string izin_faturaadi { get; set; }
        public bool izin_gorebilir { get; set; }
        public bool izin_kayitekler { get; set; }
        public bool izin_duzenleyebilir { get; set; }
        public bool izin_silebilir { get; set; }

    }
}
