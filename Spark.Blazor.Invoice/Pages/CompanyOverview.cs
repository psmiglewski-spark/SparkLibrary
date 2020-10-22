using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spark.Invoice.Data.Context;
using Spark.Invoice.Data.Models;

namespace Spark.Blazor.Invoice.Pages
{
    public partial class CompanyOverview
    {
        List<Company> company = new List<Company>();
        List<BankAccount> bankAccount = new List<BankAccount>();
        List<Address> address = new List<Address>();

        protected override Task OnInitializedAsync()
        {
            Initialize_Addresses();
            Initialize_BankAccount();
            Initialize_Company();

            return base.OnInitializedAsync();
        }

        private void Initialize_Company()
        {
            this.company = new InvoiceContext().Companies.ToList();
        }


        private void Initialize_BankAccount()
        {
            this.bankAccount = new InvoiceContext().BankAccounts.ToList();
        }


        private void Initialize_Addresses()
        {
            this.address = new InvoiceContext().Addresses.ToList();
        }
    }
}
