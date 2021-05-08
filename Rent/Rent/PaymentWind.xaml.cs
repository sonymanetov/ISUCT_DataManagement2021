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

    }
}
