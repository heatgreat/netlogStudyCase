using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace StudyVehicle
{
    public class SqlConn
    {
        private static string _dataSource, _catalog, _id, _password;
        private static SqlConnection connection;
        /// <summary>
        /// DB test connection 
        /// </summary>
        /// <returns></returns>
        public static SqlConnection Connection()
        {
            try
            {


                var t = XDocument.Load("config.xml");
                foreach (var item in t.Root.Elements("Sql"))
                {
                    _dataSource = item.Element("DataSource").Value;
                    _catalog = item.Element("Database").Value;
                    _id = item.Element("UserId").Value;
                    _password = item.Element("Password").Value;
                }


                connection = new SqlConnection("Data Source =" + _dataSource + "; " +
                                               "Initial Catalog =" + _catalog + "; " +
                                               "uid=" + _id + "; " +
                                               "password=" + _password + "; ");
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    connection.Close();
                    SqlConnection.ClearPool(connection);
                    return null;
                }


                return connection;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void ConnectionClose()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
                connection.Close();

        }
    }
}
