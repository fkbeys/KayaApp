using KayaApp.Helpers;
using SQLite;
using System;

namespace KayaApp.Models
{
    public class UsersModel : BaseViewModel
    {
        [PrimaryKey]
        public int USERS_ID { get; set; }
        public string USERS_NAME { get; set; }
        public int USERS_MIKROID { get; set; }
        public string USERS_PASS { get; set; }
        public int USERS_SETTINGS { get; set; }
        public DateTime USERS_CREATE_DATE { get; set; }
        public bool USERS_IS_ACTIVE { get; set; }
        public string USERS_STOCK_LIST_PRICE { get; set; }
        public string USERS_STORE { get; set; }
        public string USERS_SHORT_NAME { get; set; }
        public string USERS_KASA_KOD { get; set; }
        public string USERS_BANKA_KOD { get; set; }
        public string USERS_CEK_KOD { get; set; }
        public string USERS_SENED_KOD { get; set; }
        public string USERS_SRM_KOD { get; set; }
        public string USERS_PROJE_KOD { get; set; }
        public string USERS_FIRMALAR { get; set; }
        public string USERS_SUBELER { get; set; }
        public string USERS_DEFAULT_FIRMA { get; set; }
        public string USERS_DEFAULT_SUBE { get; set; }
        public int USERS_DEFAULT_FIYATLISTESI { get; set; }
        public int USERS_DEFAULT_KAYNAKDEPO { get; set; }
        public int USERS_DEFAULT_TRFDEPO { get; set; }
        public int USERS_DEFAULT_HEDEFDEPO { get; set; }
        public string USERS_DEFAULT_KASA { get; set; }
        public string USERS_DEFAULT_BANKA { get; set; }
        public string USERS_DEFAULT_CEKKASA { get; set; }
        public string USERS_DEFAULT_SENETKASA { get; set; }
        public string USERS_DEFAULT_PROJE { get; set; }
        public string USERS_DEFAULT_SRM { get; set; }
        public int USERS_DEFAULT_ODEMEYON { get; set; }
        public string USERS_ODEMEYON { get; set; }
        public string USERS_DEFAULT_TEMSILCI { get; set; }
        public string USERS_TEMSILCI { get; set; }

        public string USERS_MASRAF { get; set; }
    }
}
