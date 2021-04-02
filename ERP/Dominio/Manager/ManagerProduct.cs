using ERP.Persistencia;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void createProduct(Product p)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle createProduct = new ConnectOracle();
            connection = createProduct.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("INSERT INTO PRODUCTS(IDPRODUCT,NAME,REFCOMPOSITION,REFSIZES,PRICE,AMOUNT,DELETED) VALUES(IDPRODUCT.NEXTVAL,:name,:refcomposition,:refsizes,:price,:amount,:deleted)", connection);
            cmd.Parameters.Add(new OracleParameter("name", p.getName()));
            cmd.Parameters.Add(new OracleParameter("refcomposition", p.getRefComposition()));
            cmd.Parameters.Add(new OracleParameter("refsizes", p.getRefSize()));
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
    }
}
