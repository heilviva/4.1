using System;
using System.Collections.Generic;
using System.Data;
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
using _4._1.ITCompanyDataSetTableAdapters;

namespace _4._1
{
    /// <summary>
    /// Логика взаимодействия для SecondPage.xaml
    /// </summary>
    public partial class SecondPage : Window

    {
        EmployeesTableAdapter context = new EmployeesTableAdapter();
        public SecondPage()
        {
            InitializeComponent();
            employeesGrd.ItemsSource = context.GetData();
            Cbx.ItemsSource = context.GetData();
            Cbx.DisplayMemberPath = "LastName";
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            employeesGrd.ItemsSource = context.SearchByName(SearchTxt.Text);
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            employeesGrd.ItemsSource = context.GetData();
        }

        private void Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbx.SelectedItem != null)
            {
                var id = (int)(Cbx.SelectedItem as DataRowView).Row[0];
                employeesGrd.ItemsSource = context.FilterByEmployee(id);
            }
        }
    }
}
