using System;
using System.Globalization;

namespace KayaApp.Helpers
{
    public class NumericConverter
    {
        public static NumericConverter cevir;

        //public static int RenkBedenModeltoIntConvertor(RenkModel gelenrenk, BedenModel gelenbeden)
        //{


        //    try
        //    {
        //        int renkkodu = 0;
        //        int bedenkodu = 1;


        //        if (gelenrenk != null && gelenrenk.rnk_IndicatorName != null)
        //        {
        //            renkkodu = NumericConverter.GetNumberInaString(gelenrenk.rnk_IndicatorName) - 1;
        //        }

        //        if (gelenbeden != null && gelenbeden.bdn_IndicatorName != null)
        //        {
        //            bedenkodu = NumericConverter.GetNumberInaString(gelenbeden.bdn_IndicatorName);
        //        }

        //        var reng = gelenrenk;
        //        var beden = gelenbeden;


        //        return (renkkodu) * 40 + bedenkodu;
        //    }
        //    catch (Exception ex)
        //    {
        //        HelpME.MessageShow("hata", ex.Message, "ok");

        //    }

        //    return 0;
        //}

        public static int GetNumberInaString(string gelenstring)
        {
            string b = string.Empty;
            int val = 0;

            for (int i = 0; i < gelenstring.Length; i++)
            {
                if (Char.IsDigit(gelenstring[i]))
                    b += gelenstring[i];
            }

            if (b.Length > 0)
                val = int.Parse(b);



            return val;
        }
        public static int StringToInt(string metin)
        {
            int finalsayi = 1;
            int.TryParse(metin, out finalsayi);
            if (finalsayi == 0) finalsayi = 1;

            return finalsayi;
        }
        public static double StringToDouble(string metin)
        {


            if (cevir == null)
            {
                cevir = new NumericConverter();

            }
            if (!string.IsNullOrEmpty(metin))
            {
                try
                {
                    var gelen = metin.Replace(",", ".");
                    var gelen2 = Math.Round((double.Parse(gelen, CultureInfo.InvariantCulture)), 5);


                    return gelen2;
                }
                catch (Exception)
                {
                    return 0;

                }
            }
            else return 0;

        }
        public static string StringDecor(string textim)
        {
            if (textim == null) return "0";

            string deger = "";
            string son = "";
            try
            {

                deger = textim.Replace(",", ".");
                son = deger;

                //if (string.IsNullOrWhiteSpace(deger))
                //{
                //    deger = "0";
                //    son = "0";
                //}

                if (deger.StartsWith("."))
                {
                    deger = "0" + deger;
                    son = deger;

                }


                var deger_numeric = NumericConverter.StringToDouble(deger);


                if (deger_numeric < 1)
                {

                    deger = deger.Replace("000.", "0.");
                    deger = deger.Replace("00.", "0.");
                    son = deger;
                }




                if (deger_numeric >= 1 && deger_numeric < 10)
                {
                    son = deger.Replace("0", "");

                }


                if (deger.StartsWith("0") && deger_numeric >= 10)
                {

                    son = deger.Substring(1);

                }

                if (deger.Contains("."))
                {
                    var tespit = deger.IndexOf(".");

                    var tumuzunluk = deger.Length;
                    if (tespit + 2 != tumuzunluk && tespit + 2 < tumuzunluk)
                    {
                        son = deger.Substring(0, tespit + 3);

                    }
                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
                HelpME.MessageShow("Convertion Error", ex.Message, "OK");
            }
            return son;
        }
        public static string StringToIntStringValue(string text)
        {

            int deger = 0;

            int.TryParse(text, out deger);

            if (deger > 1)
            {
                deger = 1;
            }

            return deger.ToString();
        }
    }
}