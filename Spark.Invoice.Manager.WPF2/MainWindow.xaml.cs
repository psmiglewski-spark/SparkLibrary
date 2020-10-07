using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Spark.Invoice.Data.Context;
using Spark.Invoice.Data.Models;
using Spark.Invoice.Data.Services;

namespace Spark.Invoice.Manager.WPF2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            new LoginWindow().ShowDialog();
            var currentProcess = new Process();
            currentProcess = Process.GetCurrentProcess();
            var isLogged = new InvoiceContext().IsLogged.Where(l => l.Session == currentProcess.Id.ToString() && l.ComputerName == Environment.MachineName).FirstOrDefault();
            InitializeComponent();
            MainWindowViewSetup();
            CurrencyTableUpdate();
            this.Closed += MainWindow_Closed;
            isLoggedLabel.Content = isLogged.UserName;
            pidLabel.Content = currentProcess.Id.ToString();
            filter1Box.TextChanged += Filter1Box_TextChanged;
            filter2Box.TextChanged += Filter2Box_TextChanged;
            filter3Box.TextChanged += Filter3Box_TextChanged;
            filter4Box.TextChanged += Filter4Box_TextChanged;
            filter5Box.SelectionChanged += Filter5Box_SelectionChanged;
            dataGridMain.MouseDoubleClick += DataGridMain_MouseDoubleClick;
            

        }

        private void CurrencyTableUpdate()
        {
            var currencyTable = new CurrencyTable();
            var currencyTableList = currencyTable.Currencies();
            var checkCurrencyTable = new InvoiceContext().CurrencyTables
                .Where(c => c.effectiveDate == currencyTable.effectiveDate)
                .Any();

            if (!checkCurrencyTable)
            {
                foreach (var currency in currencyTableList)
                {
                    currency.AddCurrency();
                }
            }
        }

        private void MainWindowViewSetup()
        {
            fromDateLabel.Visibility = Visibility.Collapsed;
            fromDatePicker.Visibility = Visibility.Collapsed;
            toDateLabel.Visibility = Visibility.Collapsed;
            toDatePicker.Visibility = Visibility.Collapsed;
            filter5Box.Visibility = Visibility.Collapsed;
            filter5Label.Visibility = Visibility.Collapsed;
            filter4Label.Visibility = Visibility.Collapsed;
            filter3Label.Visibility = Visibility.Collapsed;
            filter2Label.Visibility = Visibility.Collapsed;
            filter1Label.Visibility = Visibility.Collapsed;
            filter4Box.Visibility = Visibility.Collapsed;
            filter3Box.Visibility = Visibility.Collapsed;
            filter2Box.Visibility = Visibility.Collapsed;
            filter1Box.Visibility = Visibility.Collapsed;
            addBtn.Visibility = Visibility.Collapsed;
            removeBtn.Visibility = Visibility.Collapsed;
            paymentMethodsBtn.Visibility = Visibility.Collapsed;
            countriesBtn.Visibility = Visibility.Collapsed;
            clientTypesBtn.Visibility = Visibility.Collapsed;
            dataGridMain.Visibility = Visibility.Collapsed;
            
        }

        
        private void DataGridMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedCompany = dataGridMain.SelectedItem as Company;
            var newCompanyWindow = new CompanyWindow(selectedCompany);
            newCompanyWindow.ShowDialog();
            newCompanyWindow.Unloaded += NewCompanyWindow_Unloaded;
        }

        private void Filter2Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            var CompanyList = new InvoiceContext().Companies.Where(c => c.Name.Contains(filter1Box.Text) && c.NIP.Contains(filter3Box.Text) && c.Short_Name.Contains(filter2Box.Text) && c.Id.ToString().Contains(filter4Box.Text)).OrderBy(c => c.Name).ToList();
            filter5Box.SelectedValue = "Wszyscy";
            dataGridMain.Columns.Clear();
            CompanyDataGridFill(CompanyList);
        }

        private void Filter3Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            var CompanyList = new InvoiceContext().Companies.Where(c => c.Name.Contains(filter1Box.Text) && c.NIP.Contains(filter3Box.Text) && c.Short_Name.Contains(filter2Box.Text) && c.Id.ToString().Contains(filter4Box.Text)).OrderBy(c => c.Name).ToList();
            filter5Box.SelectedValue = "Wszyscy";
            dataGridMain.Columns.Clear();
            CompanyDataGridFill(CompanyList);
        }

        private void Filter4Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            var CompanyList = new InvoiceContext().Companies.Where(c => c.Name.Contains(filter1Box.Text) && c.NIP.Contains(filter3Box.Text) && c.Short_Name.Contains(filter2Box.Text) && c.Id.ToString().Contains(filter4Box.Text)).OrderBy(c => c.Name).ToList();
            filter5Box.SelectedValue = "Wszyscy";

            dataGridMain.Columns.Clear();
            CompanyDataGridFill(CompanyList);
        }

        private void Filter5Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var CompanyList = new List<Company>();
                if (filter5Box.SelectedValue.ToString() == "Wszyscy")
                {
                    CompanyList = new InvoiceContext().Companies.Where(c => c.Name.Contains(filter1Box.Text) && c.NIP.Contains(filter3Box.Text) && c.Short_Name.Contains(filter2Box.Text) && c.Id.ToString().Contains(filter4Box.Text)).OrderBy(c => c.Name).ToList();

                }
                else
                {
                    CompanyList = new InvoiceContext().Companies.Where(c => c.Name.Contains(filter1Box.Text) && c.NIP.Contains(filter3Box.Text) && c.Short_Name.Contains(filter2Box.Text) && c.Id.ToString().Contains(filter4Box.Text) && c.Client_Type == filter5Box.SelectedValue.ToString()).OrderBy(c => c.Name).ToList();
                }
                dataGridMain.Columns.Clear();
                CompanyDataGridFill(CompanyList);
            }
            catch (Exception exception)
            {
               
            }
               
           
            
        }

        private void Filter1Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter5Box.SelectedValue = "Wszyscy";
            var CompanyList = new InvoiceContext().Companies.Where(c=> c.Name.Contains(filter1Box.Text) && c.NIP.Contains(filter3Box.Text) && c.Short_Name.Contains(filter2Box.Text) && c.Id.ToString().Contains(filter4Box.Text)).OrderBy(c => c.Name).ToList();
            
            dataGridMain.Columns.Clear();
            CompanyDataGridFill(CompanyList);
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            var currentProcess = new Process();
            currentProcess = Process.GetCurrentProcess();
            var isLogged = new InvoiceContext().IsLogged.Where(l => l.Session == currentProcess.Id.ToString() && l.ComputerName == Environment.MachineName).FirstOrDefault();
            if (isLogged != null)
            {
                isLogged.DeleteIsLogged();
            }
        }

        private void UsersBtn_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void InvoiceBtn_OnClickButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomersBtn_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
           // AddCustomerBtn.Visibility = Visibility.Visible;
           dataGridMain.Visibility = Visibility.Visible;
           var CompanyList = new InvoiceContext().Companies.OrderBy(c => c.Name).ToList();
           CompanyDataGridFill(CompanyList);
           ClientTypeComboBoxFill();
           
        }

        private void ClientTypeComboBoxFill()
        {
            var clientTypes = new InvoiceContext().ClientTypes.Select(c => c.Client_Type);
            filter5Box.Items.Add("Wszyscy");
            foreach (var clientType in clientTypes)
            {
                filter5Box.Items.Add(clientType);
            }
            
            filter5Box.SelectedValue = "Wszyscy";
        }

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var newCompanyWindow = new CompanyWindow();
            newCompanyWindow.ShowDialog();
            newCompanyWindow.Unloaded += NewCompanyWindow_Unloaded;
        }

        private void NewCompanyWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            var CompanyList = new InvoiceContext().Companies.OrderBy(c => c.Name).ToList();
            dataGridMain.Columns.Clear();
            CompanyDataGridFill(CompanyList);
        }

        private void RemoveBtn_OnClickBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedCompany = dataGridMain.SelectedItem as Company;
            if (selectedCompany != null)
            {
                
                selectedCompany.DeleteCompany();
                var CompanyList = new InvoiceContext().Companies.OrderBy(c => c.Name).ToList();
                dataGridMain.Columns.Clear();
                CompanyDataGridFill(CompanyList);
            }
            else
            {
                MessageBox.Show("Brak wskazanej firmy do usunięcia");
            }
           
        }


        private void CompanyDataGridFill(List<Company> CompanyList)
        {
            fromDateLabel.Visibility = Visibility.Collapsed;
            fromDatePicker.Visibility = Visibility.Collapsed;
            toDateLabel.Visibility = Visibility.Collapsed;
            toDatePicker.Visibility = Visibility.Collapsed;
            filter5Box.Visibility = Visibility.Visible;
            filter5Label.Visibility = Visibility.Visible;
            filter4Label.Visibility = Visibility.Visible;
            filter3Label.Visibility = Visibility.Visible;
            filter2Label.Visibility = Visibility.Visible;
            filter1Label.Visibility = Visibility.Visible;
            filter4Box.Visibility = Visibility.Visible;
            filter3Box.Visibility = Visibility.Visible;
            filter2Box.Visibility = Visibility.Visible;
            filter1Box.Visibility = Visibility.Visible;
            addBtn.Visibility = Visibility.Visible;
            removeBtn.Visibility = Visibility.Visible;
            //dataGridMain.Visibility = Visibility.Visible;
            dataGridMain.AutoGenerateColumns = false;
            dataGridMain.ItemsSource = null;
            dataGridMain.AlternatingRowBackground = new SolidColorBrush(Colors.LightSlateGray);
            dataGridMain.ItemsSource = CompanyList;
            //dataGridMain.Columns.Add(new DataGridCheckBoxColumn() { Header = new CheckBox() });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Id", Binding = new Binding("Id")});
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Nazwa Firmy", Binding = new Binding("Name") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Symbol", Binding = new Binding("Short_Name") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "NIP", Binding = new Binding("NIP") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Typ", Binding = new Binding("Client_Type") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Adres firmy", Binding = new Binding("Full_Address") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Kod Poczt.", Binding = new Binding("Postal_Code") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Miasto", Binding = new Binding("City") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Kraj", Binding = new Binding("Country") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "E-mail", Binding = new Binding("Email") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Telefon", Binding = new Binding("Phone_Number") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Metoda płatności", Binding = new Binding("Payment_Method") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Rabat", Binding = new Binding("Discount") });

        }


        private void DictionariesBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (countriesBtn.Visibility == Visibility.Visible && paymentMethodsBtn.Visibility == Visibility.Visible && clientTypesBtn.Visibility == Visibility.Visible)
            {
                paymentMethodsBtn.Visibility = Visibility.Collapsed;
                clientTypesBtn.Visibility = Visibility.Collapsed;
                countriesBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                countriesBtn.Visibility = Visibility.Visible;
                clientTypesBtn.Visibility = Visibility.Visible;
                paymentMethodsBtn.Visibility = Visibility.Visible;
            }
        }

        private void PaymentMethodsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CountriesBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClientTypesBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
