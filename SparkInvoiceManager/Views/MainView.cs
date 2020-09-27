using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SparkInvoiceManager.Views
{
    public class MainView : Grid
    {
        //<Grid HorizontalAlignment = "Left" Height="907" Margin="0,108,0,0" VerticalAlignment="Top" Width="236">
        //<Button x:Name="button" Content="Button" HorizontalAlignment="Left" Margin="38,84,0,0" VerticalAlignment="Top" Width="159" Height="62"/>
        //<Button x:Name="button_Copy" Content="Button" HorizontalAlignment="Left" Margin="38,180,0,0" VerticalAlignment="Top" Width="159" Height="62"/>
        //<Button x:Name="button_Copy1" Content="Button" HorizontalAlignment="Left" Margin="38,276,0,0" VerticalAlignment="Top" Width="159" Height="62"/>
        //<Button x:Name="button_Copy2" Content="Button" HorizontalAlignment="Left" Margin="38,375,0,0" VerticalAlignment="Top" Width="159" Height="62"/>
        //<Button x:Name="button_Copy3" Content="Button" HorizontalAlignment="Left" Margin="38,474,0,0" VerticalAlignment="Top" Width="159" Height="62"/>
        //<Button x:Name="button_Copy4" Content="Button" HorizontalAlignment="Left" Margin="38,579,0,0" VerticalAlignment="Top" Width="159" Height="62"/>
        //<Button x:Name="button_Copy5" Content="Button" HorizontalAlignment="Left" Margin="38,678,0,0" VerticalAlignment="Top" Width="159" Height="62"/>
        //<Button x:Name="button_Copy6" Content="Button" HorizontalAlignment="Left" Margin="38,783,0,0" VerticalAlignment="Top" Width="159" Height="62"/>
        //<Label x:Name="label" Content="Label" HorizontalAlignment="Left" Margin="38,10,0,0" VerticalAlignment="Top" Height="41" Width="159"/>
        //</Grid>
        //<Image x:Name="image" HorizontalAlignment="Left" Height="100" Margin="836,306,0,0" VerticalAlignment="Top" Width="100"/>

        Grid leftSidebarGrid = new Grid()
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            Height = 907,
            Margin = new Thickness(0,108,0,0),
            VerticalAlignment = VerticalAlignment.Top,
            Width = 236
        };

        public Button leftSidebarInvoiceButton = new Button()
        {
            Content = "",
            Opacity = 0.1,
            HorizontalAlignment = HorizontalAlignment.Right,
            Margin = new Thickness(38,84,0,0),
            VerticalAlignment = VerticalAlignment.Top,
            Width = 159,
            Height = 62
        };

        Grid invoiceButtonGrid = new Grid()
        {
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Right,
            Margin = new Thickness(38, 84, 0, 0),
            Width = 150,
            Height = 62
        };

        private Label invoiceLabel = new Label()
        {
            Content = "Faktury",
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center
            
        };

        Image invoiceIconImage = new Image()
        {
             HorizontalAlignment = HorizontalAlignment.Left
        };

        public MainView()
        {
            Children.Add(leftSidebarGrid);
            var uri = new Uri(System.IO.Directory.GetCurrentDirectory() + @"\Graphics\invoiceicon.png");
            invoiceIconImage.Source = new BitmapImage(uri);
            invoiceButtonGrid.Children.Add(invoiceIconImage);
            invoiceButtonGrid.Children.Add(invoiceLabel);
            leftSidebarGrid.Children.Add(invoiceButtonGrid);
            leftSidebarGrid.Children.Add(leftSidebarInvoiceButton);
            
        }

    }
}
