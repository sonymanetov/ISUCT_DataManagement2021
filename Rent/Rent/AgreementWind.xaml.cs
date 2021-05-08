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
    }
}
