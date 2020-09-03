using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Invoice.Data.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string NIP { get; set; }
        public string Name { get; set; }
        public string Short_Name { get; set; }
        public string Address_Street { get; set; }
        public string Address_Pos_Number { get; set; }
        public string Address_Loc_Number { get; set; }
        public string Address_Postal_Code { get; set; }
        public string Address_City { get; set; }
        public string Address_Country { get; set; }
        public string Client_Type { get; set; }
        public int Discount { get; set; }
        public string Payment_Method { get; set; }
        public string Phone_Number { get; set; }
        public string Account_Number { get; set; }
        public string Mobile_Phone { get; set; }
        public string SWIFT { get; set; }
        public string Account_Bank { get; set; }
        public string Email { get; set; }
        public string WWW { get; set; }

        public Company()
        {
            this.Id = 0;
            this.Name = " ";
            this.Short_Name = " ";
            this.Address_Street = " ";
            this.Address_Pos_Number = " ";
            this.Address_Loc_Number = " ";
            this.Address_Postal_Code = " ";
            this.Address_City = " ";
            this.Address_Country = " ";
            this.Client_Type = " ";
            this.Discount = 0;
            this.Payment_Method = " ";
            this.Phone_Number = " ";
            this.Account_Number = " ";
            this.Mobile_Phone = " ";
            this.SWIFT = " ";
            this.Account_Bank = " ";
            this.Email = " ";
            this.WWW = " ";
        }
    }
}
