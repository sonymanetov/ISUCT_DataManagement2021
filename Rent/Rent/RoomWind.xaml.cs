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
    /// Логика взаимодействия для RoomWind.xaml
    /// </summary>
    public partial class RoomWind : Window
    {
        public RoomWind()
        {
            InitializeComponent();
            UpdateWND();
        }
        private void UpdateWND()
        {
            dataGridRoom.ItemsSource = ProcessFactory.GetRoomProcess().getList();
        }

        private void btdelroom_Click(object sender, RoutedEventArgs e)
        {
            RoomDto item = dataGridRoom.SelectedItem as RoomDto;
            if (item == null)
            {
                MessageBox.Show("Ничего не было выбрано для удаления ╮(￣ω￣)╭ ", "Какой коwмар!");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Сейчас произойдет удаление помещения " + item.RoomID + " (×_×)", "!!!!", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            IRoomProcess roomProcess = ProcessFactory.GetRoomProcess();
            roomProcess.Delete(item.RoomID);
            UpdateWND();
        }

        private void btclose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btaddroom_Click(object sender, RoutedEventArgs e)
        {
            AddRoom wnd = new AddRoom();
            wnd.ShowDialog();
            UpdateWND();
        }

        private void addroombt_Click(object sender, RoutedEventArgs e)
        {
            AddRoom wnd = new AddRoom();
            wnd.ShowDialog();
            UpdateWND();
        }
    }
}
