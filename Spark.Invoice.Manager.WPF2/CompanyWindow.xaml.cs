using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Spark.Invoice.Data.Context;
using Spark.Invoice.Data.Models;
using Spark.Invoice.Data.Services;

namespace Spark.Invoice.Manager.WPF2
{
    /// <summary>
    /// Logika interakcji dla klasy CompanyWindow.xaml
    /// </summary>
    public partial class CompanyWindow : Window
    {
        private Company _company { get; set; }

        public CompanyWindow()
        {
            InitializeComponent();
            idTextBox.IsEnabled = false;
            ClientTypeComboBoxFill();
            PaymentMethodsComboBoxFill();
            CountriesComboBoxFill();
        }

        public CompanyWindow(Company company)
        {
            InitializeComponent();
            clientTypeComboBox.Items.Add("Verified");
            clientTypeComboBox.Items.Add("Unverified");
            clientTypeComboBox.SelectedItem = "Verified";
            countryComboBox.Items.Add("PL");
            countryComboBox.SelectedItem = "PL";
            paymentMethodComboBox.Items.Add("Przelew");
            paymentMethodComboBox.SelectedItem = "Przelew";
            this._company = company;
            idTextBox.Text = company.Id.ToString();
            nameTextBox.Text = company.Name;
            shortNameTextBox.Text = company.Short_Name;
            clientTypeComboBox.SelectedItem = company.Client_Type;
            addressTextBox.Text = company.Full_Address;
            postalCodeTextBox.Text = company.Postal_Code;
            cityTextBox.Text = company.City;
            countryComboBox.SelectedItem = company.Country;
            nipTextBox.Text = company.NIP;
            paymentMethodComboBox.SelectedItem = company.Payment_Method;
            phoneTextBox.Text = company.Phone_Number;
            emailTextBox.Text = company.Email;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (idTextBox.Text != "")
            {
                

                Int32.TryParse(idTextBox.Text, out var id);
                _company.UpdateCompany(new Company() { Id = id, Name = nameTextBox.Text, Short_Name = shortNameTextBox.Text, Full_Address = addressTextBox.Text, Postal_Code = postalCodeTextBox.Text, City = cityTextBox.Text, Country = countryComboBox.SelectedValue.ToString(), NIP = nipTextBox.Text, Payment_Method = paymentMethodComboBox.SelectedValue.ToString(), Phone_Number = phoneTextBox.Text, Email = emailTextBox.Text, Client_Type = clientTypeComboBox.SelectedValue.ToString() });
                this.Close();
            }
            else
            {
               

                if (!String.IsNullOrEmpty(nameTextBox.Text) && !String.IsNullOrEmpty(shortNameTextBox.Text))
                {
                    new Company() { Name = nameTextBox.Text, Short_Name = shortNameTextBox.Text, Full_Address = addressTextBox.Text, Postal_Code = postalCodeTextBox.Text, City = cityTextBox.Text, Country = countryComboBox.SelectedValue.ToString(), NIP = nipTextBox.Text, Payment_Method = paymentMethodComboBox.SelectedValue.ToString(), Phone_Number = phoneTextBox.Text, Email = emailTextBox.Text, Client_Type = clientTypeComboBox.SelectedValue.ToString() }.AddCompany();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nie wprowadzono nazwy firmy i/lub symbolu ");
                }
               
            }
        }

        private void ClientTypeComboBoxFill()
        {
            var clientTypes = new InvoiceContext().ClientTypes.Select(c => c.Client_Type);
            foreach (var clientType in clientTypes)
            {
                clientTypeComboBox.Items.Add(clientType);
            }

            clientTypeComboBox.SelectedValue = clientTypes.FirstOrDefault();
        }

        private void PaymentMethodsComboBoxFill()
        {
            var paymentMethods = new InvoiceContext().PaymentMethods.Select(p => p.Payment_Method_Name);
            foreach (var paymentMethod in paymentMethods)
            {
                paymentMethodComboBox.Items.Add(paymentMethod);
            }

            paymentMethodComboBox.SelectedValue = paymentMethods.FirstOrDefault();
        }

        private void CountriesComboBoxFill()
        {
            var countryList = new InvoiceContext().Countries.Select(c => c.Country_Code);
            foreach (var country in countryList)
            {
                countryComboBox.Items.Add(country);
            }

            countryComboBox.SelectedValue = countryList.FirstOrDefault();
        }
        //private void CurrencyComboBoxFill()
        //{
        //    var currencyList = new InvoiceContext().Currencies.Select(c => c.code);
        //    foreach (var currency in currencyList)
        //    {

        //    }
        //}

        private void CloseButton_OnClickButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
