using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
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
        public List<Country> _countries { get; set; }
        public int? buttonValue = 1;
        public Address newAddress = new Address();
        public BankAccount newBankAccount = new BankAccount();
        public bool NewAddressForm { get; set; } = false;
        public bool NewBankForm { get; set; } = false;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        public int saveNewIndex { get; set; }
        protected bool Saved;
        public string saveButton = "Zapisz";
        public Invoice.Data.Models.Invoice _invoice { get; set; }



        protected override async Task OnInitializedAsync()
        {
            Saved = false;
          

            int.TryParse(idCompany, out var _idcompany);
            _clientType = _context.ClientTypes.ToList();
            _paymentMethods = _context.PaymentMethods.ToList();
            _countries = _context.Countries.ToList();
            if (_idcompany == 0) //new Company is being created
            {

                _company = new Company { Discount = 0 };
            }
            else
            {
                saveButton = "Zapisz i zamknij";
               
                _company = _context.Companies.Include(b=>b.BankAccount).Include(a=>a.Address).Where(c => c.Id == _idcompany).FirstOrDefault();
            }

            Discount = _company.Discount.ToString();
           
        }

        protected void HandleValidSubmit()
        {
            Saved = false;
            _company.Discount = int.Parse(Discount);
            buttonValue = 1;

            if (_company.Id == 0) //new
            {
                try
                {

                    _company.AddCompany();
                   
                    if (saveNewIndex < 1)
                    {
                       
                        Saved = false;
                        saveButton = "Zapisz i zamknij";
                        _company = _context.Companies.Include(b => b.BankAccount).Include(a => a.Address).OrderByDescending(c=>c.Id).FirstOrDefault();
                        saveNewIndex++;
                    }
                    else
                    {
                        Saved = true;
                    }
                    StatusClass = "alert-success";
                    Message = "New Company added successfully.";

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
                _context.BankAccounts.RemoveRange(_company.BankAccount);
                _context.Addresses.RemoveRange(_company.Address);
                _context.SaveChanges();
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
            try
            {

                bankAccounts = _company.BankAccount;
                Addresses = _company.Address;
            }
            catch (NullReferenceException ex)
            {
                //Log info: nowy kontrahent
            }
           

        }

        protected void AddressFormOpen()
        {
            NewAddressForm = true;
            newAddress = new Address();

        }
        protected void BankFormOpen()
        {
            NewBankForm = true;
            newBankAccount = new BankAccount();

        }

        protected void AddressAdd()
        {
            int.TryParse(idCompany, out var _idcompany);
            NewAddressForm = false;
            if (_idcompany == 0 && saveNewIndex > 0)
            {
                _company.Address.Add(newAddress);
                _context.Update(_company);
                _context.SaveChanges();
            }
            else if (_idcompany >0)
            {

                _company.Address.Add(newAddress);
                _context.Update(_company);
                _context.SaveChanges();
            }
            else
            {

                StatusClass = "alert-danger";
                Message = $"Należy w pierwszej kolejności dodać klienta, później oddziały";
                buttonValue = 1;
                Saved = false;
            }
        }

        protected void AddressDelete(int id)
        {
            var _address = _context.Addresses.Where(a => a.Id == id).FirstOrDefault();
            _context.Addresses.Remove(_address);
            _context.SaveChanges();
        }

        protected void BankAccountDelete(int id)
        {
            var _bankAccount = _context.BankAccounts.Where(b => b.ID == id).FirstOrDefault();
            _context.BankAccounts.Remove(_bankAccount);
            _context.SaveChanges();
        }

        protected void BankAccountAdd()
        {
            int.TryParse(idCompany, out var _idcompany);
            NewBankForm = false;
            if (_idcompany == 0 && saveNewIndex > 0)
            {
                _company.BankAccount.Add(newBankAccount);
                _context.Update(_company);
                _context.SaveChanges();
            }
            else if (_idcompany > 0)
            {

                _company.BankAccount.Add(newBankAccount);
                _context.Update(_company);
                _context.SaveChanges();
            }
            else
            {

                StatusClass = "alert-danger";
                Message = $"Należy w pierwszej kolejności dodać klienta, później oddziały";
                buttonValue = 1;
                Saved = false;
            }
        }
       
    }
}
