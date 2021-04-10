using ERP.Dominio;
using ERP.Presentacion;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ERP
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         
        public MainWindow()
        {
            InitializeComponent();
            //Load Clients that not deleted
            Customer.manager().startDataGrid(dgClientes);
        }

        
        
        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            New_Customer cc = new New_Customer();
            cc.ShowDialog();
            //Refresh DataGrid
            Customer.manager().startDataGrid(dgClientes);
        }


        private void btnBusqueda_Click(object sender, RoutedEventArgs e)
        {
       
        }

        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            DataRowView row = dgClientes.SelectedItem as DataRowView;
            MessageBox.Show(row.Row.ItemArray[0].ToString());
            Console.WriteLine("------------------- " + row.ToString());
        }
    }
}
