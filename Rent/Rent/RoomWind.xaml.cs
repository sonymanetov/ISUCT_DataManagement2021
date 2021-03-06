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
using System.Linq;
using Microsoft.Win32;
using System.IO;

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

        private void addroombt_Click(object sender, RoutedEventArgs e)
        {
            AddRoom wnd = new AddRoom();
            wnd.ShowDialog();
            UpdateWND();
        }

        private void btupdroom_Click(object sender, RoutedEventArgs e)
        {
            RoomDto item = dataGridRoom.SelectedItem as RoomDto;
            if (item == null)
            {
                MessageBox.Show("Ничего не было выбрано для изменения ╮(￣ω￣)╭ ", "Какой коwмар!");
                return;
            }

            AddRoom wnd = new AddRoom(item);
            wnd.ShowDialog();
            UpdateWND();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchWind search = new SearchWind("Room");
            {

                search.ShowDialog();
                if (search.exec)
                {
                    this.dataGridRoom.ItemsSource = search.FoundRooms;
                }

            }
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
                UpdateWND();
        }

        private void ExcelExportButton_Click(object sender, RoutedEventArgs e)
        {
            List<object> grid = null;
            grid = this.dataGridRoom.ItemsSource.Cast<object>().ToList();

            SaveFileDialog saveXlsxDialog = new SaveFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel Files(.xlsx)|*.xlsx",
                AddExtension = true,
                FileName = "Room",
            };

            bool? result = saveXlsxDialog.ShowDialog();
            if (result == true)
            {
                FileInfo xlsxFile = new FileInfo(saveXlsxDialog.FileName);
                ProcessFactory.GetReport().fillExcelTableByType(grid, "Room", xlsxFile);
            }
        }
    }
}
