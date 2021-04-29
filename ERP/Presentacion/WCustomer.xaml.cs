using ERP.Dominio;
using ERP.Dominio.Manager;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;
using ToolTip = System.Windows.Controls.ToolTip;

namespace ERP
{
    /// <summary>
    /// Lógica de interacción para WCustomer.xaml
    /// </summary>
    public partial class WCustomer : Window
    {
        private char optionSelected;
        private int idCustomerSelected;

        //--------------------------------------------------------------------Constructors----------------------------------------------------------------------------------
        public WCustomer(char option)
        {
            //New Customer
            InitializeComponent();
            optionSelected = option;

            //Initial configuration
            txtName.MaxLength = 30;
            txtSurname.MaxLength = 20;
            txtAddress.MaxLength = 30;
            txtPhone.MaxLength = 9;
            txtDni.MaxLength = 9;
            txtEmail.MaxLength = 20;

            Customer.manager().refillComboRegion(cboRegion);
            Customer.manager().startListTags(listTagsOriginal);
        }

        public WCustomer(char option, int idCustomer, String dni, String name, String surname, String address,int phone, String email, String city)
        {
            //Modify Customer
            InitializeComponent();
            optionSelected = option;
            idCustomerSelected = idCustomer;

            //Initial configuration
            this.Title = "Modificar Cliente";
            txtTitle.Content =" MODIFICAR CLIENTE";
            txtName.MaxLength = 30;
            txtSurname.MaxLength = 20;
            txtAddress.MaxLength = 30;
            txtPhone.MaxLength = 9;
            txtDni.MaxLength = 9;
            txtEmail.MaxLength = 20;

            txtDni.Text = dni;
            txtName.Text = name;
            txtSurname.Text = surname;
            txtAddress.Text = address;
            txtPhone.Text = phone.ToString();
            txtEmail.Text = email;
            String nameCity = city;

            Customer.manager().refillComboRegion(cboRegion);
            Customer.manager().refillAllCombos(idCustomer, cboRegion, cboState, cboCity, cboZipCode);
            Customer.manager().loadTagsList(listTagsOriginal, listTagsSelected, idCustomer);
        }

