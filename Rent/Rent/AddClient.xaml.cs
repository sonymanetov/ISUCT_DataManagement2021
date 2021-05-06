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
        private ClientDto clientdto;

        private void LoadClient()
        {
            if (clientdto == null)
            {
                return;
            }
            nametb.Text = clientdto.Name;
            banktb.Text = clientdto.BankDetails;
            adresstb.Text = clientdto.Adress;
            phonetb.Text = clientdto.Phone;
            agenttb.Text = clientdto.AgentName;
        }
        public AddClient(ClientDto client = null)
        {
            clientdto = client;
            InitializeComponent();
            LoadClient();
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

            if (clientdto == null)
            {
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
            else
            {
                clientdto.Name = nametb.Text;
                clientdto.BankDetails = banktb.Text;
                clientdto.Adress = adresstb.Text;
                clientdto.Phone = phonetb.Text;
                clientdto.AgentName = agenttb.Text;

                IClientProsess clientProsess = ProcessFactory.GetClientProsess();
                clientProsess.update(clientdto);
                MessageBox.Show("Данные изменены °˖✧◝(⁰▿⁰)◜✧˖° ", "Всё получилось!");
            }
        }
    }
}
