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

        public Company _company { get; set; }
        public List<ClientType> _clientType { get; set; }
        private readonly InvoiceContext _context = new InvoiceContext();
        protected string Discount = string.Empty;
        public List<PaymentMethod> _paymentMethods { get; set; }
        public List<BankAccount> bankAccounts { get; set; }
        public List<Address> Addresses { get; set; }
        public int buttonValue = 1;

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;



        protected override async Task OnInitializedAsync()
        {
            Saved = false;


            int.TryParse(idCompany, out var _idcompany);
            _clientType = _context.ClientTypes.ToList();
            _paymentMethods = _context.PaymentMethods.ToList();
            if (_idcompany == 0) //new Company is being created
            {

                _company = new Company { Discount = 0 };
            }
            else
            {
                _company = _context.Companies.Include(b=>b.BankAccount).Include(a=>a.Address).Where(c => c.Id == _idcompany).FirstOrDefault();
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
            else
            {
                try
                {
                    _context.Update(_company);
                    _context.SaveChanges();
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
                throw;
            }
            Saved = true;

        }


        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/Companyoverview");
        }

        protected void MoreInfoBtnClick()
        {
            buttonValue++;
            bankAccounts = _company.BankAccount;
            Addresses = _company.Address;

        }
    }
}
