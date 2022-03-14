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

namespace laba2
{
    /// <summary>
    /// Логика взаимодействия для TablePage.xaml
    /// </summary>
    public partial class TablePage : Page
    {
        public TablePage()
        {
            InitializeComponent();
            DGridTable.ItemsSource = KiyamobL5Entities.GetContext().Employee.ToList();
            AddEditPage.tablePage = this;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null, true));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var TableForRemoving = DGridTable.SelectedItems.Cast<Employee>().ToList();

           
                try
                {
                    KiyamobL5Entities.GetContext().Employee.RemoveRange(TableForRemoving);
                    KiyamobL5Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены успешно!");
                    DGridTable.ItemsSource = KiyamobL5Entities.GetContext().Employee.ToList();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Employee));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                KiyamobL5Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridTable.ItemsSource = KiyamobL5Entities.GetContext().Employee.ToList();
            }
        }
    }

}

