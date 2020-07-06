using SQLite;
using System;

namespace KayaApp.GetData
{
    public class CompanyModel
    {
        [PrimaryKey]
        public int COMPANY_ID { get; set; }
        public string COMPANY_IP { get; set; }
        public int COMPANY_PORT { get; set; }
        public string COMPANY_NAME { get; set; }
        public DateTime COMPANY_REGISTRATION { get; set; }
        public DateTime COMPANY_LICENCE_START { get; set; }
        public DateTime COMPANY_LICENCE_END { get; set; }
        public string COMPANY_LOCATION { get; set; }
        public string COMPANY_DB_NAME { get; set; }

    }
}