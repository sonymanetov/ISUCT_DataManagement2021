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
    /// Логика взаимодействия для PaymentWind.xaml
    /// </summary>
    public partial class PaymentWind : Window
    {
        public PaymentWind()
        {
            InitializeComponent();
            UpdateWND();
        }
        private void UpdateWND()
        {
            dataGridPayment.ItemsSource = ProcessFactory.GetPaymentProcess().getList();
        }

        private void btcls_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btdel_Click(object sender, RoutedEventArgs e)
        {
            PaymentDto item = dataGridPayment.SelectedItem as PaymentDto;
            if (item == null)
            {
                MessageBox.Show("Ничего не было выбрано для удаления ╮(￣ω￣)╭ ", "Какой коwмар!");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Сейчас произойдет удаление помещения " + item.PayID + " (×_×)", "!!!!", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            IRoomProcess roomProcess = ProcessFactory.GetRoomProcess();
            roomProcess.Delete(item.PayID);
            UpdateWND();
        }

        private void btadd_Click(object sender, RoutedEventArgs e)
        {
            AddPayment wnd = new AddPayment();
            wnd.ShowDialog();
            UpdateWND();
        }

        private void btupd_Click(object sender, RoutedEventArgs e)
        {
            PaymentDto item = dataGridPayment.SelectedItem as PaymentDto;
            if (item == null)
            {
                MessageBox.Show("Ничего не было выбрано для изменения ╮(￣ω￣)╭ ", "Какой коwмар!");
                return;
            }

            AddPayment wnd = new AddPayment(item);
            wnd.ShowDialog();
            UpdateWND();
        }
    }
}
