using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using SparkLibrary.Web;
using Spark.Bussiness.Library;
using Spark.Invoice.Data.Models;
using Spark.Invoice.Data.Services;

namespace Spark.ManualTests
{
    class Program
    {
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
           var db = new DbCompanyData(@"Server=ACERLAPTOP\SPARKDBENGINE;Database=InvoiceManager;User Id=sa;Password=PIotreck1;");
           //List<Company> tabela = new List<Company>();
           var tabela = db.GetAll().ToList();
           var companybyid = db.SelectCompanyById(1);
           SparkIO.SerializeToXml(tabela, Directory.GetCurrentDirectory() + "\\companies.xml");
           var companyNip = db.SelectCompanyByNip("6972171117");
           Console.WriteLine(companybyid.Name + " " + companyNip.Name);
           try
           {
               var companyName = db.SelectCompanyByName("SPARK Piotr Śmiglewski");
               Console.WriteLine(companyName.Name);
           }
           catch (Exception e)
           {
               Console.WriteLine("Brak takiej firmy" + e);
               
           }
           Console.WriteLine(tabela[0].NIP);
        }

        private static void Sender_MessageSent(object sender, EventArgs args)
        {
            Console.WriteLine("Ihahah");
            Console.ReadLine();
        }
    }
}
