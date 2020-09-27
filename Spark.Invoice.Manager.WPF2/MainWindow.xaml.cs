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
            filter5Box.Items.Add(ClientType.Unverified);
            filter5Box.Items.Add(ClientType.Verified);
            filter5Box.Items.Add("Wszyscy");
            this.Closed += MainWindow_Closed;
            isLoggedLabel.Content = isLogged.UserName;
            pidLabel.Content = currentProcess.Id.ToString();
            filter1Box.TextChanged += Filter1Box_TextChanged;
            filter2Box.TextChanged += Filter2Box_TextChanged;
            filter3Box.TextChanged += Filter3Box_TextChanged;
            filter4Box.TextChanged += Filter4Box_TextChanged;
            filter5Box.SelectionChanged += Filter5Box_SelectionChanged;
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
                if (filter5Box.SelectedValue.ToString() == "Unverified")
                {
                    CompanyList = new InvoiceContext().Companies.Where(c => c.Name.Contains(filter1Box.Text) && c.NIP.Contains(filter3Box.Text) && c.Short_Name.Contains(filter2Box.Text) && c.Id.ToString().Contains(filter4Box.Text) && c.Client_Type == ClientType.Unverified).OrderBy(c => c.Name).ToList();
                }
                else if (filter5Box.SelectedValue.ToString() == "Verified")
                {
                    CompanyList = new InvoiceContext().Companies.Where(c => c.Name.Contains(filter1Box.Text) && c.NIP.Contains(filter3Box.Text) && c.Short_Name.Contains(filter2Box.Text) && c.Id.ToString().Contains(filter4Box.Text) && c.Client_Type == ClientType.Verified).OrderBy(c => c.Name).ToList();
                }
                else if (filter5Box.SelectedValue.ToString() == "Wszyscy")
                {
                    CompanyList = new InvoiceContext().Companies.Where(c => c.Name.Contains(filter1Box.Text) && c.NIP.Contains(filter3Box.Text) && c.Short_Name.Contains(filter2Box.Text) && c.Id.ToString().Contains(filter4Box.Text)).OrderBy(c => c.Name).ToList();

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
            AddCustomerBtn.Visibility = Visibility.Visible;
            var CompanyList = new InvoiceContext().Companies.OrderBy(c => c.Name).ToList();
            CompanyDataGridFill(CompanyList);
        }


        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            new CompanyWindow().ShowDialog();
        }

        private void RemoveBtn_OnClickBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedCompany = dataGridMain.SelectedItem as Company;
            if (selectedCompany != null)
            {
                var CompanyList = new InvoiceContext().Companies.OrderBy(c => c.Name).ToList();
                selectedCompany.DeleteCompany();
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
            
            //dataGridMain.Visibility = Visibility.Visible;
            dataGridMain.AutoGenerateColumns = false;
            dataGridMain.ItemsSource = null;
            dataGridMain.AlternatingRowBackground = new SolidColorBrush(Colors.YellowGreen);
            
            dataGridMain.ItemsSource = CompanyList;


            //dataGridMain.Columns.Add(new DataGridCheckBoxColumn() { Header = new CheckBox() });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Id", Binding = new Binding("Id")});
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Nazwa Firmy", Binding = new Binding("Name") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Symbol", Binding = new Binding("Short_Name") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "NIP", Binding = new Binding("NIP") });
            dataGridMain.Columns.Add(new DataGridTextColumn() { Header = "Typ", Binding = new Binding("Client_Type") });
            
        }

        
    }
}
