using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Invoice.Data.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string currency { get; set; }
        public string code { get; set; }
        public float mid { get; set; }
    }
}
