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
using Spark.Invoice.Data.Models;
using Spark.Invoice.Data.Services;

namespace Spark.Invoice.Manager.WPF2
{
    /// <summary>
    /// Logika interakcji dla klasy CompanyWindow.xaml
    /// </summary>
    public partial class CompanyWindow : Window
    {
        public CompanyWindow()
        {
            InitializeComponent();
            idTextBox.IsEnabled = false;
            clientTypeComboBox.Items.Add("Verified");
            clientTypeComboBox.Items.Add("Unverified");
            clientTypeComboBox.SelectedItem = "Verified";
            countryComboBox.Items.Add("PL");
            countryComboBox.SelectedItem = "PL";
            paymentMethodComboBox.Items.Add("Przelew");
            paymentMethodComboBox.SelectedItem = "Przelew";
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (idTextBox.Text != "")
            {

            }
            else
            {
                ClientType clientType = ClientType.Unverified;
                if (clientTypeComboBox.SelectedValue.ToString() == "Verified")
                {
                    clientType = ClientType.Verified;
                }
                else if (clientTypeComboBox.SelectedValue.ToString() == "Unverified")
                {
                    clientType = ClientType.Verified;
                }

                new Company(){Name = nameTextBox.Text,Short_Name = shortNameTextBox.Text, Full_Address = addressTextBox.Text,Postal_Code = postalCodeTextBox.Text, City = cityTextBox.Text,Country = countryComboBox.SelectedValue.ToString(), NIP = nipTextBox.Text, Payment_Method = paymentMethodComboBox.SelectedValue.ToString(), Phone_Number = phoneTextBox.Text, Email = emailTextBox.Text, Client_Type = clientType}.AddCompany();
                this.Close();
            }
        }

        private void CloseButton_OnClickButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
