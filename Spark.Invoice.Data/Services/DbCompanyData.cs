using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Invoice.Data.Models;

namespace Spark.Invoice.Data.Services
{
    public class DbCompanyData
    {
        public string connectionString { get; set; }

        public DbCompanyData(string _connectionString)
        {
            this.connectionString = _connectionString;
            Console.WriteLine(_connectionString);
        }

        public IEnumerable<Company> GetAll()
        {
            var ds = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            var sqlCommand = "select * from dbo.Company";
            sqlConnection.Open();
            Console.WriteLine("iha");
            try
            {
                var da = new SqlDataAdapter(sqlCommand, sqlConnection);
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sqlConnection.Close();
            }

            var companyList = (from DataRow row in ds.Rows

                               select new Company()
                               {
                                   Id = (int)row["Id"],
                                   NIP = row["NIP"].ToString(),
                                   Name = row["Name"].ToString(),
                                   Short_Name = row["Short_Name"].ToString(),
                                   Address_Street = row["Address_Street"].ToString(),
                                   Address_Pos_Number = row["Address_Pos_Number"].ToString(),
                                   Address_Loc_Number = row["Address_Loc_Number"].ToString(),
                                   Address_Postal_Code = row["Address_Postal_Code"].ToString(),
                                   Address_City = row["Address_City"].ToString(),
                                   Address_Country = row["Address_Country"].ToString(),
                                   Client_Type = row["Client_Type"].ToString(),
                                   Discount = (int)row["Discount"],
                                   Payment_Method = row["Payment_Method"].ToString(),
                                   Phone_Number = row["Phone_Number"].ToString(),
                                   Account_Number = row["Account_Number"].ToString(),
                                   Mobile_Phone = row["Mobile_Phone"].ToString(),
                                   SWIFT = row["SWIFT"].ToString(),
                                   Account_Bank = row["Account_Bank"].ToString(),
                                   Email = row["Email"].ToString(),
                                   WWW = row["WWW"].ToString(),
                               }).ToList();
            
            return companyList;
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

