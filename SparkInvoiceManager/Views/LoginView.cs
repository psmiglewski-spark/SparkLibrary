using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Spark.Invoice.Data.Context;
using Spark.Invoice.Data.Models;
using Spark.Invoice.Data.Services;
using SparkLibrary.Web;
using Color = System.Drawing.Color;

namespace SparkInvoiceManager.Views
{
    class LoginView : Grid
    {
        
        Label loginLabel = new Label()
        {
            Content = "Login:",
            HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(111, 99, 0, 0),
            VerticalAlignment = VerticalAlignment.Top,
            Height = 30,
            Width = 212
        };

        Label passwordLabel = new Label()
        {
            Content = "Hasło:",
            HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(111, 185, 0, 0),
            VerticalAlignment = VerticalAlignment.Top,
            Height = 30,
            Width = 212
        };

        TextBox loginTextBox = new TextBox()
        {

            HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(111, 148, 0, 0),
            VerticalAlignment = VerticalAlignment.Top,
            Height = 30,
            Width = 212
        };

        PasswordBox passwordBox = new PasswordBox()
        {
            Password = "",
            HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(111, 234, 0, 0),
            VerticalAlignment = VerticalAlignment.Top,
            Height = 30,
            Width = 212
        };

        Button loginButton = new Button()
        {
            Content = "Zaloguj",
            HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(300, 288, 0, 0),
            VerticalAlignment = VerticalAlignment.Top,
            Height = 30,
            Width = 100,
        };

        Label wrongPasswordLabel = new Label()
        {
            Content = "Podano błędne hasło",
            Foreground = Brushes.Red,
            HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(111, 260, 0, 0),
            VerticalAlignment = VerticalAlignment.Top,
            Height = 30,
            Width = 212
        };

        public LoginView()
        {
            HorizontalAlignment = HorizontalAlignment.Left;
            Height = 354;
            Margin = new Thickness(548, 396, 0, 0);
            VerticalAlignment = VerticalAlignment.Top;
            Width = 849;

           

            Children.Add(loginLabel);
            Children.Add(passwordLabel);
            Children.Add(loginTextBox);
            Children.Add(passwordBox);
            Children.Add(loginButton);
            loginButton.Click += LoginButton_Click;
            passwordBox.GotFocus += PasswordBox_GotFocus;
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordBox.Background = new SolidColorBrush(Colors.White);
            Children.Remove(wrongPasswordLabel);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var context = new InvoiceContext();
            if (context.Users.Any(u => u.UserName == loginTextBox.Text))
            {
                var selectedUser = context.Users.Where(u => u.UserName == loginTextBox.Text).Single();
                if (selectedUser.Password == passwordBox.Password.Hash())
                {
                    var processInfo = new Process();
                    processInfo = Process.GetCurrentProcess();
                    
                    this.Children.Clear();
                    this.IsEnabled = false;
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
                    Children.Add(wrongPasswordLabel);

                }
            }
            else
            {
                MessageBox.Show("Taki użytkownik nie istnieje");
            }
        }
    }
}
