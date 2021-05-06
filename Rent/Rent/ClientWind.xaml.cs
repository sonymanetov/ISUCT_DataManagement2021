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
using Rent_Dto;

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
            UpdateWND();
        }

        private void UpdateWND()
        {
            dataGridClient.ItemsSource = ProcessFactory.GetClientProsess().getList();
        }

 
        private void BTADD_Click_1(object sender, RoutedEventArgs e)
        {
            AddClient wnd = new AddClient();
            wnd.ShowDialog();
            UpdateWND();
        }

        private void BTUPD_Click(object sender, RoutedEventArgs e)
        {

        }

        //удалить
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientDto item = dataGridClient.SelectedItem as ClientDto;
            if (item == null)
            {
                MessageBox.Show("Чел, ты ничего не выбрал ╮(￣ω￣)╭ ", "Какой коwмар!");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Сейчас произойдет удаление клиента " + item.Name + " (×_×)", "!!!!", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            IClientProsess clientProsess = ProcessFactory.GetClientProsess();
            clientProsess.delete(item.ClientID);
            UpdateWND();
        }

        //закрыть
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
