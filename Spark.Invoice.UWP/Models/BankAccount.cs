using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Invoice.Data.Models
{
    public class BankAccount
    {
        
        public BankAccount()
        {
            BankAccounts = new List<IdBankAccounts>();
        }
        
        public int ID { get; set; } 
        public string AccountNumber { get; set; }
        public string VatAccountNumber { get; set; }
        public string SWIFT { get; set; }
        public string BankName { get; set; }
        public bool Active { get; set; }
        public List<IdBankAccounts> BankAccounts { get; set; }
       
    }
}
