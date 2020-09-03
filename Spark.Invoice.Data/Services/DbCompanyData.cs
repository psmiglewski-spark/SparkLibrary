using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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
        }

        public IEnumerable<Company> GetAll()
        {
            var ds = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            var sqlCommand = "select * from dbo.Company";
            sqlConnection.Open();
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

        public Company SelectCompanyById(int _id)
        {
            var companyList = GetAll();
            var companyDict = companyList.ToDictionary(x =>x.Id);
            companyDict.TryGetValue(_id, out var company);

            return company;
        }

        public Company SelectCompanyByNip(string _nip)
        {
            var companyList = GetAll();
            var companyDict = companyList.ToDictionary(x => x.NIP);
            companyDict.TryGetValue(_nip, out var company);

            return company;
        }

        public Company SelectCompanyByName(string _name)
        {
            var companyList = GetAll();
            var companyDict = companyList.ToDictionary(x => x.Name);
            companyDict.TryGetValue(_name, out var company);

            return company;
        }

        public void AddNewCompany(Company company)
        {
            var ds = new DataTable();
            var sqlConnection = new SqlConnection(connectionString);
            var sqlQuerry =
                @"INSERT INTO dbo.Company(NIP, Name, Short_Name, Address_Street, Address_Pos_Number, Address_Loc_Number, Address_Postal_Code, Address_City, Address_Country, Client_Type, Discount, Payment_Method, Phone_Number, Account_Number, Mobile_Phone, SWIFT, Account_Bank, Email, WWW) 
                                                Values(@NIP, @Name, @Short_Name, @Address_Street, @Address_Pos_Number, @Address_Loc_Number, @Address_Postal_Code, @Address_City, @Address_Country, @Client_Type, @Discount, @Payment_Method, @Phone_Number, @Account_Number, @Mobile_Phone, @SWIFT, @Account_Bank, @Email, @WWW)";
            var sqlCommand = new SqlCommand(sqlQuerry,sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", company.Id);
            sqlCommand.Parameters.AddWithValue("@Name", company.Name);
            sqlCommand.Parameters.AddWithValue("@Short_Name", company.Short_Name);
            sqlCommand.Parameters.AddWithValue("@Address_Street", company.Address_Street);
            sqlCommand.Parameters.AddWithValue("@Address_Pos_Number", company.Address_Pos_Number);
            sqlCommand.Parameters.AddWithValue("@Address_Loc_Number", company.Address_Loc_Number);
            sqlCommand.Parameters.AddWithValue("@Address_Postal_Code", company.Address_Postal_Code);
            sqlCommand.Parameters.AddWithValue("@Address_City", company.Address_City);
            sqlCommand.Parameters.AddWithValue("@Address_Country", company.Address_Country);
            sqlCommand.Parameters.AddWithValue("@Client_Type", company.Client_Type);
            sqlCommand.Parameters.AddWithValue("@Discount", company.Discount);
            sqlCommand.Parameters.AddWithValue("@Payment_Method", company.Payment_Method);
            sqlCommand.Parameters.AddWithValue("@Phone_Number", company.Phone_Number);
            sqlCommand.Parameters.AddWithValue("@Account_Number", company.Account_Number);
            sqlCommand.Parameters.AddWithValue("@Mobile_Phone", company.Mobile_Phone);
            sqlCommand.Parameters.AddWithValue("@SWIFT", company.SWIFT);
            sqlCommand.Parameters.AddWithValue("@Account_Bank", company.Account_Bank);
            sqlCommand.Parameters.AddWithValue("@Email", company.Email);
            sqlCommand.Parameters.AddWithValue("@WWW", company.WWW);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
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

