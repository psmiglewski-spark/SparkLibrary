using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Invoice.Data.Models
{
    public enum ClientType {
        Unveryfied = 0,
        Veryfied = 1
    }
    public class Company
    {
        public Company()
        {
            CompanyAddresses = new List<CompanyAddress>();
            BankAccounts = new List<IdBankAccounts>();
        }

        public int Id { get; set; }
        public string NIP { get; set; }
        public string Name { get; set; }
        public string Short_Name { get; set; }
        public List<Address> Address { get; set; }
        public ClientType Client_Type { get; set; }
        public int Discount { get; set; }
        public string Payment_Method { get; set; }
        public string Phone_Number { get; set; }
        public List<BankAccount> BankAccount { get; set; }
        public string Mobile_Phone { get; set; }
        public string Email { get; set; }
        public string WWW { get; set; }
        public List<CompanyAddress> CompanyAddresses { get; set; }
        public List<IdBankAccounts> BankAccounts { get; set; }

        //public Company()
        //{
        //    this.Id = 0;
        //    this.Name = " ";
        //    this.Short_Name = " ";
        //    this.Address_Street = " ";
        //    this.Address_Pos_Number = " ";
        //    this.Address_Loc_Number = " ";
        //    this.Address_Postal_Code = " ";
        //    this.Address_City = " ";
        //    this.Address_Country = " ";
        //    this.Client_Type = " ";
        //    this.Discount = 0;
        //    this.Payment_Method = " ";
        //    this.Phone_Number = " ";
        //    this.Account_Number = " ";
        //    this.Mobile_Phone = " ";
        //    this.SWIFT = " ";
        //    this.Account_Bank = " ";
        //    this.Email = " ";
        //    this.WWW = " ";
        //}
    }
}
