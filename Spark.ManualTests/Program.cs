using System;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using SparkLibrary.Web;
using Spark.Bussiness.Library;

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

        }

        private static void Sender_MessageSent(object sender, EventArgs args)
        {
            Console.WriteLine("Ihahah");
            Console.ReadLine();
        }
    }
}
