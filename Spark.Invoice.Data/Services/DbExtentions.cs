using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spark.Invoice.Data.Context;
using Spark.Invoice.Data.Models;
using Spark.Setup;
using SparkLibrary.Web;

namespace Spark.Invoice.Data.Services
{
    public static class DbExtentions
    {
        

        // ADO.Net methods
        //public string connectionString { get; set; }

        //public DbCompanyData(string _connectionString)
        //{
        //    this.connectionString = _connectionString;
        //}

        //    public static IEnumerable<Company> SelectAll()
        //    {
        //        var config = new ConfigFile(System.IO.Directory.GetCurrentDirectory() + @"\config.ini");
        //        var ds = new DataTable();
        //        SqlConnection sqlConnection = new SqlConnection(config.GetConnectionString());
        //        var sqlCommand = "select * from dbo.Company";
        //        sqlConnection.Open();
        //        try
        //        {
        //            var da = new SqlDataAdapter(sqlCommand, sqlConnection);
        //            da.Fill(ds);
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //        finally
        //        {
        //            sqlConnection.Close();
        //        }

        //        var companyList = (from DataRow row in ds.Rows

        //                           select new Company()
        //                           {
        //                               Id = (int)row["Id"],
        //                               NIP = row["NIP"].ToString(),
        //                               Name = row["Name"].ToString(),
        //                               Short_Name = row["Short_Name"].ToString(),
        //                               Address_Street = row["Address_Street"].ToString(),
        //                               Address_Pos_Number = row["Address_Pos_Number"].ToString(),
        //                               Address_Loc_Number = row["Address_Loc_Number"].ToString(),
        //                               Address_Postal_Code = row["Address_Postal_Code"].ToString(),
        //                               Address_City = row["Address_City"].ToString(),
        //                               Address_Country = row["Address_Country"].ToString(),
        //                               Client_Type = row["Client_Type"].ToString(),
        //                               Discount = (int)row["Discount"],
        //                               Payment_Method = row["Payment_Method"].ToString(),
        //                               Phone_Number = row["Phone_Number"].ToString(),
        //                               Account_Number = row["Account_Number"].ToString(),
        //                               Mobile_Phone = row["Mobile_Phone"].ToString(),
        //                               SWIFT = row["SWIFT"].ToString(),
        //                               Account_Bank = row["Account_Bank"].ToString(),
        //                               Email = row["Email"].ToString(),
        //                               WWW = row["WWW"].ToString(),
        //                           }).ToList();

        //        return companyList;
        //    }

        //    public static Company SelectCompanyById(int _id)
        //    {
        //        var companyList = (List<Company>)SelectAll();
        //        var company = companyList.Single(x => x.Id == _id);
        //        return company;
        //    }

        //    public static Company SelectCompanyByNip(string _nip)
        //    {
        //        var companyList = (List<Company>)SelectAll();
        //        var company = companyList.First(x => x.NIP == _nip);

        //        return company;
        //    }

        //    public static Company SelectCompanyByName(string _name)
        //    {
        //        var companyList = (List<Company>)SelectAll();
        //        var company = companyList.First(x => x.Name == _name);
        //        return company;
        //    }

        //    public static void Insert(Object _company)
        //    {
        //        var company = (Company)_company;
        //        var config = new ConfigFile(System.IO.Directory.GetCurrentDirectory() + @"\config.ini");
        //        var ds = new DataTable();
        //        var sqlConnection = new SqlConnection(config.GetConnectionString());
        //        var sqlQuerry =
        //            @"INSERT INTO dbo.Company(NIP, Name, Short_Name, Address_Street, Address_Pos_Number, Address_Loc_Number, Address_Postal_Code, Address_City, Address_Country, Client_Type, Discount, Payment_Method, Phone_Number, Account_Number, Mobile_Phone, SWIFT, Account_Bank, Email, WWW) 
        //                                            Values(@NIP, @Name, @Short_Name, @Address_Street, @Address_Pos_Number, @Address_Loc_Number, @Address_Postal_Code, @Address_City, @Address_Country, @Client_Type, @Discount, @Payment_Method, @Phone_Number, @Account_Number, @Mobile_Phone, @SWIFT, @Account_Bank, @Email, @WWW)";
        //        var sqlCommand = new SqlCommand(sqlQuerry,sqlConnection);
        //        sqlCommand.Parameters.AddWithValue("@Name", company.Name);
        //        sqlCommand.Parameters.AddWithValue("@Short_Name", company.Short_Name);
        //        sqlCommand.Parameters.AddWithValue("@Address_Street", company.Address_Street);
        //        sqlCommand.Parameters.AddWithValue("@Address_Pos_Number", company.Address_Pos_Number);
        //        sqlCommand.Parameters.AddWithValue("@Address_Loc_Number", company.Address_Loc_Number);
        //        sqlCommand.Parameters.AddWithValue("@Address_Postal_Code", company.Address_Postal_Code);
        //        sqlCommand.Parameters.AddWithValue("@Address_City", company.Address_City);
        //        sqlCommand.Parameters.AddWithValue("@Address_Country", company.Address_Country);
        //        sqlCommand.Parameters.AddWithValue("@Client_Type", company.Client_Type);
        //        sqlCommand.Parameters.AddWithValue("@Discount", company.Discount);
        //        sqlCommand.Parameters.AddWithValue("@Payment_Method", company.Payment_Method);
        //        sqlCommand.Parameters.AddWithValue("@Phone_Number", company.Phone_Number);
        //        sqlCommand.Parameters.AddWithValue("@Account_Number", company.Account_Number);
        //        sqlCommand.Parameters.AddWithValue("@Mobile_Phone", company.Mobile_Phone);
        //        sqlCommand.Parameters.AddWithValue("@SWIFT", company.SWIFT);
        //        sqlCommand.Parameters.AddWithValue("@Account_Bank", company.Account_Bank);
        //        sqlCommand.Parameters.AddWithValue("@Email", company.Email);
        //        sqlCommand.Parameters.AddWithValue("@WWW", company.WWW);

