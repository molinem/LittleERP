using ERP.Dominio;
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
    public partial class WProduct : Window
    {
        private char optionSelected;
        private int idProductSelected;

        public WProduct(char option)
        {
            //New Customer
            InitializeComponent();
            optionSelected = option;

            //Initial configuration
            txtNameProduct.MaxLength = 30;
            txtPriceProduct.MaxLength = 7;
            txtAmountProduct.MaxLength = 7;

            //Load combobox
            //Composition
            Product.manager().refillComboComposition(cboCompositionProduct);
            //Size
            Product.manager().refillComboSize(cboSizeProduct);

            //Load tags
            Customer.manager().startListTags(listTagsOriginal);

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

        //--------------------------------------------------------------------Buttons----------------------------------------------------------------------------------
        private void btnCleanFields(object sender, RoutedEventArgs e)
        {
            txtNameProduct.Text = "";
            txtPriceProduct.Text = "";
            txtAmountProduct.Text = "";

            Product.manager().refillComboComposition(cboCompositionProduct);
            Product.manager().refillComboSize(cboSizeProduct);
            listTagsOriginal.Items.Clear();
            listTagsSelected.Items.Clear();
            Customer.manager().startListTags(listTagsOriginal);

            //Reset ComboBox
            cboCompositionProduct.SelectedIndex = 0;
            cboSizeProduct.SelectedIndex = 0;
        }

        private void btnNewProduct(object sender, RoutedEventArgs e)
        {
            int num = 0;
            double p = 0;
            
            if (!txtAmountProduct.Text.Equals("") && !txtNameProduct.Text.Trim().Equals("") && !txtPriceProduct.Equals(""))
            {
                if (optionSelected.Equals('+'))
                {
                    if (cboCompositionProduct.SelectedIndex > 0 && cboSizeProduct.SelectedIndex > 0)
                    {
                        if ((double.TryParse(txtPriceProduct.Text, out p) && (double.Parse(txtPriceProduct.Text) > 0)) && (int.TryParse(txtAmountProduct.Text, out num) && int.Parse(txtAmountProduct.Text) > 0))
                        {
                            String price = txtPriceProduct.Text.Replace('.', ',');
                            double priceFormatted = double.Parse(price);
                            Product pr = new Product(txtNameProduct.Text, priceFormatted, int.Parse(txtAmountProduct.Text));


                            //Obtain Composition
                            DataRowView row = (DataRowView)cboCompositionProduct.SelectedItem;/*********************/
                            DataRow data = row.Row;
                            Object[] objData = data.ItemArray;
                            int composition = (int)objData[0];

                            //Obtain Size
                            DataRowView row2 = (DataRowView)cboSizeProduct.SelectedItem;
                            DataRow data2 = row2.Row;
                            data2 = row2.Row;
                            Object[] objData2 = data2.ItemArray;
                            int size = (int)objData2[0];

                            String composition2 = "";
                            String size2 = "";
                            //Insert new product
                            Product.manager().createProduct(pr, composition2, size2);

                            //Insert tag product
                            Product.manager().add_tags_new_products(listTagsSelected.Items);
                        }
                        else
                        {
                            MessageBox.Show("El precio y la cantidad deben de ser números positivos", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Comprueba los campos", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    if ((double.TryParse(txtPriceProduct.Text, out p) && (double.Parse(txtPriceProduct.Text) > 0)) && (int.TryParse(txtAmountProduct.Text, out num) && int.Parse(txtAmountProduct.Text) > 0))
                    {
                        //product.modifProduct(txtID.Text, txtName.Text, cbComposicion.GetItemText(cbComposicion.SelectedItem), cbSizes.GetItemText(cbSizes.SelectedItem), txtPrice.Text.Replace('.', ','), txtAmount.Text);
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("El precio y la cantidad deben de ser números positivos", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Comprueba los campos", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
