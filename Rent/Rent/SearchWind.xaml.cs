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

        private readonly IList<ClientDto> AllowClients = ProcessFactory.GetClientProsess().getList();
        public IList<ClientDto> FoundClients;
        public bool exec;
        private readonly IList<RoomDto> AllowRooms = ProcessFactory.GetRoomProcess().getList();
        public IList<RoomDto> FoundRooms;

        private void sclient_Click(object sender, RoutedEventArgs e)
        {
            this.FoundClients = ProcessFactory.GetClientProsess().SearchClient(this.ClientName.Text, this.tbbank.Text, this.tbagent.Text);
            this.exec = true;
            this.Close();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cancbt_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void roomback_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void sroom_Click(object sender, RoutedEventArgs e)
        {
            this.FoundRooms = ProcessFactory.GetRoomProcess().SearchRoom(Convert.ToInt32(tbnumber.Text), Convert.ToDecimal(pl1.Text), Convert.ToDecimal(price1.Text), Convert.ToDecimal(price2.Text));
            this.exec = true;
            this.Close();
        }

    }
}
