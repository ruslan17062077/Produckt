using Produckt.Database;
using Produckt.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows;

namespace Produckt
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PostavkaListPage listPage;
        public static ProductInStock2 db = new ProductInStock2();
        public static MainWindow mainWindow;
        public static ProductList productList;
        public static List<ProductIntake> productIntakes ;
    }
}