        //        try
        //        {
        //            sqlConnection.Open();
        //            sqlCommand.ExecuteNonQuery();

        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            throw;
        //        }
        //        finally
        //        {
        //            sqlConnection.Close();
        //        }
        //    }

        //    public static void Update(Object _company)
        //    {
        //        var company = (Company)_company;
        //        var config = new ConfigFile(System.IO.Directory.GetCurrentDirectory() + @"\config.ini");
        //        var ds = new DataTable();
        //        var sqlConnection = new SqlConnection(config.GetConnectionString());
        //        var sqlQuerry =
        //            @"UPDATE dbo.Company set NIP = @NIP,
        //                                     Name = @Name,
        //                                     Short_Name = @Short_Name, 
        //                                     Address_Street = @Address_Street, 
        //                                     Address_Pos_Number = @Address_Pos_Number, 
        //                                     Address_Loc_Number = @Address_Loc_Number, 
        //                                     Address_Postal_Code = @Address_Postal_Code, 
        //                                     Address_City = @Address_City, 
        //                                     Address_Country = @Address_Country, 
        //                                     Client_Type = @Client_Type, 
        //                                     Discount = @Discount, 
        //                                     Payment_Method = @Payment_Method, 
        //                                     Phone_Number = @Phone_Number, 
        //                                     Account_Number = @Account_Number, 
        //                                     Mobile_Phone = @Mobile_Phone, 
        //                                     SWIFT = @SWIFT, 
        //                                     Account_Bank = @Account_Bank, 
        //                                     Email = @Email, 
        //                                     WWW = @WWW
        //            WHERE Id = @Id";
        //        var sqlCommand = new SqlCommand(sqlQuerry, sqlConnection);
        //        sqlCommand.Parameters.AddWithValue("@Id", company.Id);
        //        sqlCommand.Parameters.AddWithValue("@Name", company.Name);
        //        sqlCommand.Parameters.AddWithValue("@Short_Name", company.Short_Name);
        //        sqlCommand.Parameters.AddWithValue("@Address_Street", company.Address_Street);
        //        sqlCommand.Parameters.AddWithValue("@Address_Pos_Number", company.Address_Pos_Number);
        //        sqlCommand.Parameters.AddWithValue("@Address_Loc_Number", company.Address_Loc_Number);
        //        sqlCommand.Parameters.AddWithValue("@Address_Postal_Code", company.Address_Postal_Code);
        //        sqlCommand.Parameters.AddWithValue("@Address_City", company.Address_City);
        //        sqlCommand.Parameters.AddWithValue("@Address_Country", company.Address_Country);
        //        sqlCommand.Parameters.AddWithValue("@Client_Type", company.Client_Type);
        //        sqlCommand.Parameters.AddWithValue("@Discount", company.Discount);
        //        sqlCommand.Parameters.AddWithValue("@Payment_Method", company.Payment_Method);
        //        sqlCommand.Parameters.AddWithValue("@Phone_Number", company.Phone_Number);
        //        sqlCommand.Parameters.AddWithValue("@Account_Number", company.Account_Number);
        //        sqlCommand.Parameters.AddWithValue("@Mobile_Phone", company.Mobile_Phone);
        //        sqlCommand.Parameters.AddWithValue("@SWIFT", company.SWIFT);
        //        sqlCommand.Parameters.AddWithValue("@Account_Bank", company.Account_Bank);
        //        sqlCommand.Parameters.AddWithValue("@Email", company.Email);
        //        sqlCommand.Parameters.AddWithValue("@WWW", company.WWW);

