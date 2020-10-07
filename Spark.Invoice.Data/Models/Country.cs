using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Invoice.Data.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Country_Name { get; set; }
        public string Country_Code { get; set; }
        public bool IsEU { get; set; }
    }
}
