using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Invoice.Data.Models;

namespace Spark.Invoice.Data.Services
{
    interface ICompanyData
    {
        IEnumerable<Company> GetAll();
        Company SelectCompanyById();
        Company SelectCompanyByNip();
        Company SelectCompanyByName();
        void AddNewCompany(Company company);
        void EditCompanyData(Company company);
        void DeleteCompany(Company company);
    }
}
