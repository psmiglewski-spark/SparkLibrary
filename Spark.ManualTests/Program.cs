using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using SparkLibrary.Web;
using Spark.Bussiness.Library;
using Spark.Invoice.Data.Context;
using Spark.Invoice.Data.Models;
using Spark.Invoice.Data.Services;



namespace Spark.ManualTests
{
    class Program
    {
        private static InvoiceContext invoiceContext = new InvoiceContext();

        static void Main(string[] args)
        {
            //EmailMessageSender sender = new EmailMessageSender(@"c:\temp\temp.txt","temp.txt","psmiglewski@gmail.com","piotr@smiglewski.pl","Test","smiglewski.pl","piotr@smiglewski.pl","PIotreck1");
            //sender.MessageSent += Sender_MessageSent;
            //sender.SendMessage();
            //var a = new PolishBussiness();
            //var check = a.WhiteListCheck("6972171117", "67187010452078106494350001");
            //Console.WriteLine(check);
            //Console.ReadLine();

            ISecurity securityTest = new Security();

            Console.WriteLine(securityTest.GetStringToHash("SPARK"));
            Console.WriteLine(securityTest.GetEncryptString("SPARK", "piotr"));
            var encrypedString = securityTest.GetEncryptString("SPARK", "piotr");
            Console.WriteLine(securityTest.GetDecryptedString(encrypedString, "piotr"));
            //ICompanyData companyData;
            ////companyData = new DbCompanyData();
            //var companyList = companyData.GetAll();
            //foreach (var company in companyList)
            //{
            //    Console.WriteLine(company.Name);
            //    Console.WriteLine(company.AddressCity);
            //}
            //var db = new DbCompanyData(@"Server=ACERLAPTOP\SPARKDBENGINE;Database=InvoiceManager;User Id=sa;Password=PIotreck1;");
            //List<Company> tabela = new List<Company>();
            //   var tabela =(List<Company>)DbCompanyData.SelectAll();
            //   var companybyid = DbCompanyData.SelectCompanyById(1);
            //   SparkIO.SerializeToXml(tabela, Directory.GetCurrentDirectory() + "\\companies.xml");
            //   var companyNip = DbCompanyData.SelectCompanyByNip("6972171117");
            //   Console.WriteLine(companybyid.Name + " " + companyNip.Name);
            //   try
            //   {
            //       var companyName = DbCompanyData.SelectCompanyByName("SPARK Piotr Śmiglewski");
            //       Console.WriteLine(companyName.Name);
            //   }
            //   catch (Exception e)
            //   {
            //       Console.WriteLine("Brak takiej firmy" + e);

            //   }
            //   Console.WriteLine(tabela[0].NIP);
            //}

            //private static void Sender_MessageSent(object sender, EventArgs args)
            //{
            //    Console.WriteLine("Ihahah");
            //    Console.ReadLine();
            var addresses = new List<Address>(); 
            var address = new Address() { Address_Street = "55 pułku piechoty 2" };
            addresses.Add(address) ;
            var company = new Company() { Name = "Spark", Address = addresses};
            var newcompany = new Company() { Name = "Spark12", Address = addresses};
            var user = new User(){UserName = "Piotr", Password = "PIotreck1"};
            //company.AddCompany();
            user.AddUser();
           
            //company.AddCompany();
            
            //var companies =  DataBase.GetCompanies();
           
            var companies2 = new InvoiceContext().Companies.Where(c => c.Name == "Spark")
                                                     .OrderByDescending(c => c.Id)
                                                     .Take(2);
            new InvoiceContext().Companies.Where(c => c.Id == 14).Single().UpdateCompany(newcompany);
            InvoiceContext context2 = new InvoiceContext();
            // Console.WriteLine("company: " + context.Companies.Where(c => c.Id == 9).Single().Id);
            foreach (var client in context2.Companies.ToList())
            {
                Console.WriteLine(client.Name);

            }

            //Console.WriteLine(" ");

            foreach (var client in companies2)
            {
                Console.WriteLine($@"{client.Name} : {client.Id}");
            }

            // company.DeleteCompany();


        }

        //private static void AddClient(Company company)
        //{

        //    invoiceContext.Add(company);
        //    invoiceContext.SaveChanges();
        //}

        //private static void DeleteCompany(Company company)
        //{
        //    invoiceContext.Remove(company);
        //    invoiceContext.SaveChanges();
        //}
    }
}
