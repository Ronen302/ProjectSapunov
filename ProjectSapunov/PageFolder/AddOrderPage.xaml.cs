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
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        private Order _curentOrder = new Order();

        public AddOrderPage()
        {
            InitializeComponent();
            DataContext = _curentOrder;
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NumberTb.Text))
            {
                MBClass.ErrorMB("Введите порядковый номер");
                NumberTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(OrderTb.Text))
            {
                MBClass.ErrorMB("Введите название заказа");
                OrderTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(StatusTb.Text))
            {
                MBClass.ErrorMB("Введите статус заказа");
                StatusTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(CountOfPartsTb.Text))
            {
                MBClass.ErrorMB("Введите количество партий");
                CountOfPartsTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PriceOfPartTb.Text))
            {
                MBClass.ErrorMB("Введите цену за одну партию");
                PriceOfPartTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(SumTb.Text))
            {
                MBClass.ErrorMB("Введите общую сумму");
                SumTb.Focus();
            }
            else if (_curentOrder.IdOrder == 0)
            {
                ProjectSapunovEntities.GetContext().Order.Add(_curentOrder);
            }
            else
            {
                try
                {
                    ProjectSapunovEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Заказ успешно добавлен");
                    MainFrameAddOrder.Navigate(new ListOfOrdersPage());
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
