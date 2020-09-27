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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Spark.Invoice.Data.Context;
using Spark.Invoice.Data.Models;
using Spark.Invoice.Data.Services;
using SparkLibrary.Web;

namespace Spark.Invoice.Manager.WPF2
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
        }

       

        private void LoginBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var context = new InvoiceContext();

            //MessageBox.Show("1");
            if (context.Users.Any(u => u.UserName == loginTextBox.Text))
            {
                
                var selectedUser = context.Users.Where(u => u.UserName == loginTextBox.Text).Single();
                if (selectedUser.Password == passwordBox.Password.Hash())
                {
                    var processInfo = new Process();
                    processInfo = Process.GetCurrentProcess();

                    
                    this.Close();
                    IsLogged isLogged = new IsLogged();
                    isLogged.UserName = selectedUser.UserName;
                    isLogged.Role = (int)selectedUser.UserRole;
                    isLogged.Session = processInfo.Id.ToString();
                    isLogged.ComputerName = Environment.MachineName;
                    isLogged.AddIsLogged();


                }
                else
                {
                    passwordBox.Background = new SolidColorBrush(Colors.Red);
                    wrongPasswordLabel.Visibility = Visibility.Visible;
                    restorePasswordLbl.Visibility = Visibility.Visible;

                }
            }
            else
            {
                MessageBox.Show("Taki użytkownik nie istnieje");
            }
        }

        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
          Environment.Exit(0);
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
