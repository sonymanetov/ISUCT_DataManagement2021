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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void btclients_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void savebt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nametb.Text))
            {
                MessageBox.Show("Название организации не указано ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(banktb.Text))
            {
                MessageBox.Show("Номер счета организации не указан ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(adresstb.Text))
            {
                MessageBox.Show("Юридический адрес организации не указан ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(phonetb.Text))
            {
                MessageBox.Show("Номер телефона не указан ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(agenttb.Text))
            {
                MessageBox.Show("ФИО агента не указаны ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            ClientDto clientdto = new ClientDto();
            clientdto.Name = nametb.Text;
            clientdto.BankDetails = banktb.Text;
            clientdto.Adress = adresstb.Text;
            clientdto.Phone = phonetb.Text;
            clientdto.AgentName = agenttb.Text;

            IClientProsess clientProsess = ProcessFactory.GetClientProsess();
            clientProsess.add(clientdto);
            MessageBox.Show("Клиент добавлен °˖✧◝(⁰▿⁰)◜✧˖° ", "Всё получилось!");
        }
    }
}
