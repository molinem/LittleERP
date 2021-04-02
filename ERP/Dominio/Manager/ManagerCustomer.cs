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
    class ManagerCustomer
    {
        private DataTable table;

        public ManagerCustomer()
        {
            table = new DataTable();
        }

        public DataTable obtainCustomers()
        {
            return table;
        }

        public void readAllCustomers()
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle allCustomers = new ConnectOracle();
            connection = allCustomers.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("SELECT C.IDCUSTOMER,C.NAME,C.SURNAME,C.ADDRESS,C.PHONE,C.EMAIL,S.STATE FROM CUSTOMERS C, ZIPCODESCITIES Z, STATES S WHERE C.REFZIPCODESCITIES = Z.IDZIPCODESCITIES AND Z.REFSTATE = S.IDSTATE AND C.DELETED=0", connection);
            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data,"customers");

            table = data.Tables["customers"];
            connection.Close();
        }

        public void readCustomer(Customer c)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle searchEspecifyCustomer = new ConnectOracle();
            connection = searchEspecifyCustomer.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("SELECT * FROM CUSTOMERS WHERE IDCUSTOMER=:idCustomer", connection);
            cmd.Parameters.Add(new OracleParameter("idCustomer", c.getIdCustomer()));

            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data, "customers");

            connection.Close();
            table = data.Tables["customers"];

            //create new customer object
            DataRow row = table.Rows[0];
            c.setName(Convert.ToString(row["NAME"]));
            c.setSurname(Convert.ToString(row["SURNAME"]));
            c.setAddress(Convert.ToString(row["ADDRESS"]));
            c.setPhoneNumber(Convert.ToInt32(row["PHONE"]));
            c.setEmail(Convert.ToString(row["EMAIL"]));
            c.setZipCode(Convert.ToInt32(row["REFZIPCODESCITIES"]));
        }

        public void createCustomer(Customer c)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle createCustomer = new ConnectOracle();
            connection = createCustomer.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("INSERT INTO CUSTOMERS(IDCUSTOMER,NAME,SURNAME,ADDRESS,PHONE,EMAIL,DELETED,REFZIPCODESCITIES) VALUES(ID_CUSTOMER.NEXTVAL,:name,:surname,:address,:phone,:email,:deleted,:zipCode)", connection);
            cmd.Parameters.Add(new OracleParameter("name", c.getName()));
            cmd.Parameters.Add(new OracleParameter("surname", c.getSurname()));
            cmd.Parameters.Add(new OracleParameter("address", c.getAddress()));
            cmd.Parameters.Add(new OracleParameter("phone", c.getPhoneNumber()));
            cmd.Parameters.Add(new OracleParameter("email", c.getEmail()));
            cmd.Parameters.Add(new OracleParameter("deleted", 0));
            cmd.Parameters.Add(new OracleParameter("zipCode", c.getZipCode()));

            cmd.ExecuteNonQuery();

            connection.Close();
        }


        public void modifyCustomer(Customer c) 
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle modifyCustomer = new ConnectOracle();
            connection = modifyCustomer.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("UPDATE CUSTOMERS SET NAME=:name, SURNAME=:surname, ADDRESS=:address, PHONE=:phone, EMAIL=:email, REFZIPCODESCITIES:=zipCode WHERE IDCUSTOMER=:idCustomer",connection);
            cmd.Parameters.Add(new OracleParameter("name", c.getName()));
            cmd.Parameters.Add(new OracleParameter("surname", c.getSurname()));
            cmd.Parameters.Add(new OracleParameter("address", c.getAddress()));
            cmd.Parameters.Add(new OracleParameter("phone", c.getPhoneNumber()));
            cmd.Parameters.Add(new OracleParameter("email", c.getEmail()));
            cmd.Parameters.Add(new OracleParameter("zipCode", c.getZipCode()));
            cmd.Parameters.Add(new OracleParameter("idCustomer", c.getIdCustomer()));

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void deleteCustomer(Customer c)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle deleteCustomer = new ConnectOracle();
            connection = deleteCustomer.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("UPDATE CUSTOMERS SET DELETED=1 WHERE IDCUSTOMER=:idCustomer", connection);
            cmd.Parameters.Add(new OracleParameter("idCustomer", c.getIdCustomer()));

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
