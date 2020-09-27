using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Spark.Invoice;
using Spark.Invoice.Data.Models;
using Spark.Invoice.Data.Services;
using Spark.Invoice.UWP.Libraries;
using SparkLibrary.Web;


//Szablon elementu Okno dialogowe zawartości jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Spark.Invoice.UWP
{
    public sealed partial class LoginDialog : ContentDialog
    {
        public LoginDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //var context = new InvoiceContext();
            //if (context.Users.Any(u => u.UserName == loginBox.Text))
            //{
            //    var selectedUser = context.Users.Where(u => u.UserName == loginBox.Text).Single();
            //    if (selectedUser.Password == PasswordBox.Password.Hash())
            //    {
            //        var processInfo = new Process();
            //        processInfo = Process.GetCurrentProcess();


            //        IsLogged isLogged = new IsLogged();
            //        isLogged.UserName = selectedUser.UserName;
            //        isLogged.Role = (int)selectedUser.UserRole;
            //        isLogged.Session = processInfo.Id.ToString();
            //        isLogged.ComputerName = Environment.MachineName;
            //        isLogged.AddIsLogged();
            //        var message = new MessageDialog("yeah");
            //        message.ShowAsync();

            //    }
            //    else
            //    {
            //        PasswordBox.Background = new SolidColorBrush(Colors.Red);


            //    }
            //}
            //else
            //{
            //    new MessageDialog("Taki użytkownik nie istnieje").ShowAsync();
            //}
            //var context = new InvoiceContext();
            //new MessageDialog(context.Users.Where(u =>u.UserName == "piotr").Select(u => u.Password).Single()).ShowAsync();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Environment.Exit(0);
        }
    }
}
