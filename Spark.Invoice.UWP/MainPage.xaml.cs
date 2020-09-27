using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Spark.Invoice.UWP.Libraries;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Spark.Invoice.UWP
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            var loginDialog = new LoginDialog();
            
            this.InitializeComponent();
            loginDialog.ShowAsync();

        }

        

        private void CustomersBtn_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerBtn.Visibility = Visibility.Visible;
        }

        private void InvoiceBtn_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            var context = new InvoiceContext();
            new MessageDialog(context.Users.Where(u => u.UserName == "piotr").Select(u => u.Password).Single()).ShowAsync();
        }

        private void UsersBtn_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
