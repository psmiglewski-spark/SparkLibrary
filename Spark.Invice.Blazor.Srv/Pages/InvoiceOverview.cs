using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Spark.Invoice.Data.Context;

namespace Spark.Invice.Blazor.Srv.Pages
{
    public partial class InvoiceOverview
    {
        

        public List<Invoice.Data.Models.Invoice> _invoice { get; set; }
        public string invoiceNrFilter = string.Empty;
        public string invoiceCompnayFilter = string.Empty;
        public string invoiceAddressFilter = string.Empty;
        public string invoiceNipFilter = string.Empty;
        public string invoiceIssueDateFilter = string.Empty;
        public string invoicePaymentDateFilter = string.Empty;
        public string invoiceNetValueFilter = string.Empty;
        public string invoiceGrossValueFilter = string.Empty;
        public string invoiceVatValueFilter = string.Empty;
        public string invoicePaymentFilter = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            var _context = new InvoiceContext();
            _invoice = _context.Invoices.Where(i=> i.Invoice_Number.Contains(invoiceNrFilter) && i.Company_Name.Contains(invoiceCompnayFilter) && i.Company_Full_Address.Contains(invoiceAddressFilter) && i.Company_Nip.Contains(invoiceNipFilter)).ToList();
        }


    
    }
}
