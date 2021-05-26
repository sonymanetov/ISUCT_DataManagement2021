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
    /// Логика взаимодействия для SearchWind.xaml
    /// </summary>
    public partial class SearchWind : Window
    {
        public SearchWind(string status)
        {
            InitializeComponent();
            switch (status)
            {
                case "Client":
                    this.SC.SelectedIndex = 0;
                    this.Room.Visibility = Visibility.Collapsed;
                    //this.Agreement.Visibility = Visibility.Collapsed;
                    //this.Payment.Visibility = Visibility.Collapsed;
                    break;

                case "Room":
                    this.SC.SelectedIndex = 1;
                    this.Client.Visibility = Visibility.Collapsed;
                    //this.Agreement.Visibility = Visibility.Collapsed;
                    //this.Payment.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        //выход
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private readonly IList<ClientDto> AllowClients = ProcessFactory.GetClientProsess().getList();
        public IList<ClientDto> FoundClients;
        public bool exec;

        private void sclient_Click(object sender, RoutedEventArgs e)
        {
            this.FoundClients = ProcessFactory.GetClientProsess().SearchClient(this.ClientName.Text, this.tbbank.Text, this.tbagent.Text);
            this.exec = true;
            this.Close();

        }
    }
}