        //--------------------------------------------------------------------Buttons----------------------------------------------------------------------------------
        private void btnNewCustomerDB_Click(object sender, RoutedEventArgs e)
        {
            int state, city, zipCode;
            if (txtDni.Text.ToString().Equals("") || txtAddress.Text.ToString().Equals("") || txtEmail.Text.ToString().Equals("") || txtName.Text.ToString().Equals("") || txtPhone.Text.ToString().Equals("") || txtSurname.Text.ToString().Equals("") || listTagsSelected.Items.IsEmpty)
            {
                MessageBox.Show("Debes rellenar todos los campos.", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string message = "";

                int id = -1;

                if (!Auxiliary.correctDni(txtDni))
                {
                    message = message + "//Formato del DNI incorrecto//";
                }

                if (!Auxiliary.correctName(txtName))
                {
                    message = message + "//Campo Nombre incorrecto//";
                }

                if (!Auxiliary.correctSurname(txtSurname))
                {
                    message = message + "//Campo Apellido incorrecto//";
                }

                if (!Auxiliary.correctAddress(txtAddress))
                {
                    message = message + "//Campo Dirección incorrecto//";
                }

                if (!Auxiliary.correctEmail(txtEmail))
                {
                    message = message + "//Campo Email incorrecto//";
                }

                if (!Auxiliary.correctPhone(txtPhone))
                {
                    message = message + "//Campo teléfono incorrecto";
                }

                if (cboRegion.SelectedIndex > 0 && cboState.SelectedIndex > 0 && cboCity.SelectedIndex > 0 && cboZipCode.SelectedIndex > 0)
                {
                    //Obtain data from ComboBox
                    //Obtain State
                    state = Auxiliary.obtainSelectedOnComboBox(cboState);

                    //Obtain city
                    city = Auxiliary.obtainSelectedOnComboBox(cboCity);

                    //Obtain zipcode
                    zipCode = Auxiliary.obtainSelectedOnComboBox(cboZipCode);

                    id = Customer.manager().searchZipCodeCities(state, city, zipCode);
                }
                else
                {
                    message = message + "//Debes seleccionar la ciudad//";
                }

                if (message.Equals(""))
                {
                    String DNI = txtDni.Text.ToUpper();
                    String name = txtName.Text;
                    String surname = txtSurname.Text;
                    String address = txtAddress.Text;
                    int phone = int.Parse(txtPhone.Text);
                    String email = txtEmail.Text;

                    //Insert or modify
                    if (optionSelected == '+')
                    {
                        //Insert new customer -- id (CP)
                        Customer c = new Customer(name, DNI, surname, address, phone, email, id);
                        Customer.manager().createCustomer(c);

                        //Obtain all selected tags and insert to DB
                        Customer.manager().add_tags_new_customer(listTagsSelected.Items);
                        MessageBox.Show("Cliente creado correctamente", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Modify
                        //Update customer
                        Customer updateC = new Customer(idCustomerSelected, DNI, name, surname, address, phone, email, id);
                        Customer.manager().modifyCustomer(updateC);

                        //Add Tags
                        Customer.manager().updateTags(updateC, listTagsSelected.Items);
                        MessageBox.Show("Cliente actualizado correctamente", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show(message, "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void btnSelectCP_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //For clean all fields
        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txtDni.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            Customer.manager().refillComboRegion(cboRegion);
            listTagsOriginal.Items.Clear();
            listTagsSelected.Items.Clear();
            Customer.manager().startListTags(listTagsOriginal);

            //Reset ComboBox
            cboState.SelectedIndex = 0;
            cboCity.SelectedIndex = 0;
            cboZipCode.SelectedIndex = 0;


            cboState.IsEnabled = false;
            cboCity.IsEnabled = false;
            cboZipCode.IsEnabled = false;
        }

        //--------------------------------------------------------------------ComboBox----------------------------------------------------------------------------------
        private void cboRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboRegion.SelectedIndex > 0)
            {
                //Obtain data from combobox
                int region = Auxiliary.obtainSelectedOnComboBox(cboRegion);
                
                //Refill
                Customer.manager().refillComboState(cboState, region);
                cboState.IsEnabled = true;

                cboCity.SelectedIndex = 0;
                cboZipCode.SelectedIndex = 0;
            }
            else
            {
                cboState.IsEnabled = false;
                cboCity.IsEnabled = false;
                cboZipCode.IsEnabled = false;
            }
        }

        private void cboState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboState.SelectedIndex > 0)
            {
                //Obtain state
                int state = Auxiliary.obtainSelectedOnComboBox(cboState);
                //Refill cities
                Customer.manager().refillComboCities(cboCity, state);
                cboCity.IsEnabled = true;
                cboZipCode.SelectedIndex = 0;
            }
            else
            {
                cboCity.IsEnabled = false;
                cboZipCode.IsEnabled = false;
            }
        }

        private void cboCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboCity.SelectedIndex > 0)
            {
                //Obtain City
                int city = Auxiliary.obtainSelectedOnComboBox(cboCity);

                //Obtain state
                int state = Auxiliary.obtainSelectedOnComboBox(cboState);


                //Refill CP
                Customer.manager().refillComboCP(cboZipCode, state, city);
                cboZipCode.IsEnabled = true;
            }
            else
            {
                cboZipCode.IsEnabled = false;
            }
        }

        //--------------------------------------------------------------------ListBox----------------------------------------------------------------------------------
        private void btnSelected_Click(object sender, RoutedEventArgs e)
        {
            if (listTagsOriginal.SelectedItem != null)
            {
                listTagsSelected.Items.Add(listTagsOriginal.SelectedItem);
                listTagsOriginal.Items.Remove(listTagsOriginal.SelectedItem);
            }
        }

        private void btnNotSelected_Click(object sender, RoutedEventArgs e)
        {
            if (listTagsSelected.SelectedItem != null)
            {
                listTagsOriginal.Items.Add(listTagsSelected.SelectedItem);
                listTagsSelected.Items.Remove(listTagsSelected.SelectedItem);
            }
        }

    }
}
