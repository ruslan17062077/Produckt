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
using Produckt.Components;
using Produckt.Database;

namespace Produckt.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public partial class ProductList : Page
    {
        
        public ProductList()
        {
            App.productList = this;
            InitializeComponent();
            UnitCb.ItemsSource = App.db.Unit.ToList();
            UnitCb.DisplayMemberPath = "Name";
            Refresh();

        }

        


        private void UnitCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }



        private void FilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
        public void Refresh()
        {
            var listproduct = App.db.Product.Where((x => x.IsDelette != true)).ToList();
            if (FilterCb.SelectedIndex != -1 && FilterBox.Text.Length > 0)
            {

                if (FilterCb.SelectedIndex == 0)
                {
                    listproduct = App.db.Product.Where(x => x.Name.ToLower().Contains(FilterBox.Text.ToLower())).ToList();
                }
                else if (FilterCb.SelectedIndex == 1)
                {
                    listproduct = App.db.Product.Where(x => x.SerialNumber.ToString().ToLower().Contains(FilterBox.Text.ToLower()) ).ToList();
                }

            }
            if (UnitCb.SelectedIndex != 3 && UnitCb.SelectedIndex != -1)
            {
                var selunit = UnitCb.SelectedItem as Unit;
                listproduct = listproduct.FindAll(x => x.Unit == selunit );
            }
            
            WP.Children.Clear();
            foreach (var product in listproduct)
            {
                WP.Children.Add(new ProductUserControl(product));
            }
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.myframe.Navigate(new Pages.EditandAddPagexaml(new Product()));
        }

        private void PostavkaProduct_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.myframe.Navigate(new Pages.PostavkaListPage());
        }
    }
}
