using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Invoice.Data.Models;

namespace Spark.Invoice.Data.Services
{
    public class CsvCompanyData : ICompanyData
    {
        public IEnumerable<Company> GetAll()
        {
            throw new NotImplementedException();
        }

        public Company SelectCompanyById()
        {
            throw new NotImplementedException();
        }

        public Company SelectCompanyByNip()
        {
            throw new NotImplementedException();
        }

        public Company SelectCompanyByName()
        {
            throw new NotImplementedException();
        }

        public void AddNewCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public void EditCompanyData(Company company)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompany(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
