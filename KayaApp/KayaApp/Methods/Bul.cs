using KayaApp.GetData;
using KayaApp.Models;

namespace KayaApp.Methods
{

    public class Bul
    {

        public static OdemeYontemiModel TahsilattanOdemeYontemiBul(TahsilatFatModel gelentahsilatfaturasi)
        {

            if (
                gelentahsilatfaturasi.fat_evrak_tip == 2 &&
                gelentahsilatfaturasi.fat_tip == 1 &&
                gelentahsilatfaturasi.fat_kasa_hizmet == 4 &&
                gelentahsilatfaturasi.fat_cari_cins == 0 &&
                gelentahsilatfaturasi.fat_cinsi == 0 &&
                gelentahsilatfaturasi.fat_karsidgrupno == 0
                )
            {
                //kassa
                return DataClass._LSTMANAGER.ODEMEYONTEMLERI[0];
            }
            else if (
              gelentahsilatfaturasi.fat_evrak_tip == 34 &&
              gelentahsilatfaturasi.fat_tip == 1 &&
              gelentahsilatfaturasi.fat_kasa_hizmet == 2 &&
              gelentahsilatfaturasi.fat_cari_cins == 0 &&
              gelentahsilatfaturasi.fat_cinsi == 0 &&
              gelentahsilatfaturasi.fat_karsidgrupno == 1
              )
            {
                //banka
                return DataClass._LSTMANAGER.ODEMEYONTEMLERI[1];
            }

            else if (
            gelentahsilatfaturasi.fat_evrak_tip == 4 &&
            gelentahsilatfaturasi.fat_tip == 1 &&
            gelentahsilatfaturasi.fat_kasa_hizmet == 4 &&
            gelentahsilatfaturasi.fat_cari_cins == 0 &&
            gelentahsilatfaturasi.fat_cinsi == 1 &&
            gelentahsilatfaturasi.fat_karsidgrupno == 0
            )
            {
                //cek
                return DataClass._LSTMANAGER.ODEMEYONTEMLERI[2];
            }

            else if (
            gelentahsilatfaturasi.fat_evrak_tip == 3 &&
            gelentahsilatfaturasi.fat_tip == 1 &&
            gelentahsilatfaturasi.fat_kasa_hizmet == 4 &&
            gelentahsilatfaturasi.fat_cari_cins == 0 &&
            gelentahsilatfaturasi.fat_cinsi == 2 &&
            gelentahsilatfaturasi.fat_karsidgrupno == 0
            )
            {
                //SENED
                return DataClass._LSTMANAGER.ODEMEYONTEMLERI[3];
            }

            else return DataClass._LSTMANAGER.ODEMEYONTEMLERI[0];
        }



    }
}
