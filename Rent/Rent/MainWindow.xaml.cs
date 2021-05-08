using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Rent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           //var b =  new SqlConnection(); 
            InitializeComponent();
           
            datetext.Text = DateTime.Now.ToShortDateString();
        }

        private void btclients_Click(object sender, RoutedEventArgs e)
        {
            ClientWind wnd = new ClientWind();
            wnd.ShowDialog();
        }

        //exit
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btroom_Click(object sender, RoutedEventArgs e)
        {
            RoomWind wnd = new RoomWind();
            wnd.ShowDialog();
        }

        private void btagreement_Click(object sender, RoutedEventArgs e)
        {
            AgreementWind wnd = new AgreementWind();
            wnd.ShowDialog();
        }

        private void btpay_Click(object sender, RoutedEventArgs e)
        {
            PaymentWind wnd = new PaymentWind();
            wnd.ShowDialog();
        }
    }
}
