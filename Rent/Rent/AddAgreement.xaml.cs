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
    /// Логика взаимодействия для AddAgreement.xaml
    /// </summary>
    public partial class AddAgreement : Window
    {
        private AgreementDto agreementdto;

        private static readonly string[] cl = { "aaa", "baa", "aba" }; 
        private void LoadAgreement()
        {
            if (agreementdto == null)
            {
                return;
            }
            tbclient.Text = agreementdto.ClientID.ToString();
            tbroom.Text = agreementdto.RoomID.ToString();
            tbstart.Text = agreementdto.Start.ToString();
            tbfinish.Text = agreementdto.Finish.ToString();
            tbday.Text = agreementdto.Payday.ToString();
        }
        public AddAgreement(AgreementDto agreement = null)
        {
            agreementdto = agreement;
            InitializeComponent();
            LoadAgreement();
            cbclient.ItemsSource = cl;
            cbclient.SelectedIndex = 0;
        } 

        private void btsave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbclient.Text))
            {
                MessageBox.Show("Код организации не указан ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(tbroom.Text))
            {
                MessageBox.Show("Номер помещения не указан ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(tbstart.Text))
            {
                MessageBox.Show("Дата начала действия договора не указана ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(tbfinish.Text))
            {
                MessageBox.Show("Дата окончания действия договора не указана ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(tbday.Text))
            {
                MessageBox.Show("День ежемесячных выплат не указан ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }

            if (agreementdto == null)
            {
                AgreementDto agreementdto = new AgreementDto();
                agreementdto.ClientID = Convert.ToInt32(tbclient.Text);
                agreementdto.RoomID = Convert.ToInt32(tbroom.Text);
                agreementdto.Start = Convert.ToDateTime(tbstart.Text);
                agreementdto.Finish = Convert.ToDateTime(tbfinish.Text);
                agreementdto.Payday = Convert.ToDecimal(tbday.Text);

                IAgreementProcess agreementProcess = ProcessFactory.GetAgreementProcess();
                agreementProcess.Add(agreementdto);
                MessageBox.Show("Договор добавлен °˖✧◝(⁰▿⁰)◜✧˖° ", "Всё получилось!");
            }
            else
            {
                agreementdto.ClientID = Convert.ToInt32(tbclient.Text);
                agreementdto.RoomID = Convert.ToInt32(tbroom.Text);
                agreementdto.Start = Convert.ToDateTime(tbstart.Text);
                agreementdto.Finish = Convert.ToDateTime(tbfinish.Text);
                agreementdto.Payday = Convert.ToDecimal(tbday.Text);

                IAgreementProcess agreementProcess = ProcessFactory.GetAgreementProcess();
                agreementProcess.Update(agreementdto);
                MessageBox.Show("Данные изменены °˖✧◝(⁰▿⁰)◜✧˖° ", "Всё получилось!");
            }
        }
    private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbclient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
