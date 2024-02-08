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
    /// Логика взаимодействия для EditandAddPagexaml.xaml
    /// </summary>
    public partial class EditandAddPagexaml : Page
    {
        Product productnull;
        private bool add = false;
        public EditandAddPagexaml(Product product)
        {
            InitializeComponent();
            UnitCb.ItemsSource = App.db.Unit.Where(x => x.Name != "Все").ToList();
            UnitCb.DisplayMemberPath = "Name";
            productnull = product;
           

                


            if (product.SerialNumber.ToString() != "0")
            {
                DataContext = product;
                UnitCb.SelectedItem = product.Unit;
                SerialNumberBox.IsReadOnly = true;


            }
            else
            {
                SerialNumberBox.IsReadOnly = false;
                add = true;
                productnull = null;
            }
                    

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var selunit = UnitCb.SelectedItem as Unit;
            if (add == false)
            {
                productnull.UnitId = selunit.Id;
                productnull.Name = NameBox.Text;
                productnull.SerialNumber = Convert.ToInt32(SerialNumberBox.Text);
            }
            else
            {
                if (App.db.Product.Any(x => x.SerialNumber.ToString() == SerialNumberBox.Text))
                {
                    MessageBox.Show("Серийный номер уже есть в бд");
                    return;
                }
                if(NameBox.Text.Length < 3)
                {
                    MessageBox.Show("Название должно быть больше нуля");
                    return;
                }
                if (UnitCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберете ед. измерения");
                    return;
                }
                if (SerialNumberBox.Text.Length < 2)
                {
                    App.db.Product.Add(new Product
                    {
                        Name = NameBox.Text.ToString(),
                        UnitId = selunit.Id,
                        Count = 0,
                        IsDelette = false

                    });
                }
                else
                {
                    App.db.Product.Add(new Product
                    {
                        Name = NameBox.Text.ToString(),
                        SerialNumber = Convert.ToInt32(SerialNumberBox.Text),
                        UnitId = selunit.Id,
                        Count = 0,
                        IsDelette = false
                    });
                    
                }
            }
            MessageBox.Show("Save");
            App.db.SaveChanges();
            App.mainWindow.myframe.Navigate(new Pages.ProductList());
            
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.myframe.GoBack();
        }
    }
}
