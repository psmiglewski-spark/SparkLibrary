using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Spark.Bussiness.Library
{
    public class PolishBussiness : IBussiness
    {
        public string AmountInWords(float amount)
        {
            float kwotaDec = amount;
            int zlote = (int)kwotaDec;
            int grosze = (int)(100 * kwotaDec) % 100;
            var slownieZlote = KwotaSlownie.LiczbaSlownie(zlote);
            var slownieWaluta = KwotaSlownie.WalutaSlownie(zlote, "PLN");
            var slownieGrosze = KwotaSlownie.LiczbaSlownie(grosze);
            var slownieWalutaGrosze = KwotaSlownie.WalutaSlownie(grosze, ".PLN");

            return slownieZlote + slownieWaluta + ", " + slownieGrosze + slownieWalutaGrosze;
        }

        public bool VatCheck()
        {
            throw new System.NotImplementedException();
        }

        public bool UeVatCheck()
        {
            throw new System.NotImplementedException();
        }

        public WlAccountVerification WhiteListCheck(string nip, string accountNr)
        {
            var checkResult = new WlAccoubtVerificationDeserialised();
            var t = Task.Run(() => GetUri(new Uri("https://wl-api.mf.gov.pl/api/check/nip/" + nip + "/bank-account/" + accountNr)));
            t.Wait();
            
            var jsonString = t.Result;
            checkResult = JsonConvert.DeserializeObject<WlAccoubtVerificationDeserialised>(jsonString);

            return checkResult.Result;
        }

        public List<string> WhiteListAccountList()
        {
            throw new System.NotImplementedException();
        }

        public ClientData GetClientDataFromWhiteList(string nip, string date )
        {
            var result = new ClientData();
            var wlResultClass = new WlDeserialised();
            var wlResult = new WlResult();
            var t = Task.Run(() => GetUri(new Uri("https://wl-api.mf.gov.pl/api/search/nip/" + nip + "?" + "date=" + date)));
            t.Wait();

           

            string jsonString;


            jsonString = t.Result;
            wlResultClass = JsonConvert.DeserializeObject<WlDeserialised>(jsonString);
            wlResult = wlResultClass.Result;
            result = wlResult.Subject;



            return result;
        }

        private static async Task<string> GetUri(Uri u)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(u);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
            }
            return response;
        }

        public CeidgClientData GetClientDataFromCeidg()
        {
            throw new System.NotImplementedException();
        }

        public GusClientData GetClientDataFromGus()
        {
            throw new System.NotImplementedException();
        }
    }
}