﻿using ERP.Dominio;
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

namespace ERP.Presentacion
{
    /// <summary>
    /// Lógica de interacción para New_Customer.xaml
    /// </summary>
    public partial class New_Customer : Window
    {
        private char option;
        public New_Customer(char option)
        {
            InitializeComponent();

            txtName.MaxLength = 30;
            txtSurname.MaxLength = 20;
            txtAddress.MaxLength = 30;
            txtPhone.MaxLength = 9;
            txtDni.MaxLength = 9;
            txtEmail.MaxLength = 20;

            Customer.manager().refillComboRegion(cboRegion);
        }

        private void btnNewCustomerDB_Click(object sender, RoutedEventArgs e)
        {
            if (txtDni.Text.ToString().Equals("") || txtAddress.Text.ToString().Equals("") || txtEmail.Text.ToString().Equals("") || txtName.Text.ToString().Equals("") || txtPhone.Text.ToString().Equals("") || txtSurname.Text.ToString().Equals(""))
            {
                MessageBox.Show("Debes rellenar todos los campos.", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string message = "";

                int id = -1;

                if (!correctDni())
                {
                    message = message + "//Formato del DNI incorrecto//";
                }

                if (!correctName())
                {
                    message = message + "//Campo Nombre incorrecto//";
                }

                if (!correctSurname())
                {
                    message = message + "//Campo Apellido incorrecto//";
                }

                if (!correctAddress())
                {
                    message = message + "//Campo Dirección incorrecto//";
                }

                if (!correctEmail())
                {
                    message = message + "//Campo Email incorrecto//";
                }

                if (!correctPhone())
                {
                    message = message + "//Campo teléfono incorrecto";
                }

                if (cboRegion.SelectedIndex > 0 && cboState.SelectedIndex > 0 && cboCity.SelectedIndex > 0 && cboZipCode.SelectedIndex > 0)
                {
                    //Obtain data from ComboBox
                    //Obtain State
                    DataRowView row = (DataRowView)cboState.SelectedItem;
                    DataRow data = row.Row;
                    Object[] objData = data.ItemArray;
                    decimal stateData = (decimal)objData[0];
                    int state = (int)stateData;

                    //Obtain city
                    row = (DataRowView)cboCity.SelectedItem;
                    data = row.Row;
                    objData = data.ItemArray;
                    decimal cityData = (decimal)objData[0];
                    int city = (int)cityData;

                    //Obtain zipcode
                    row = (DataRowView)cboZipCode.SelectedItem;
                    data = row.Row;
                    objData = data.ItemArray;
                    decimal zipcodeDato = (decimal)objData[0];
                    int zipcode = (int)zipcodeDato;

                    id = Customer.manager().searchZipCodeCities(state, city, zipcode);
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
                    if (option == '+')
                    {
                        //Insert
                        Customer c = new Customer(name, DNI, surname, address, phone, email, id);
                        Customer.manager().createCustomer(c);
                    }
                    else
                    {
                        //Modify
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
            Zip_Code z = new Zip_Code();
            z.ShowDialog();
        }

        
        private void cboRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboRegion.SelectedIndex > 0)
            {
                //Obtain data from combobox
                DataRowView row = (DataRowView)cboRegion.SelectedItem;
                DataRow data = row.Row;
                Object[] objData = data.ItemArray;
                decimal regionData = (decimal)objData[0];
                int region = (int)regionData;
                
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
                DataRowView row = (DataRowView)cboState.SelectedItem;
                DataRow data = row.Row;
                Object[] objData = data.ItemArray;
                decimal stateData = (decimal)objData[0];
                int state = (int)stateData;
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
                //Se coge la ciudad
                DataRowView row = (DataRowView)cboCity.SelectedItem;
                DataRow data = row.Row;
                Object[] objData = data.ItemArray;
                decimal cityData = (decimal)objData[0];
                int city = (int)cityData;

                //Se coge la provincia
                row = (DataRowView)cboState.SelectedItem;
                data = row.Row;
                objData = data.ItemArray;
                decimal stateData = (decimal)objData[0];
                int state = (int)stateData;


                //Se rellenan los códigos postales
                Customer.manager().refillComboCP(cboZipCode, state, city);
                cboZipCode.IsEnabled = true;
            }
            else
            {
                cboZipCode.IsEnabled = false;
            }
        }

        public bool correctDni()
        {
            //8 dígits 1 letter)
            string patron = "[A-HJ-NP-SUVW][0-9]{7}[0-9A-J]|\\d{8}[TRWAGMYFPDXBNJZSQVHLCKE]|[X]\\d{7}[TRWAGMYFPDXBNJZSQVHLCKE]|[X]\\d{8}[TRWAGMYFPDXBNJZSQVHLCKE]|[YZ]\\d{0,7}[TRWAGMYFPDXBNJZSQVHLCKE]";
            string sRemp = "";
            bool ret = false;
            System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(patron);
            sRemp = rgx.Replace(txtDni.Text.ToString().ToUpper(), "OK");
            if (sRemp == "OK") ret = true;

            //Check is letter is correct
            if (ret)
            {
                string data = txtDni.Text.ToString().ToUpper();
                string readLetter= data.Substring(data.Length - 1, 1);

                int nifNum = int.Parse(data.Substring(0, data.Length - 1));

                string correctLetter = getLetter(nifNum % 23);
                if (!correctLetter.Equals(readLetter))
                {
                    ret = false;
                }
            }
            return ret;
        }


        //Méthod that return correct letter of DNI
        private static string getLetter(int id)
        {
            Dictionary<int, String> letters = new Dictionary<int, string>();
            letters.Add(0, "T");
            letters.Add(1, "R");
            letters.Add(2, "W");
            letters.Add(3, "A");
            letters.Add(4, "G");
            letters.Add(5, "M");
            letters.Add(6, "Y");
            letters.Add(7, "F");
            letters.Add(8, "P");
            letters.Add(9, "D");
            letters.Add(10, "X");
            letters.Add(11, "B");
            letters.Add(12, "N");
            letters.Add(13, "J");
            letters.Add(14, "Z");
            letters.Add(15, "S");
            letters.Add(16, "Q");
            letters.Add(17, "V");
            letters.Add(18, "H");
            letters.Add(19, "L");
            letters.Add(20, "C");
            letters.Add(21, "K");
            letters.Add(22, "E");
            return letters[id];
        }

        public bool correctName()
        {
            bool ok = true;

            string name = txtName.Text;
            if (name != null)
            {
                if (name.Length < 30)
                {
                    if (!name.Equals(""))
                    {
                        for (int i = 0; i < name.Length; i++)
                        {
                            char car = name[i];
                            if (Char.IsDigit(car))
                            {
                                ok = false;
                            }
                        }

                        if (name.Contains("'"))
                        {
                            ok = false;
                        }
                    }
                    else
                    {
                        ok = false;
                    }
                }
                else
                {
                    ok = false;
                }
            }

            return ok;
        }


        public bool correctSurname()
        {
            bool ok = true;

            string surname = txtSurname.Text;
            if (surname != null)
            {
                if (surname.Length < 20)
                {
                    if (!surname.Equals(""))
                    {
                        for (int i = 0; i < surname.Length && ok; i++)
                        {
                            char car = surname[i];
                            if (Char.IsDigit(car))
                            {
                                ok = false;
                            }
                        }

                        if (surname.Contains("'"))
                        {
                            ok = false;
                        }
                    }
                    else
                    {
                        ok = false;
                    }
                }
                else
                {
                    ok = false;
                }
            }

            return ok;
        }


        public bool correctAddress()
        {
            bool ok = true;

            string address = txtAddress.Text;
            if (address != null)
            {
                if (address.Length <= 30)
                {
                    if (!address.Equals(""))
                    {
                        if (address.Contains("'"))
                        {
                            ok = false;
                        }
                    }
                    else
                    {
                        ok = false;
                    }
                }
                else
                {
                    ok = false;
                }

            }
            else
            {
                ok = false;
            }
            return ok;
        }

        public bool correctPhone()
        {
            bool ok = true;

            string phone = txtPhone.Text;
            if (phone != null)
            {
                try
                {
                    int number = int.Parse(phone);
                }
                catch (FormatException f)
                {
                    ok = false;
                }
            }

            return ok;
        }

        public bool correctEmail()
        {
            bool ok = true;

            string email = txtAddress.Text;
            if (email != null)
            {
                if (email.Length < 20)
                {
                    if (email.Contains("'"))
                    {
                        ok = false;
                    }
                    else
                    {
                        int cont = 0;
                        for (int i = 0; i < email.Length; i++)
                        {
                            if (email[i].Equals('@') || email[i].Equals('.'))
                            {
                                cont++;
                            }
                        }

                        if (cont > 1)
                        {
                            email = txtEmail.Text;
                        }
                    }
                }
                else
                {
                    ok = false;
                }
            }
            else
            {
                ok = false;
            }

            return ok;
        }

        public bool okData()
        {
            bool ok = true;

            return ok;
        }
    }
}