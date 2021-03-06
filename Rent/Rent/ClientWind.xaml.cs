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
using System.IO;
using Microsoft.Win32;

namespace Rent
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class ClientWind : Window
    {
        public ClientWind()
        {
            InitializeComponent();
            UpdateWND();
        }

        private void UpdateWND()
        {
            dataGridClient.ItemsSource = ProcessFactory.GetClientProsess().getList();
        }


        private void BTADD_Click_1(object sender, RoutedEventArgs e)
        {
            AddClient wnd = new AddClient();
            wnd.ShowDialog();
            UpdateWND();
        }

        private void BTUPD_Click(object sender, RoutedEventArgs e)
        {

            ClientDto item = dataGridClient.SelectedItem as ClientDto;
            if (item == null)
            {
                MessageBox.Show("Ничего не было выбрано для изменения ╮(￣ω￣)╭ ", "Какой коwмар!");
                return;
            }

            AddClient wnd = new AddClient(item);
            wnd.ShowDialog();
            UpdateWND();
        }

        //удалить
        private void btdel(object sender, RoutedEventArgs e)
        {
            ClientDto item = dataGridClient.SelectedItem as ClientDto;
            if (item == null)
            {
                MessageBox.Show("Ничего не было выбрано для удаления ╮(￣ω￣)╭ ", "Какой коwмар!");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Сейчас произойдет удаление клиента " + item.Name + " (×_×)", "!!!!", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            IClientProsess clientProsess = ProcessFactory.GetClientProsess();
            clientProsess.delete(item.ClientID);
            UpdateWND();
        }

        //закрыть
        private void btclose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SearchClient_Click(object sender, RoutedEventArgs e)
        {
            SearchWind search = new SearchWind("Client");
            {

                search.ShowDialog();
                if (search.exec)
                {
                    this.dataGridClient.ItemsSource = search.FoundClients;
                }

            }
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            UpdateWND();
        }

        private void ExcelExporterButton_Click(object sender, RoutedEventArgs e)
        {
            List<object> grid = null;
            grid = this.dataGridClient.ItemsSource.Cast<object>().ToList();

            SaveFileDialog saveXlsxDialog = new SaveFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel Files(.xlsx)|*.xlsx",
                AddExtension = true,
                FileName = "Client",
            };

            bool? result = saveXlsxDialog.ShowDialog();
            if (result == true)
            {
                FileInfo xlsxFile = new FileInfo(saveXlsxDialog.FileName);
                ProcessFactory.GetReport().fillExcelTableByType(grid, "Client", xlsxFile);
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            SearchWind search = new SearchWind("Client");
            {

                search.ShowDialog();
                if (search.exec)
                {
                    this.dataGridClient.ItemsSource = search.FoundClients;
                }

            }
        }
    }
}



