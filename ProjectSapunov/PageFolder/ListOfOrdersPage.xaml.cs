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
    /// Логика взаимодействия для ListOfOrdersPage.xaml
    /// </summary>
    public partial class ListOfOrdersPage : Page
    {
        public ListOfOrdersPage()
        {
            InitializeComponent();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrameListOrders.Navigate(new AddOrderPage());
        }

        private void IsVisibleChanged_Changed(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ProjectSapunovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                OrdersDG.ItemsSource = ProjectSapunovEntities.GetContext().Order.ToList();
            }
        }

        private void DeleteOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            var ordersForRemoving = OrdersDG.SelectedItems.Cast<Order>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ordersForRemoving.Count()} заказов?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {
                try
                {
                    ProjectSapunovEntities.GetContext().Order.RemoveRange(ordersForRemoving);
                    ProjectSapunovEntities.GetContext().SaveChanges();
                    OrdersDG.ItemsSource = ProjectSapunovEntities.GetContext().Order.ToList();
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}