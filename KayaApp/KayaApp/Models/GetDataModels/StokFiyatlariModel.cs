using SQLite;

namespace KayaApp.Models
{
    public class StokFiyatlariModel
    {
        [PrimaryKey]
        public int sfiyat_RECno { get; set; }
        public string sfiyat_stokkod { get; set; }
        public int sfiyat_listesirano { get; set; }
        public int sfiyat_deposirano { get; set; }
        public double sfiyat_fiyati { get; set; }
        public int sfiyat_doviz { get; set; }


    }
}
