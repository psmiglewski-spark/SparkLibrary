using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Invoice.Data.Models
{
    public class IsLogged
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Session { get; set; }
        public string ComputerName { get; set; }    
        public int Role { get; set; }
        public List<IndividualRights> Rights { get; set; }
    }
}
