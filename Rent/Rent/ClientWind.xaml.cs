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
using RentBusinessLayer;

namespace Rent
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class ClientWind : Window
    {
        public ClientWind()
        {
            InitializeComponent();
            dataGridClient.ItemsSource = ProcessFactory.GetClientProsess().getList();
        }

 
        private void BTADD_Click_1(object sender, RoutedEventArgs e)
        {
            AddClient wnd = new AddClient();
            wnd.ShowDialog();
        }

        private void BTUPD_Click(object sender, RoutedEventArgs e)
        {

        }

        //удалить
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //закрыть
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
