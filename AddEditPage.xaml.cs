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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
         
    {
        private Employee _currentTable = new Employee();
        public static TablePage tablePage;
        private bool _flag = false;
        public AddEditPage(Employee selectedTable, bool flag = false)
        {
            InitializeComponent();
            if (selectedTable != null)
                _currentTable = selectedTable;
            DataContext = _currentTable;
            _flag = flag;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            

            

            if (_flag)
            {
                KiyamobL5Entities.GetContext().Employee.Add(new Employee() { id = Convert.ToInt32(TbId.Text), FIO = TbFIO.Text, Position = Convert.ToInt32(TbPos.Text), Rank = Convert.ToInt32(TbRank.Text) });
                KiyamobL5Entities.GetContext().SaveChanges();
                tablePage.DGridTable.ItemsSource = KiyamobL5Entities.GetContext().Employee.ToList();
                return;
            }

            try
            {
                KiyamobL5Entities.GetContext().SaveChanges();
               
                MessageBox.Show("Данные успешно добавлены!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
