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
using ProjectSapunov.ClassFolder;

namespace ProjectSapunov.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {

        private Store _curentProduct = new Store();

        public AddProductPage()
        {
            InitializeComponent();
            DataContext = _curentProduct;
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NumberTb.Text))
            {
                MBClass.ErrorMB("Введите порядковый номер");
                NumberTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(ProductTb.Text))
            {
                MBClass.ErrorMB("Введите название товара");
                ProductTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(CountTb.Text))
            {
                MBClass.ErrorMB("Введите количество");
                CountTb.Focus();
            }
            else if (_curentProduct.IdProduct == 0)
            {
                ProjectSapunovEntities.GetContext().Store.Add(_curentProduct);
            }
            else
            {
                try
                {
                    ProjectSapunovEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Заказ успешно добавлен");
                    MainFrameAddProduct.Navigate(new ListOfProductsPage());
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
