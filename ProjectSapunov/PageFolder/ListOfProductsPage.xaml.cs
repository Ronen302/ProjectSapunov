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
    /// Логика взаимодействия для ListOfProductsPage.xaml
    /// </summary>
    public partial class ListOfProductsPage : Page
    {
        public ListOfProductsPage()
        {
            InitializeComponent();
        }

        private void IsVisibleChanged_Changed(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ProjectSapunovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ProductsDG.ItemsSource = ProjectSapunovEntities.GetContext().Store.ToList();
            }
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrameListProducts.Navigate(new AddProductPage());
        }

        private void DeleteProductBtn_Click(object sender, RoutedEventArgs e)
        {
            var productsForRemoving = ProductsDG.SelectedItems.Cast<Store>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {productsForRemoving.Count()} товаров?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.Yes)
            {
                try
                {
                    ProjectSapunovEntities.GetContext().Store.RemoveRange(productsForRemoving);
                    ProjectSapunovEntities.GetContext().SaveChanges();
                    ProductsDG.ItemsSource = ProjectSapunovEntities.GetContext().Store.ToList();
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
