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

        private void btclients_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
