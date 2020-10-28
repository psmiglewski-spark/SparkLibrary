using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spark.Invoice.Data.Models;
using Spark.Setup;


namespace Spark.Invoice.Data.Context
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
        {

        }

        public InvoiceContext()
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Models.Invoice> Invoices { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<IsLogged> IsLogged { get; set; }
        public DbSet<IndividualRights> IndividualRights { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<CurrencyTable> CurrencyTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigFile(System.IO.Directory.GetCurrentDirectory() + @"\config.ini");
            optionsBuilder.UseSqlServer(@"Server = ACERLAPTOP\SPARKDBENGINE; Database = InvoiceManager3; User Id = sa; Password = PIotreck1;");
         //   optionsBuilder.UseSqlServer(@"Server = VMI436130\SPARKSQL2016; Database = InvoiceManager3; User Id = sa; Password = PIotreck1;");


        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CompanyAddress>().HasKey(c => new {c.AddressId, c.CompanyId});
        //    modelBuilder.Entity<IdBankAccounts>().HasKey(b => new { b.CompanyId, b.BankAccountId });
        //}
    }
}
