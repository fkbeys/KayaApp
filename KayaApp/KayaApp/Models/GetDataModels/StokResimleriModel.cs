using SQLite;
using System;

namespace KayaApp.Models
{
    class StokResimleriModel
    {
        [PrimaryKey]
        public int STOK_RESIM_ID { get; set; }
        public string STOK_KOD { get; set; }
        public string STOK_RESIMURL { get; set; }
        public DateTime STOK_RESIMCREATE { get; set; }

    }
}
