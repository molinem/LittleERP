using ERP.Persistencia;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ERP.Dominio.Manager
{
    class ManagerCustomer
    {
        private DataTable table;
        public ObservableCollection<string> list = new ObservableCollection<string>();
        public ManagerCustomer()
        {
            table = new DataTable();
        }

        public DataTable obtainData()
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

            OracleCommand cmd = new OracleCommand("SELECT C.IDCUSTOMER,C.DNI,C.NAME,C.SURNAME,C.ADDRESS,C.PHONE,C.EMAIL,S.STATE FROM CUSTOMERS C, ZIPCODESCITIES Z, STATES S WHERE C.REFZIPCODESCITIES = Z.IDZIPCODESCITIES AND Z.REFSTATE = S.IDSTATE AND C.DELETED=0 ORDER BY C.IDCUSTOMER", connection);
            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data,"customers");

            table = data.Tables["customers"];
            connection.Close();
        }

        public void readAllZipCodes()
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle allZipCodes = new ConnectOracle();
            connection = allZipCodes.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("SELECT Z.IDZIPCODESCITIES,ZP.ZIPCODE,C.CITY FROM ZIPCODESCITIES Z,CITIES C,ZIPCODES ZP  WHERE  Z.REFCITY=C.IDCITY  AND Z.REFZIPCODE=ZP.IDZIPCODE ORDER BY C.CITY ASC", connection);
            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data, "zipcodes");

            table = data.Tables["zipcodes"];
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
            //Customer(String name, String dni, String surname, String address, int phone_number, String email, int zip_code)
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle createCustomer = new ConnectOracle();
            connection = createCustomer.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("INSERT INTO CUSTOMERS VALUES(ID_CUSTOMER.NEXTVAL,:name,:surname,:address,:phone,:email,0,:zipCode,:dni)", connection);
            cmd.Parameters.Add(new OracleParameter("name", c.getName()));
            cmd.Parameters.Add(new OracleParameter("surname", c.getSurname()));
            cmd.Parameters.Add(new OracleParameter("address", c.getAddress()));
            cmd.Parameters.Add(new OracleParameter("phone", c.getPhoneNumber()));
            cmd.Parameters.Add(new OracleParameter("email", c.getEmail()));
            cmd.Parameters.Add(new OracleParameter("zipCode", c.getZipCode()));
            cmd.Parameters.Add(new OracleParameter("dni", c.getDni()));

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


        public void refill(ComboBox combo,String sql,String first,String table)
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

        public void startDataGridCustomers(DataGrid dgCustomers)
        {
            readAllCustomers();
            DataTable dtClientes = obtainData();
            dgCustomers.ItemsSource = dtClientes.DefaultView;
        }

        //--------------------------------------------------------------------ComboBox----------------------------------------------------------------------------------
        public void refillComboRegion(ComboBox combo)
        {
            String sql = "SELECT IDREGION, REGION FROM REGIONS ORDER BY IDREGION";
            refill(combo, sql, "--- Seleccionar --", "COMBOCOMUNIDAD");
        }

        public void refillComboState(ComboBox combo,int region)
        {
            String sql = "SELECT IDSTATE, STATE FROM STATES WHERE REFREGION=" + region + " ORDER BY IDSTATE";
            refill(combo, sql, "--- Seleccionar --", "COMBOPROVINCIA");
        }

        public void refillComboCP(ComboBox combo, int state, int city)
        {
            String sql = "SELECT CP.IDZIPCODE, CP.ZIPCODE FROM ZIPCODES CP, ZIPCODESCITIES Z WHERE CP.IDZIPCODE=Z.REFZIPCODE AND " +
            "Z.REFCITY=" + city + " AND Z.REFSTATE=" + state + " ORDER BY CP.ZIPCODE";
            refill(combo, sql, "--- Seleccionar --", "COMBOZIPCODE");
        }

        public void refillComboCities(ComboBox combo, int state)
        {
            String sql = "SELECT DISTINCT C.IDCITY, C.CITY FROM CITIES C, ZIPCODESCITIES Z WHERE C.IDCITY=Z.REFCITY AND Z.REFSTATE=" + state + " ORDER BY C.IDCITY";
            refill(combo, sql, "--- Seleccionar --", "COMBOCIUDAD");
        }

        public int searchZipCodeCities(int state, int city, int zipcode)
        {
            //idref on customers
            String condition = "REFCITY=" + city + " AND REFSTATE=" + state + " AND REFZIPCODE=" + zipcode;
            String table = "ZIPCODESCITIES";
            String column = "IDZIPCODESCITIES";

            ConnectOracle cn = new ConnectOracle();
            decimal datoId = (decimal)cn.DLookUp(column, table, condition);
            int id = (int)datoId;

            return id;
        }


        //--------------------------------------------------------------------TAGS----------------------------------------------------------------------------------
        public void readAllTags()
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle allTags = new ConnectOracle();
            connection = allTags.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("SELECT NAME FROM TAGS ORDER BY IDTAG", connection);
            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data, "tags");

            table = data.Tables["tags"];
            connection.Close();
        }

        public void createTagCustomer(int refIdTag, int refIdCustomer)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle createTagCustomer = new ConnectOracle();
            connection = createTagCustomer.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("INSERT INTO TAGS_CUSTOMERS VALUES(:idtag,:idCustomer)", connection);
            cmd.Parameters.Add(new OracleParameter("idtag", refIdTag));
            cmd.Parameters.Add(new OracleParameter("idCustomer", refIdCustomer));

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void startListTags(ListBox listTags)
        {
            readAllTags();
            DataTable dtTags = obtainData();

            foreach (DataRow row in dtTags.Rows)
            {
                if (!listTags.Items.Contains(row["NAME"]))
                {
                    listTags.Items.Add(row["NAME"]);
                }
            }
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

            //Obtain id tag if we have the name
            DataRow row = table.Rows[0];
            int idTag = Convert.ToInt32(row["IDTAG"]);
            return idTag;
        }

            public void add_tags_customer(ItemCollection it)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle tags = new ConnectOracle();
            connection = tags.getConnection();

            connection.Open();

            OracleCommand cmd = new OracleCommand("SELECT MAX(IDCUSTOMER) AS ID FROM CUSTOMERS", connection);

            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data, "customers");

            connection.Close();
            table = data.Tables["customers"];

            //Obtain last id inserted (customers)
            DataRow row = table.Rows[0];
            int customerID = Convert.ToInt32(row["ID"]);

            //-------------Procedure TAGS--------------------
            String tagSelected;
            int idTagSelected;
            //Obtain tags, search id and insert
            foreach(object item in it) 
            {
                //Tag selected
                tagSelected = item.ToString();
                //Tag id
                idTagSelected = obtainTagID(tagSelected);
                //Insert on table TAGS_CUSTOMERS
                createTagCustomer(idTagSelected, customerID);
            }
        }

    }
}
