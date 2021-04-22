using ERP.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ERP
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int idCustomer;
        public MainWindow()
        {
            InitializeComponent();
            //Load Clients that not deleted
            Customer.manager().startDataGridCustomers(dgCustomer);
        }
        
        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            //Option + for create new customer
            WCustomer cc = new WCustomer('+');
            cc.ShowDialog();
            //Refresh DataGrid
            Customer.manager().startDataGridCustomers(dgCustomer);
        }

        private void btnModifyCustomer_Click(object sender, RoutedEventArgs e)
        {
            
            //Obtain id of customer selected
            //DataRowView row = (DataRowView)dgCustomer.SelectedItems[0];
            //idCustomer = int.Parse(row["IDCUSTOMER"].ToString());

            DataRowView dataRowView = (DataRowView)dgCustomer.SelectedItem;
            if(dataRowView != null)
            {
                idCustomer = Convert.ToInt32(dataRowView.Row[0]);

                String dni = Convert.ToString(dataRowView.Row[1]);
                String name = Convert.ToString(dataRowView.Row[2]);
                String surname = Convert.ToString(dataRowView.Row[3]);
                String address = Convert.ToString(dataRowView.Row[4]);
                int phone = Convert.ToInt32(dataRowView.Row[5]);
                String email = Convert.ToString(dataRowView.Row[6]);
                String city = Convert.ToString(dataRowView.Row[7]);

                //Option M for Modify customer
                WCustomer cc = new WCustomer('M', idCustomer, dni, name, surname, address, phone, email, city);

                cc.ShowDialog();
                //Refresh DataGrid
                Customer.manager().startDataGridCustomers(dgCustomer);
            }
            else
            {
                MessageBox.Show("Debes seleccionar un cliente.", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }


        private void btnBusqueda_Click(object sender, RoutedEventArgs e)
        {
       
        }

        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
        }
    }
}
