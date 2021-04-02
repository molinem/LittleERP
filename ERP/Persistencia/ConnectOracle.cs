﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Persistencia
{
    class ConnectOracle
    {
        ////////////////////////////////////////////////////////////
        ////////////////////  DRIVER //////////////////////
        ////////////////////////////////////////////////////////////
        const String driver = "Data Source=(DESCRIPTION ="
        + "(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = LOCALHOST)(PORT = 1521)))"
        + "(CONNECT_DATA = (SERVICE_NAME = XE))); "
        + "User Id=ERP; Password=ERP;";


        public OracleConnection getConnection() {
            OracleConnection objConnection;
            objConnection = new OracleConnection(driver);
            return objConnection;
        }

        public DataSet getAllData(String table,String order)
        {
            OracleConnection connection;
            DataSet requestQuery = new DataSet();

            connection = getConnection();
            connection.Open();

            OracleCommand cmd = new OracleCommand("SELECT * FROM :table ORDER BY :order", connection);
            cmd.Parameters.Add(new OracleParameter("table",table));
            cmd.Parameters.Add(new OracleParameter("order", order));

            cmd.ExecuteNonQuery();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(requestQuery);
            connection.Close();

            return requestQuery;
        }

        public void insertData(String data, String table)
        {
            OracleConnection connection;
            DataSet requestQuery = new DataSet();

            connection = getConnection(); ;
            connection.Open();

            OracleCommand cmd = new OracleCommand("INSERT INTO :table VALUES :data * FROM :table", connection);
            cmd.Parameters.Add(new OracleParameter("table", table));
            cmd.Parameters.Add(new OracleParameter("data", data));

            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }


}