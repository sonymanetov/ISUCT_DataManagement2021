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
using Rent_Dto;
using RentBusinessLayer;

namespace Rent
{
    /// <summary>
    /// Логика взаимодействия для AddPayment.xaml
    /// </summary>
    public partial class AddPayment : Window
    {
        private PaymentDto paymentdto;

        private void LoadPayment()
        {
            if (paymentdto == null)
            {
                return;
            }
            tbrent.Text = paymentdto.RentID.ToString();
            tbdate.Text = paymentdto.Date.ToString();
            tbmonth.Text = paymentdto.Month.ToString();
            tbsum.Text = paymentdto.Sum.ToString();
            tbontime.Text = paymentdto.Ontime.ToString();
        }
        public AddPayment(PaymentDto payment = null)
        {
            paymentdto = payment;
            InitializeComponent();
            LoadPayment();
        }


        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btsave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbrent.Text))
            {
                MessageBox.Show("Код договора не указан ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(tbdate.Text))
            {
                MessageBox.Show("Дата платежа не указана ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(tbmonth.Text))
            {
                MessageBox.Show("Оплачиваемый месяц не указан ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(tbsum.Text))
            {
                MessageBox.Show("Сумма платежа не указана ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(tbontime.Text))
            {
                MessageBox.Show("Своевременность не обозначена ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }

            if (paymentdto == null)
            {
                PaymentDto paymentdto = new PaymentDto();
                paymentdto.RentID = Convert.ToInt32(tbrent.Text);
                paymentdto.Date = Convert.ToDateTime(tbdate.Text);
                paymentdto.Month = Convert.ToInt32(tbmonth.Text);
                paymentdto.Sum = Convert.ToDecimal(tbsum.Text);
                paymentdto.Ontime = Convert.ToBoolean(tbontime.Text);

                IPaymentProcess paymentProcess = ProcessFactory.GetPaymentProcess();
                paymentProcess.Add(paymentdto);
                MessageBox.Show("Платеж добавлена °˖✧◝(⁰▿⁰)◜✧˖° ", "Всё получилось!");
            }
            else
            {
                paymentdto.RentID = Convert.ToInt32(tbrent.Text);
                paymentdto.Date = Convert.ToDateTime(tbdate.Text);
                paymentdto.Month = Convert.ToInt32(tbmonth.Text);
                paymentdto.Sum = Convert.ToDecimal(tbsum.Text);
                paymentdto.Ontime = Convert.ToBoolean(tbontime.Text);


                IPaymentProcess paymentProcess = ProcessFactory.GetPaymentProcess();
                paymentProcess.Update(paymentdto);
                MessageBox.Show("Данные изменены °˖✧◝(⁰▿⁰)◜✧˖° ", "Всё получилось!");
            }
        }
    }
 }

