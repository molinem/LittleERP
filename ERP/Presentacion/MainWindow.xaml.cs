﻿using ERP.Dominio;
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
        private int idProduct;

        public MainWindow()
        {
            InitializeComponent();
            //Load Clients that not deleted
            Customer.manager().startDataGridCustomers(dgCustomer);

            //Hide Column id
            this.dgCustomer.Columns[0].Visibility = Visibility.Hidden;


            //Bug if you try to load on event tabControlSelectionChanged
            //Windows Load event -> works
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

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)dgCustomer.SelectedItem;
            if (dataRowView != null)
            {
                idCustomer = int.Parse(dataRowView.Row[0].ToString());
                DialogResult result = MessageBox.Show("¿Estas seguro que quieres borrar el Cliente: " + dataRowView.Row[2].ToString() + " ?", "LittleERP", MessageBoxButtons.OKCancel);
                
                
                if (result.ToString().Equals("OK"))
                {
                    //Delete user -->delete logic
                    Customer.manager().deleteCustomer(idCustomer);

                    //Refresh DataGrid
                    Customer.manager().startDataGridCustomers(dgCustomer);
                }
            }
            else 
            {
                MessageBox.Show("Debes seleccionar un cliente.", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnBusqueda_Click(object sender, RoutedEventArgs e)
        {
       
        }


        private void txtSearchByName(object sender, TextChangedEventArgs e)
        {
            if (txtFilterName.Text.Contains("'"))
            {
                txtFilterName.Text = "";
                MessageBox.Show("No puedes usar símbolos como \' \" ?", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                //String nameCustomer = txtFilterName.Text;
                //Customer.manager().searchByNameDataGridCustomers(dgCustomer, nameCustomer);


                //Other method
                /*foreach (DataGridViewRow row in dgCustomer)
                {
                    //string cadFecha = (string)row.Cells[5].Value;
                    //DateTime fecha = DateTime.ParseExact(cadFecha, "dd'/'MM'/'yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                    CurrencyManager currencyManager1 = (CurrencyManager)dgCustomer.ItemsSource;
                    currencyManager1.SuspendBinding();

                    if (!txtFilterName.Text.ToString().Equals("") && !row.Cells[2].Value.ToString().Contains(txtFilterName.Text.ToString()))
                    {
                        row.Visible = false;
                    }

                    currencyManager1.ResumeBinding();
                }*/
            }
        }

        //When tab products is loaded
        private void tabProducts_Loaded(object sender, RoutedEventArgs e)
        {
            Product.manager().startDataGridProduct(dgProducts);
            //Hide Column id
            this.dgProducts.Columns[0].Visibility = Visibility.Hidden;
        }


        private void btnNewProduct_Click(object sender, RoutedEventArgs e)
        {
            WProduct p = new WProduct('+');
            p.ShowDialog();

            //Refresh dgProducts
            Product.manager().startDataGridProduct(dgProducts);
        }

        private void btnModifyProduct_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)dgProducts.SelectedItem;
            if (dataRowView != null)
            {
                idProduct = Convert.ToInt32(dataRowView.Row[0]);
                String name = Convert.ToString(dataRowView.Row[1]);
                double price = Convert.ToDouble(dataRowView.Row[4]);
                int amount = Convert.ToInt32(dataRowView.Row[5]);
                
                //Option M for Modify customer
                WProduct pr = new WProduct('M', idProduct, name, price, amount);
                pr.ShowDialog();

                //Refresh DataGrid
                Product.manager().startDataGridProduct(dgProducts);
            }
            else
            {
                MessageBox.Show("Debes seleccionar un producto.", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)dgProducts.SelectedItem;
            if (dataRowView != null)
            {
                idProduct = int.Parse(dataRowView.Row[0].ToString());
                DialogResult result = MessageBox.Show("¿Estas seguro que quieres borrar el Producto: " + dataRowView.Row[1].ToString() + " ?", "LittleERP", MessageBoxButtons.OKCancel);


                if (result.ToString().Equals("OK"))
                {
                    //Delete Product -->delete logic
                    Product.manager().deleteProduct(idProduct);

                    //Refresh DataGrid
                    Product.manager().startDataGridProduct(dgProducts);
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un cliente.", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
