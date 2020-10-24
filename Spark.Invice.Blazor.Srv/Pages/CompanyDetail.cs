using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Spark.Invoice.Data.Context;
using Spark.Invoice.Data.Models;

namespace Spark.Invice.Blazor.Srv.Pages
{
    public partial class CompanyDetail
    {
        [Parameter] public string CompanyId { get; set; }
        public Company company { get; set; }

        protected override Task OnInitializedAsync()
        {
            company = new InvoiceContext().Companies.Where(c => c.Id == int.Parse(CompanyId)).FirstOrDefault();
            return base.OnInitializedAsync();
        }
    }
}
