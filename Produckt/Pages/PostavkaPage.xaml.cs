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
    /// Логика взаимодействия для PostavkaPage.xaml
    /// </summary
    
    public partial class PostavkaPage : Page
    {
        private bool add = false;   
        public PostavkaPage()
        {
            InitializeComponent();
            DateDp.SelectedDate = DateTime.Now;
            ProductCb.ItemsSource = App.db.Product.Where(x => x.IsDelette == false).ToList();
            ProductCb.DisplayMemberPath = "Name";
            DateDp.IsEnabled = false;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            
            var selProduct = ProductCb.SelectedItem as Product;
            if (add == true) 
            {
                App.db.Intake.Add(new Intake
                {
                    DateIntake = DateDp.DisplayDate
                });
                App.db.SaveChanges();
                App.db.ProductIntake.Add(new ProductIntake
                {
                    IntakeId = App.db.Intake.ToList().Last().Id,
                    SerialNumber = selProduct.SerialNumber,
                    Count = Convert.ToInt32(CountTb.Text),
                    Summa = Convert.ToInt32(ItogTb.Text)
                    

                });
                selProduct.Count += Convert.ToInt32(CountTb.Text);
                App.db.SaveChanges();
                App.mainWindow.myframe.GoBack();
                
            }
            else
            {
                MessageBox.Show("Невозможно сохранить тк вы не все сделали правильно");
            }

        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
          
                App.mainWindow.myframe.GoBack();
            
        }

        private void CountTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            int n;
            if(int.TryParse(CountTb.Text.Trim(), out n) )
            {
                if (Convert.ToInt32(CountTb.Text) > 0 && Convert.ToInt32(CountTb.Text) < 50)
                {
                    if (ProductCb.SelectedIndex != -1)
                    {
                        var selProduct = ProductCb.SelectedItem as Product;
                        ItogTb.Text = (selProduct.Price * Convert.ToInt32(CountTb.Text)).ToString();
                        add = true;
                    }
                }
                else
                {
                    MessageBox.Show("Кол дол быть больше нуля и меньше 50");
                }
                
                
            }
            else
            {
                MessageBox.Show("nO");
                add = false;
            }
           
        }
    }
}