        //        try
        //        {
        //            sqlConnection.Open();
        //            sqlCommand.ExecuteNonQuery();

        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            throw;
        //        }
        //        finally
        //        {
        //            sqlConnection.Close();
        //        }
        //    }

        //    public static void Delete(Object _company)
        //    {
        //        var company = (Company)_company;
        //        var config = new ConfigFile(System.IO.Directory.GetCurrentDirectory() + @"\config.ini");
        //        var ds = new DataTable();
        //        var sqlConnection = new SqlConnection(config.GetConnectionString());
        //        var sqlQuerry =
        //            @"DELETE FROM dbo.Company where Id = @Id";
        //        var sqlCommand = new SqlCommand(sqlQuerry, sqlConnection);
        //        sqlCommand.Parameters.AddWithValue("@Id", company.Id);


        //        try
        //        {
        //            sqlConnection.Open();
        //            sqlCommand.ExecuteNonQuery();

        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            throw;
        //        }
        //        finally
        //        {
        //            sqlConnection.Close();
        //        }
        //    }

        // 


        public static void AddCompany(this Company company)
        {
            var invoiceContext = new InvoiceContext();
            invoiceContext.Add(company);
            invoiceContext.SaveChanges();
        }

        public static void DeleteCompany(this Company company)
        {
            var invoiceContext = new InvoiceContext();
            var companyAdresses = invoiceContext.Addresses.Where(a => a.CompanyId == company.Id).ToList();
            if (companyAdresses.Count > 0)
            {
                invoiceContext.RemoveRange(companyAdresses);
            }

            try
            {
                invoiceContext.Remove(company);
                invoiceContext.SaveChanges();
            }
            catch (NullReferenceException e)
            {
              //  MessageBox.Show("Brak wskazanej firmy do usunięcia");
            }
            
        }

        public static void UpdateCompany(this Company company, Company newCompany)
        {
            var invoiceContext = new InvoiceContext();
            newCompany.Id = company.Id;
            company = newCompany;
            invoiceContext.Update(company);
            invoiceContext.SaveChanges();
        }

        public static void AddIsLogged(this IsLogged isLogged)
        {
            var invoiceContext = new InvoiceContext();
            invoiceContext.Add(isLogged);
            invoiceContext.SaveChanges();
        }
        public static void DeleteIsLogged(this IsLogged isLogged)
        {
            var invoiceContext = new InvoiceContext();
            invoiceContext.Remove(isLogged);
            invoiceContext.SaveChanges();
        }

        public static void AddUser(this User user)
        {
            var invoiceContext = new InvoiceContext();
            invoiceContext.Add(user);
            invoiceContext.SaveChanges();
        }

        public static void DeleteUser(this User user)
        {
            var invoiceContext = new InvoiceContext();
            invoiceContext.Remove(user);
            invoiceContext.SaveChanges();
        }

        public static void UpdateUser(this User user, User newUser)
        {
            var invoiceContext = new InvoiceContext();
            newUser.Id = user.Id;
            user = newUser;
            invoiceContext.Update(user);
            invoiceContext.SaveChanges();
        }

        public static void AddAddress(this Address address)
        {
            var invoiceContext = new InvoiceContext();
            invoiceContext.Add(address);
            invoiceContext.SaveChanges();
        }

        public static void DeleteAddress(this Address address)
        {
            var invoiceContext = new InvoiceContext();
            invoiceContext.Remove(address);
            invoiceContext.SaveChanges();
        }
        public static void UpdateAddress(this Address address, Address newAddress)
        {
            var invoiceContext = new InvoiceContext();
            newAddress.Id = address.Id;
            address = newAddress;
            invoiceContext.Update(address);
            invoiceContext.SaveChanges();
        }

        public static void AddBankAccount(this BankAccount bankAccount)
        {
            var invoiceContext = new InvoiceContext();
            invoiceContext.Add(bankAccount);
            invoiceContext.SaveChanges();
        }

        public static void DeleteBankAccount(this BankAccount bankAccount)
        {
            var invoiceContext = new InvoiceContext();
            invoiceContext.Remove(bankAccount);
            invoiceContext.SaveChanges();
        }

        public static void UpdateBankAccount(this Address bankAccount, Address newBankAccount)
        {
            var invoiceContext = new InvoiceContext();
            newBankAccount.Id = bankAccount.Id;
            bankAccount = newBankAccount;
            invoiceContext.Update(bankAccount);
            invoiceContext.SaveChanges();
        }

        public static void AddCurrency(this Currency currency)
        {
            var invoiceContext = new InvoiceContext();
            invoiceContext.Add(currency);
            invoiceContext.SaveChanges();
        }

        public static void AddCurrencyTable(this CurrencyTable currencyTable)
        {
            var invoiceContext = new InvoiceContext();
            invoiceContext.Add(currencyTable);
            invoiceContext.SaveChanges();
        }
    }
}

