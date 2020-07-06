using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KayaApp.Helpers
{
    public class ApiBaglan<T> where T : class
    {


        private static HttpClient myclient;

        public static async Task<HttpClient> Gethttpclient()
        {
            if (myclient == null)
            {

                HttpClient asmyclient = new HttpClient();
                myclient = asmyclient;
            }
            return myclient;
        }


        public static async Task<List<T>> VeriListeAl(string requesturl)
        {

            var subclient = await Gethttpclient();

            var myContent = await subclient.GetStringAsync(requesturl);

            var tr = JsonConvert.DeserializeObject<List<T>>(myContent);

            return tr;
        }

        //  nedense calismadi 
        public static async Task<T> VerisadeAl(string requesturl)
        {

            var subclient = await Gethttpclient();

            var myContent = await subclient.GetStringAsync(requesturl);

            var tr = JsonConvert.DeserializeObject<T>(myContent);

            return tr;
        }
        public static async Task<bool> VeriGonder(string requestURL, List<T> GidecekListe)
        {
            var subclient = await Gethttpclient();
            var serialize = JsonConvert.SerializeObject(GidecekListe, Formatting.None);

            HttpContent contentPost = new StringContent(serialize, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await subclient.PostAsync(requestURL, contentPost);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;

        }
    }
}