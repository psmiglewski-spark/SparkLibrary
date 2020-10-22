using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Spark.Invoice.Data.Context;
using Spark.Invoice.Data.Models;
using Spark.Invoice.Data.Services;

namespace Spark.Invice.Blazor.Srv.Pages
{
    public partial class CompanyEdit1 : ComponentBase
    {

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string idCompany { get; set; }

        public Company _company { get; set; } = new Company();
     

        protected string Discount = string.Empty;
      

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;



        protected override async Task OnInitializedAsync()
        {
            Saved = false;
         

            int.TryParse(idCompany, out var _idcompany);

            if (_idcompany == 0) //new Company is being created
            {
              
                _company = new Company{Discount = 0};
            }
            else
            {
               _company =  new InvoiceContext().Companies.Where(c=>c.Id == _idcompany).FirstOrDefault();
            }

            Discount = _company.Discount.ToString();

        }

        protected void HandleValidSubmit()
        {
            Saved = false;
            _company.Discount = int.Parse(Discount);
          

            if (_company.Id == 0) //new
            {
                try
                {
                    _company.AddCompany();
                    StatusClass = "alert-success";
                    Message = "New Company added successfully.";
                    Saved = true;

                }
                catch (Exception e)
                {
                    StatusClass = "alert-danger";
                    Message = $"Something went wrong adding the new Company. {e.ToString()}";
                    Saved = false;
                }

            }
            
        }

        protected void DeleteCompany()
        {
            try
            {
               
                _company.DeleteCompany();
                StatusClass = "alert-success";
                Message = "Deleted successfully";
               
            }
            catch (Exception e)
            {
             throw ;
            }
            Saved = true;

        }


        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/Companyoverview");
        }

    }
}
