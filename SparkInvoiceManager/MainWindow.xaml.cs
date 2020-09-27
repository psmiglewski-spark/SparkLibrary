using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Spark.Invoice.Data;
using Spark.Invoice.Data.Context;
using Spark.Invoice.Data.Models;
using Spark.Invoice.Data.Services;
using SparkInvoiceManager.Views;

namespace SparkInvoiceManager
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginView loginView = new LoginView();
        MainView mainView = new MainView();
       
        public MainWindow()
        {
            InitializeComponent();
            MainDataGrid.Visibility = Visibility.Collapsed;
            MainGrid.Children.Add(loginView);
           // var uri = new Uri(System.IO.Directory.GetCurrentDirectory() + @"\Graphics\invoiceicon.png");
          // image.Source = new BitmapImage(uri);
            this.Closed += MainWindow_Closed;
            loginView.IsEnabledChanged += LoginView_IsEnabledChanged;
            mainView.leftSidebarInvoiceButton.Click += LeftSidebarInvoiceButton_Click;
            
           
        }

        private void LeftSidebarInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            //  MainDataGrid.ItemsSource = new InvoiceContext().Companies.OrderBy(c => c.Name).ToList();
            MainDataGrid.Visibility = Visibility.Visible;
            MainDataGrid.AutoGenerateColumns = false;
            MainDataGrid.IsReadOnly = true;
            MainDataGrid.AlternatingRowBackground = new SolidColorBrush(Colors.YellowGreen);
            var x = new InvoiceContext().Companies.OrderBy(c => c.Name).Select(c => new
            {
                id = c.Id,
                name = c.Name ,
                shortName = c.Short_Name,
                nip = c.NIP,
                clientType = c.Client_Type
            }).ToList(); 

            MainDataGrid.ItemsSource = x;
            MainDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Id", Binding = new Binding("id"),  });
            MainDataGrid.Columns.Add(new DataGridTextColumn(){ Header = "Nazwa Firmy", Binding = new Binding("name")});
            MainDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Symbol", Binding = new Binding("shortName") });
            MainDataGrid.Columns.Add(new DataGridTextColumn() { Header = "NIP", Binding = new Binding("nip") });
            MainDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Typ", Binding = new Binding("clientType") });

            MainDataGrid.MouseDoubleClick += MainDataGrid_MouseDoubleClick;
        }

        private void MainDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            
        }

        private void LoginView_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!loginView.IsEnabled)
            {
                MainGrid.Children.Remove(loginView);
                MainGrid.Children.Add(mainView);
            }
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

       
    } 
}
