using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Invoice.Data.Models
{
    
    public class Company
    {
        //public Company()
        //{
        //   // CompanyAddresses = new List<CompanyAddress>();
        //    BankAccounts = new List<IdBankAccounts>();
        //}

        public int Id { get; set; }
        public string NIP { get; set; }
        public string Name { get; set; }
        public string Short_Name { get; set; }
        public List<Address> Address { get; set; }
        public string Client_Type { get; set; }
        public int Discount { get; set; }
        public string Payment_Method { get; set; }
        public string Phone_Number { get; set; }
        public List<BankAccount> BankAccount { get; set; }
        public string Mobile_Phone { get; set; }
        public string Email { get; set; }
        public string WWW { get; set; }
        public string Full_Address { get; set; }
        public string Postal_Code { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        
        

    }
}
