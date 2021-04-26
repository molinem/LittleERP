using ERP.Persistencia;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ERP.Dominio.Manager
{
    class ManagerProduct
    {
        private DataTable table;

        public ManagerProduct()
        {
            table = new DataTable();
        }
        public DataTable obtainProducts()
        {
            return table;
        }

        public void readAllProducts()
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle allCustomers = new ConnectOracle();
            connection = allCustomers.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("SELECT P.IDPRODUCT,P.NAME,C.COMPOSITION,S.SIZENAME,P.PRICE,P.AMOUNT FROM PRODUCTS P, COMPOSITIONS C, SIZES S WHERE P.REFCOMPOSITION = C.IDCOMPOSITION AND P.REFSIZES = S.IDSIZE AND P.DELETED = 0", connection);
            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data, "products");

            table = data.Tables["products"];
            connection.Close();
        }

        public void readProduct(Product p)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle searchEspecifyProduct = new ConnectOracle();
            connection = searchEspecifyProduct.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("SELECT * FROM PRODUCTS WHERE IDPRODUCT=:idProduct", connection);
            cmd.Parameters.Add(new OracleParameter("idProduct", p.getIdProduct()));

            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data, "products");

            connection.Close();
            table = data.Tables["products"];

            //create new product object
            DataRow row = table.Rows[0];
            p.setName(Convert.ToString(row["NAME"]));
            p.setRefComposition(Convert.ToInt32(row["REFCOMPOSITION"]));
            p.setRefSize(Convert.ToInt32(row["REFSIZES"]));
            p.setPrice((float)Convert.ToDouble(row["PRICE"]));//********************************************
            p.setAmount(Convert.ToInt32(row["AMOUNT"]));
        }

        public void createProduct(Product p,String compositionName,String sizeName)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle createProduct = new ConnectOracle();
            connection = createProduct.getConnection();

            connection.Open();

            //Obtain refComposition by name
           // int refComposition = obtainComposition(compositionName);
            //Obtain refSize by name
            //int refSize = obtainSize(sizeName);

            OracleCommand cmd = new OracleCommand("INSERT INTO PRODUCTS(IDPRODUCT,NAME,REFCOMPOSITION,REFSIZES,PRICE,AMOUNT,DELETED) VALUES(IDPRODUCT.NEXTVAL,:name,:refcomposition,:refsizes,:price,:amount,:deleted)", connection);
            cmd.Parameters.Add(new OracleParameter("name", p.getName()));
            cmd.Parameters.Add(new OracleParameter("refcomposition", p.getRefComposition()));
            cmd.Parameters.Add(new OracleParameter("refsizes", p.getRefSize()));
            cmd.Parameters.Add(new OracleParameter("price", p.getPrice()));
            cmd.Parameters.Add(new OracleParameter("amount", p.getAmount()));
            cmd.Parameters.Add(new OracleParameter("deleted", 0));

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void modifyProduct(Product p)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle modifyProduct = new ConnectOracle();
            connection = modifyProduct.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("UPDATE PRODUCTS SET NAME=:name, REFCOMPOSITION=:refComposition, REFSIZES=:refSizes, PRICE=:price, AMOUNT=:amount WHERE IDPRODUCT=:idProduct", connection);
            cmd.Parameters.Add(new OracleParameter("name", p.getName()));
            cmd.Parameters.Add(new OracleParameter("refComposition", p.getRefComposition()));
            cmd.Parameters.Add(new OracleParameter("refSizes", p.getRefSize()));
            cmd.Parameters.Add(new OracleParameter("price", p.getPrice()));
            cmd.Parameters.Add(new OracleParameter("amount", p.getAmount()));
            cmd.Parameters.Add(new OracleParameter("idProduct", p.getIdProduct()));

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void deleteProduct(Product p)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle deleteProduct = new ConnectOracle();
            connection = deleteProduct.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("UPDATE PRODUCTS SET DELETED=1 WHERE IDPRODUCT=:idProduct", connection);
            cmd.Parameters.Add(new OracleParameter("idProduct", p.getIdProduct()));

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        //Obtain id with the name of composition
        public int obtainComposition(String name)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle searchCompositionId = new ConnectOracle();
            connection = searchCompositionId.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("SELECT IDCOMPOSITION FROM COMPOSITIONS WHERE COMPOSITION=:name", connection);
            cmd.Parameters.Add(new OracleParameter("name", name));

            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data, "composition");

            connection.Close();
            table = data.Tables["composition"];

            DataRow row = table.Rows[0];
            int idComposition = Convert.ToInt32(row["IDCOMPOSITION"]);
            return idComposition;
        }

        //Obtain id with the name of sizes
        public int obtainSize(String name)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle searchCompositionId = new ConnectOracle();
            connection = searchCompositionId.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("SELECT IDSIZE FROM SIZES WHERE SIZENAME=:name", connection);
            cmd.Parameters.Add(new OracleParameter("name", name));

            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data, "sizes");

            connection.Close();
            table = data.Tables["sizes"];

            DataRow row = table.Rows[0];
            int idSize = Convert.ToInt32(row["IDSIZE"]);
            return idSize;
        }

        public void refill(ComboBox combo, String sql, String first, String table)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle allZipCodes = new ConnectOracle();
            connection = allZipCodes.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.ExecuteNonQuery();

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data, table);

            DataTable ttablas = data.Tables[table];

            if (!first.Equals(""))
            {
                DataRow newrow = ttablas.NewRow();
                newrow[0] = 0;
                newrow[1] = first;
                ttablas.Rows.InsertAt(newrow, 0);
            }

            combo.ItemsSource = ttablas.AsDataView();
            combo.DisplayMemberPath = ttablas.Columns[1].ToString();
            combo.SelectedIndex = 0;

            connection.Close();
        }

        //--------------------------------------------------------------------DataGrid + Filters----------------------------------------------------------------------------------
        public void startDataGridProduct(DataGrid dgProduct)
        {
            readAllProducts();
            DataTable dtCustomers = obtainProducts();
            dgProduct.ItemsSource = dtCustomers.DefaultView;
        }

        //--------------------------------------------------------------------ComboBox----------------------------------------------------------------------------------
        public void refillComboComposition(ComboBox combo)
        {
            String sql = "SELECT IDCOMPOSITION, COMPOSITION FROM COMPOSITIONS ORDER BY IDCOMPOSITION";
            refill(combo, sql, "--- Seleccionar --", "COMBOCOMPOSITION");
        }

        public void refillComboSize(ComboBox combo)
        {
            String sql = "SELECT IDSIZE, SIZENAME FROM SIZES ORDER BY IDSIZE";
            refill(combo, sql, "--- Seleccionar --", "COMBOCOMPOSITION");
        }

        //--------------------------------------------------------------------TAGS----------------------------------------------------------------------------------
        public void createTagProduct(int refIdTag, int refIdProduct)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle createTagCustomer = new ConnectOracle();
            connection = createTagCustomer.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("INSERT INTO TAGS_PRODUCTS VALUES(:idtag,:idProduct)", connection);
            cmd.Parameters.Add(new OracleParameter("idtag", refIdTag));
            cmd.Parameters.Add(new OracleParameter("idProduct", refIdProduct));

            cmd.ExecuteNonQuery();

            connection.Close();
        }


        public int obtainTagID(String nameTag)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle searchEspecifyCustomer = new ConnectOracle();
            connection = searchEspecifyCustomer.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("SELECT IDTAG FROM TAGS WHERE NAME=:nameTag", connection);
            cmd.Parameters.Add(new OracleParameter("nameTag", nameTag));

            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data, "tags");

            connection.Close();
            table = data.Tables["tags"];

            //-- Obtain id tag if we have the name
            DataRow row = table.Rows[0];
            int idTag = Convert.ToInt32(row["IDTAG"]);
            return idTag;
        }

        //Only for new Products
        public void add_tags_new_products(ItemCollection it)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle tags = new ConnectOracle();
            connection = tags.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("SELECT MAX(IDPRODUCT) AS ID FROM PRODUCTS", connection);

            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data, "products");

            connection.Close();
            table = data.Tables["products"];

            //Obtain last id inserted (products)
            DataRow row = table.Rows[0];
            int productID = Convert.ToInt32(row["ID"]);

            //-------------Procedure TAGS--------------------
            String tagSelected;
            int idTagSelected;
            //Obtain tags, search id and insert
            foreach (object item in it)
            {
                //Tag selected
                tagSelected = item.ToString();
                //Tag id
                idTagSelected = obtainTagID(tagSelected);
                //Insert on table TAGS_CUSTOMERS
                createTagProduct(idTagSelected, productID);
            }
        }
    }
}
