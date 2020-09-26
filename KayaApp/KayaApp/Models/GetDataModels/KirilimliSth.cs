using System.Collections.Generic;

namespace KayaApp.Models
{
    public class KirilimliSth
    {
        public List<SatisSthModel> SthHareketTablosu { get; set; } //satis
         
        public List<OlusanRenkBedenSeriHareketleriModel> RenkBedenSeriDetayTablosu { get; set; }
    }

    public class KirilimliSiparis
    {
        public List<NormalAlinanSiparisFatModel> Siparisler { get; set; } //Siparisler

        public List<OlusanRenkBedenSeriHareketleriModel> RenkBedenSeriDetayTablosu { get; set; }
    }
}
