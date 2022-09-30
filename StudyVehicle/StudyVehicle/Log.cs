using System.Data;
using System.Data.SqlClient;
using StudyVehicle.Models;

namespace StudyVehicle
{
    public class Log
    {
        public static void Insert(string exception, Vehicle vehicle, string method)
        {
            var info = string.Empty;

            try
            {
                if (vehicle != null)
                    info = method + " | " + "Brand : " + vehicle.Brand + " ; " +
                           "Model : " + vehicle.Model + " ; " +
                           "CapacityKG : " + vehicle.CapacityKg + " ; " +
                           "CapacityM3 : " + vehicle.CapacityM3 + " ; " +
                           "Plate : " + vehicle.Plate + " ; " +
                           "Type : " + vehicle.Type + " ; " +
                           "ModelYear : " + vehicle.ModelYear + " ; " +
                           "Color : " + vehicle.Color + " ; ";
                else
                    info = method;
            }
            catch (Exception e)
            {
                info = method + " | " +e.ToString();
            }


            var con = SqlConn.Connection();
            if (con.State != ConnectionState.Open)
                con.Open();

            try
            {
                var now = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");


                var query =
                    "Insert Into [Log] (Properties, Exception, CreateDate) Values (@Properties, @Exception, @CreateDate)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Properties", info);
                cmd.Parameters.AddWithValue("@Exception", exception);
                cmd.Parameters.AddWithValue("@CreateDate", now);


                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
        }
    }
}