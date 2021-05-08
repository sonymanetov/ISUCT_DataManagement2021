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
    /// Логика взаимодействия для AgreementWind.xaml
    /// </summary>
    public partial class AgreementWind : Window
    {
        public AgreementWind()
        {
            InitializeComponent();
            UpdateWND();
        }
        private void UpdateWND()
        {
            dataGridAgreement.ItemsSource = ProcessFactory.GetAgreementProcess().getList();
        }

        private void btclose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btaddag_Click(object sender, RoutedEventArgs e)
        {
            AddAgreement wnd = new AddAgreement();
            wnd.ShowDialog();
            UpdateWND();
        }

        private void btupdag_Click(object sender, RoutedEventArgs e)
        {
            AgreementDto item = dataGridAgreement.SelectedItem as AgreementDto;
            if (item == null)
            {
                MessageBox.Show("Ничего не было выбрано для изменения ╮(￣ω￣)╭ ", "Какой коwмар!");
                return;
            }

            AddAgreement wnd = new AddAgreement(item);
            wnd.ShowDialog();
            UpdateWND();
        }

        private void btdelag_Click(object sender, RoutedEventArgs e)
        {
            AgreementDto item = dataGridAgreement.SelectedItem as AgreementDto;
            if (item == null)
            {
                MessageBox.Show("Ничего не было выбрано для удаления ╮(￣ω￣)╭ ", "Какой коwмар!");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Сейчас произойдет удаление помещения " + item.RentID + " (×_×)", "!!!!", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            IAgreementProcess agreementProcess = ProcessFactory.GetAgreementProcess();
            agreementProcess.Delete(item.RentID);
            UpdateWND();
        }
    }
}
