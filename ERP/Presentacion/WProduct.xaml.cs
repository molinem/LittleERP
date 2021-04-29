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
    public partial class WProduct : Window
    {
        private char optionSelected;
        private int idProductSelected;

        public WProduct(char option)
        {
            //New Product
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

            //Load tags (same that products)
            Customer.manager().startListTags(listTagsOriginal);
        }

        public WProduct(char option, int idProduct, String name, Double price, int amount)
        {
            //Modify Product
            InitializeComponent();
            optionSelected = option;
            idProductSelected = idProduct;

            //Initial configuration
            this.Title = "Modificar Producto";
            txtTitleProduct.Content = " MODIFICAR PRODUCTO";
            txtNameProduct.MaxLength = 30;
            txtPriceProduct.MaxLength = 7;
            txtAmountProduct.MaxLength = 7;

            txtNameProduct.Text = name;
            txtPriceProduct.Text = price.ToString();
            txtAmountProduct.Text = amount.ToString();

            Product.manager().refillComboComposition(cboCompositionProduct);
            Product.manager().refillComboSize(cboSizeProduct);
            Product.manager().refillAllCombos(idProduct, cboCompositionProduct, cboSizeProduct);

            Product.manager().loadTagsList(listTagsOriginal, listTagsSelected, idProduct);
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
            double p = 0,priceFormatted;
            int composition, size;
            String price;
            
            if (!txtAmountProduct.Text.Equals("") && !txtNameProduct.Text.Trim().Equals("") && !txtPriceProduct.Equals("") && !listTagsSelected.Items.IsEmpty)
            {
                if (optionSelected.Equals('+'))
                {
                    if (cboCompositionProduct.SelectedIndex > 0 && cboSizeProduct.SelectedIndex > 0)
                    {
                        if ((double.TryParse(txtPriceProduct.Text, out p) && (double.Parse(txtPriceProduct.Text) > 0)) && (int.TryParse(txtAmountProduct.Text, out num) && int.Parse(txtAmountProduct.Text) > 0))
                        {
                            price = txtPriceProduct.Text.Replace('.', ',');
                            priceFormatted = double.Parse(price);
                            
                            //Composition and size from combobox
                            composition = Auxiliary.obtainSelectedOnComboBox(cboCompositionProduct);
                            size = Auxiliary.obtainSelectedOnComboBox(cboSizeProduct);

                            //New product with data
                            Product pr = new Product(txtNameProduct.Text, composition, size, priceFormatted, int.Parse(txtAmountProduct.Text));

                            //Insert new product
                            Product.manager().createProduct(pr);

                            //Insert tag product
                            Product.manager().add_tags_new_products(listTagsSelected.Items);

                            MessageBox.Show("Producto creado correctamente", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
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
                        //Modify
                        price = txtPriceProduct.Text.Replace('.', ',');
                        priceFormatted = double.Parse(price);

                        //Composition and size from combobox
                        composition = Auxiliary.obtainSelectedOnComboBox(cboCompositionProduct);
                        size = Auxiliary.obtainSelectedOnComboBox(cboSizeProduct);

                        //Object Product
                        Product pModify = new Product(idProductSelected, txtNameProduct.Text, composition, size, priceFormatted, int.Parse(txtAmountProduct.Text));

                        //Modify Product
                        Product.manager().modifyProduct(pModify);

                        //Tags for this product
                        Product.manager().updateTags(pModify, listTagsSelected.Items);

                        MessageBox.Show("Producto actualizado correctamente", "LittleERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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
