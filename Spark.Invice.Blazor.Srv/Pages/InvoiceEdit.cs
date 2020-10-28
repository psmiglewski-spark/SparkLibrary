using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Spark.Invice.Blazor.Srv.Pages
{
    public partial class InvoiceEdit
    {

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string idInvoice { get; set; }

        protected override async Task OnInitializedAsync()
        {

        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/invoiceoverview");
        }
    }
}
