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
    /// Логика взаимодействия для AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
       private RoomDto roomdto;

        private void LoadRoom()
        {
            if (roomdto == null)
            {
                return;
            }
            tbfloor.Text = roomdto.Floor.ToString();
            tbarea.Text = roomdto.Area.ToString();
            tbcond.Text = roomdto.Conditioner.ToString();
            tbcost.Text = roomdto.RentCostPerDay.ToString();
        }
        public AddRoom(RoomDto room = null)
        {
            roomdto = room;
            InitializeComponent();
            LoadRoom();
        }

        private void btclose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //save button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbfloor.Text))
            {
                MessageBox.Show("Этаж не указан ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(tbarea.Text))
            {
                MessageBox.Show("Площадь помещения не указана ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(tbcond.Text))
            {
                MessageBox.Show("Наличие кондиционера не обозначено ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }
            if (string.IsNullOrEmpty(tbcost.Text))
            {
                MessageBox.Show("Цена аренды в сутки не указана ୧((#Φ益Φ#))୨", "Фатальная ошибка");
                return;
            }

            if (roomdto == null)
            {
                RoomDto roomdto = new RoomDto();
                roomdto.Floor = Convert.ToDecimal(tbfloor.Text);
                roomdto.Area = Convert.ToDecimal(tbarea.Text);
                roomdto.Conditioner = Convert.ToBoolean(tbcond.Text);
                roomdto.RentCostPerDay = Convert.ToDecimal(tbcost.Text);

                IRoomProcess roomProcess = ProcessFactory.GetRoomProcess();
                roomProcess.Add(roomdto);
                MessageBox.Show("Комната добавлена °˖✧◝(⁰▿⁰)◜✧˖° ", "Всё получилось!");
            }
            else
            {
                roomdto.Floor = Convert.ToDecimal(tbfloor.Text);
                roomdto.Area = Convert.ToDecimal(tbarea.Text);
                roomdto.Conditioner = Convert.ToBoolean(tbcond.Text);
                roomdto.RentCostPerDay = Convert.ToDecimal(tbcost.Text);


                IRoomProcess roomProcess = ProcessFactory.GetRoomProcess();
                roomProcess.Update(roomdto);
                MessageBox.Show("Данные изменены °˖✧◝(⁰▿⁰)◜✧˖° ", "Всё получилось!");
            }
        }
    }
}
