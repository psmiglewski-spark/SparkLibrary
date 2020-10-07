using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spark.Invoice.Data.Context;
using Spark.Invoice.Data.Services;

namespace Spark.Invoice.Data.Models
{
    public class CurrencyTable
    {
        public int Id { get; set; }
        public string table { get; set; }
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public List<Currency> rates { get; set; }

        static async Task<string> GetURI(Uri u)
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

        public List<Currency> Currencies()
        {
            var _currencyTableList = new List<CurrencyTable>();
            var _currencyList = new List<Currency>();
            string jsonString;

            var t = Task.Run(() => GetURI(new Uri("https://api.nbp.pl/api/exchangerates/tables/A/?format=json")));
            t.Wait();
            jsonString = t.Result;
            _currencyTableList = JsonConvert.DeserializeObject<List<CurrencyTable>>(jsonString);

            var table = (CurrencyTable) _currencyTableList[0];
            
            _currencyList = _currencyTableList[0].rates;
            this.effectiveDate = table.effectiveDate;
            var checkCurrencyTable = new InvoiceContext().CurrencyTables
                .Where(c => c.effectiveDate == this.effectiveDate)
                .Any();
            if (!checkCurrencyTable)
            {
                table.AddCurrencyTable();
            }
            return _currencyList;
        }

        
    }
}
