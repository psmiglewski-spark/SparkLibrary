﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spark.Invoice.Data.Models;
using Spark.Setup;


namespace Spark.Invoice.UWP.Libraries
{
    public class InvoiceContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Data.Models.Invoice> Invoices { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public ClientType ClientTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<IsLogged> IsLogged { get; set; }
        public DbSet<IndividualRights> IndividualRights { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigFile(System.IO.Directory.GetCurrentDirectory() + @"\config.ini");
            optionsBuilder.UseSqlServer(@"Server = ACERLAPTOP\SPARKDBENGINE; Database = InvoiceManager3; User Id = sa; Password = PIotreck1;");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyAddress>().HasKey(c => new { c.AddressId, c.CompanyId });
            modelBuilder.Entity<IdBankAccounts>().HasKey(b => new { b.CompanyId, b.BankAccountId });
        }
    }
}
