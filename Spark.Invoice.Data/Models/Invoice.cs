using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Invoice.Data.Services;
using Spark.Setup;

namespace Spark.Invoice.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Invoice_Number { get; set; }
        public int ID_Client { get; set; }
        public Company Client;
        public DateTime Issue_Date { get; set; }
        public DateTime Sale_Date { get; set; }
        public DateTime Payment_Date { get; set; }
        public string Payment_Method { get; set; }
        public BankAccount Payment_Account { get; set; }
        public int SplitPayment { get; set; }
        public string Note { get; set; }
        public float Net_Value { get; set; }
        public float Gross_Value { get; set; }
        public float VAT_Value { get; set; }
        public float VAT { get; set; }
        public string Issuing_User { get; set; }
        public string Currency { get; set; }
        public float Currency_Change_Rate { get; set; }
        public string Kwota_Slownie { get; set; }
    }
}
