using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using RentBusinessLayer;
using Rent_Dto;

namespace Rent
{
    /// <summary>
    /// Логика взаимодействия для StoredProc.xaml
    /// </summary>
    public partial class StoredProc : Window
    {
        public StoredProc()
        {
            InitializeComponent();
        }
        private void okbt_Click(object sender, RoutedEventArgs e)
        {
            string name = tbname.Text;
            if (name == "")
            {
                MessageBox.Show("Ничего не было введено ╮(￣ω￣)╭ ", "Какой коwмар!");
                return;
            }
            dgproc.ItemsSource = ProcessFactory.GetHPProcess().getList(name);

            if (dgproc.Items.Count == 0)
            {
                MessageBox.Show("Для клиента нет акивных договоров ╮(￣ω￣)╭ ", "Результат");
                return;
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
