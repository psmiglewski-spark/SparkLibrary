using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Invoice.Data.Models
{
    public class Address
    {
        //public Address()
        //{
        //    CompanyAddresses = new List<CompanyAddress>();
        //}
        public int Id { get; set; } 
        public string Address_Full { get; set; }
        public string Address_Postal_Code { get; set; }
        public string Address_City { get; set; }
        public string Address_Country { get; set; }
        //public List<CompanyAddress> CompanyAddresses { get; set; }
        public int CompanyId { get; set; }


    }
}
