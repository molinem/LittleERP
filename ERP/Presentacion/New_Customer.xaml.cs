using ERP.Dominio;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ERP.Presentacion
{
    /// <summary>
    /// Lógica de interacción para New_Customer.xaml
    /// </summary>
    public partial class New_Customer : Window
    {
        public New_Customer()
        {
            InitializeComponent();
        }

        private void btnNewCustomerDB_Click(object sender, RoutedEventArgs e)
        {
            int phone = 0;

            if (txtName.Text.Trim().Equals("") || txtSurname.Text.Trim().Equals("") || txtAddress.Text.Trim().Equals("") || txtPhone.Text.Equals("") || txtEmail.Text.Trim().Equals("") || txtCP.Text.Equals(""))
            {
                MessageBox.Show("Los campos no pueden estar vacios", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (int.TryParse(txtPhone.Text, out phone) && int.Parse(txtPhone.Text) > 0)
                {
                    Customer c = new Customer(txtName.Text, txtSurname.Text, txtAddress.Text, phone, txtEmail.Text, Convert.ToInt32(txtCP.Text));
                    Customer.manager().createCustomer(c);
                    this.Close();
                    MessageBox.Show("Cliente creado correctamente", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El número de móvil debe ser positivo", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void btnSelectCP_Click(object sender, RoutedEventArgs e)
        {
            Zip_Code z = new Zip_Code();
            z.ShowDialog();
        }
    }
}
