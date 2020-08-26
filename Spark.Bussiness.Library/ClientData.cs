using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Bussiness.Library
{
   public class ClientData
    {
        public string Name { get; set; }
        public string Nip { get; set; }
        public string StatusVat { get; set; }
        public string Regon { get; set; }
        public string Pesel { get; set; }
        public string Krs { get; set; }
        public string RessidenceAddress { get; set; }
        public string WorkingAddress { get; set; }
        public string[]? Representatives { get; set; }
        public string[]? AuthorizedClerks { get; set; }
        public string[]? Partners { get; set; }
        public string RegistrationLegalDate { get; set; }
        public string RegistrationDenialBasis { get; set; }
        public string RegistrationDenialDate { get; set; }
        public string RestorationBasis { get; set; }
        public string RestorationDate { get; set; }
        public string RemovalBasis { get; set; }
        public string RemovalDate { get; set; }
        public string[]? AccountNumbers { get; set; }
        public string HasVirtualAccounts { get; set; }
    }
}
