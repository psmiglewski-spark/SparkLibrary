using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spark.Invoice.Data.Context;
using Spark.Invoice.Data.Models;

namespace Spark.Invice.Blazor.Srv.Pages
{
    public partial class CompanyOverview
    {
        List<Company> company = new List<Company>();
        List<BankAccount> bankAccount = new List<BankAccount>();
        List<Address> address = new List<Address>();
        private string name = string.Empty;
        private string idFilter = string.Empty;
        private string symbol = string.Empty;
        private string nip = string.Empty;

        protected override Task OnInitializedAsync()
        {
            //Initialize_Addresses();
            //Initialize_BankAccount();
            Initialize_Company();

            return base.OnInitializedAsync();
        }

        private void Initialize_Company()
        {
            int.TryParse(idFilter, out var filterId);
            company = filterId != 0 ? new InvoiceContext().Companies.Where(c => c.Name.Contains(name) && c.Id == filterId && c.Short_Name.Contains(symbol) && c.NIP.Contains(nip)).ToList() : new InvoiceContext().Companies.Where(c => c.Name.Contains(name) && c.Short_Name.Contains(symbol) && c.NIP.Contains(nip)).ToList();
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
