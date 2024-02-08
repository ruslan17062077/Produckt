using Produckt.Database;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Produckt.Components
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        private Product product;

        public ProductUserControl(Product product)
        {
            this.product = product;
            InitializeComponent();
            DataContext = product;
            UnitTb.Text = product.Unit.Name.ToString();
            if (product.MainImage != null)
            {
                BitmapImage bitmapImage = new BitmapImage();
                MemoryStream byteStream = new MemoryStream(product.MainImage);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = byteStream;
                bitmapImage.EndInit();
                img.Source = bitmapImage;
            }
            else
            {
                //img.Source = new Uri();
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.myframe.Navigate(new Pages.EditandAddPagexaml(product));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            product.IsDelette = true;
            MessageBox.Show("Delete");
            App.db.SaveChanges();
            App.productList.Refresh();
        }
    }
}
