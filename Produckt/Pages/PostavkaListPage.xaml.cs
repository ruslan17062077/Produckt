using Produckt.Components;
using Produckt.Database;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Produckt.Pages
{
    /// <summary>
    /// Логика взаимодействия для PostavkaListPage.xaml
    /// </summary>
    public partial class PostavkaListPage : Page
    {
        private int itogSum;
        public PostavkaListPage()
        {

            InitializeComponent();
           
            App.listPage = this;
            Refresh();
            var listproduct = App.db.ProductIntake.Where(x => x.IntakeId == null).ToList();



        }

        private void addpr_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.myframe.NavigationService.Navigate(new PostavkaPage());
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.Intake.Add(new Intake
            {
                DateIntake = DateTime.Now
            });
            App.db.SaveChanges();
            var listproduct = App.db.ProductIntake.Where(x => x.IntakeId == null).ToList();
            foreach (var product in listproduct)
            {
                product.IntakeId  = App.db.Intake.ToList().Last().Id;
                App.db.Product.First(x => x.SerialNumber == product.SerialNumber).Count += product.Count;
            }
            App.db.SaveChanges();
            App.mainWindow.myframe.NavigationService.Navigate(new Pages.ProductList());
        }
        public void Refresh()
        {
            itogSum = 0;
            var listproduct = App.db.ProductIntake.Where(x => x.IntakeId == null).ToList();
            wp.Children.Clear();
            foreach (var product in listproduct)
            {
                wp.Children.Add(new ProductIntakeUserControl(product));
                itogSum += Convert.ToInt32(product.Summ);
            }
            itogg.Text = itogSum.ToString();

        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.myframe.NavigationService.Navigate(new Pages.ProductList());
        }
    }
}
