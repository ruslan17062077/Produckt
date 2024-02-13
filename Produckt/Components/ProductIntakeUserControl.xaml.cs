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

namespace Produckt.Components
{
    /// <summary>
    /// Логика взаимодействия для ProductIntakeUserControl.xaml
    /// </summary>
    public partial class ProductIntakeUserControl : UserControl
    {
        private ProductIntake intake;
        public ProductIntakeUserControl(ProductIntake productIntake)
        {
            InitializeComponent();
            this.intake = productIntake;
            DataContext = productIntake;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.ProductIntake.Remove(intake);
            App.db.SaveChanges();
            App.listPage.Refresh();
        }
    }
}
