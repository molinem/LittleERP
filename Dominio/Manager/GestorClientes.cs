using ERP.Presentacion;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio.Gestores
{
    class GestorClientes
    {
        private DataTable tabla;

        public GestorClientes()
        {
            tabla = new DataTable();
        }
        public DataTable getClientes()
        {
            return tabla;
        }

        public void readAllClients()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getAllData("CUSTOMERS", "IDCUSTOMER");

            tabla = data.Tables["CUSTOMERS"];
        }

        public void readClient(String idCustomer)
        {
            OracleConnection connection;
            DataSet data = new DataSet();
            ConnectOracle searchEspecifyClient = new ConnectOracle();
            connection = searchEspecifyClient.getConnection();

            OracleCommand cmd = new OracleCommand("SELECT * FROM CUSTOMERS WHERE IDCUSTOMER=:idCustomer", connection);
            cmd.Parameters.Add(new OracleParameter("idCustomer", idCustomer));

            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(data);

            tabla = data.Tables["CUSTOMERS"];

            //create new customer object
            Customer c = new Customer();
            c.setId(idCustomer);

            DataRow row = tabla.Rows[0];
            c.setNombre(Convert.ToString(row["Nombre"]));
            c.setApellido1(Convert.ToString(row["Apellido1"]));
            c.setApellido2(Convert.ToString(row["Apellido2"]));

        }
    }
}
