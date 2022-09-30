using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyVehicle.Models;

namespace StudyVehicle.Controllers
{
    public class VehicleController : Controller
    {

        
        //Tamam
        [HttpPost]
        public async Task<ActionResult<bool>> AddVehicle([FromBody]Vehicle vehicle)
        {
            var conn = SqlConn.Connection();
            if (conn == null)
                throw new Exception("Sql Connection Error!");

            if (conn.State != ConnectionState.Open)
                conn.Open();

            var vehicleList = new List<Vehicle>();
            try
            {
                var now = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

                var query = "Insert Into Vehicle (Brand, Model, CapacityKg, CapacityM3, Plate, Type, ModelYear, Color, CreateDate) Values (@Brand, @Model, @CapacityKg, @CapacityM3, @Plate, @Type, @ModelYear, @Color, @CreateDate)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Brand", vehicle.Brand);
                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@CapacityKg", vehicle.CapacityKg);
                cmd.Parameters.AddWithValue("@CapacityM3", vehicle.CapacityM3);
                cmd.Parameters.AddWithValue("@Plate", vehicle.Plate);
                cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                cmd.Parameters.AddWithValue("@ModelYear", vehicle.ModelYear);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.Parameters.AddWithValue("@CreateDate", now);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Log.Insert(e.ToString(), vehicle, "AddVehicle");
                throw new Exception(e.ToString());
            }

            return true;
        }


        [HttpPost]
        public async Task<ActionResult<bool>> EditVehicle([FromBody] Vehicle vehicle)
        {
            var conn = SqlConn.Connection();
            if (conn == null)
                throw new Exception("Sql Connection Error!");

            if (conn.State != ConnectionState.Open)
                conn.Open();

            var vehicleList = new List<Vehicle>();
            try
            {
                var query = "Update Vehicle Set Brand = @Brand, Model = @Model, CapacityKg = @CapacityKg, CapacityM3 = @CapacityM3, Type = @Type, ModelYear = @ModelYear, Color = @Color  Where Plate = @Plate";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Brand", vehicle.Brand);
                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@CapacityKg", vehicle.CapacityKg);
                cmd.Parameters.AddWithValue("@CapacityM3", vehicle.CapacityM3);
                cmd.Parameters.AddWithValue("@Plate", vehicle.Plate);
                cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                cmd.Parameters.AddWithValue("@ModelYear", vehicle.ModelYear);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Log.Insert(e.ToString(), vehicle, "EditVehicle");
                throw new Exception(e.ToString());
            }

            return true;
        }

        // Tamam
        [HttpPost]
        public async Task<ActionResult<bool>> DeleteVehicle([FromBody] Vehicle vehicle)
        {
            var conn = SqlConn.Connection();
            if (conn == null)
                throw new Exception("Sql Connection Error!");

            if (conn.State != ConnectionState.Open)
                conn.Open();

            try
            {
                var query = "Delete From Vehicle Where Plate = @Plate";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Plate", vehicle.Plate);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Log.Insert(e.ToString(), null, "DeleteVehicle" + " Plate : " +vehicle.Plate);
                throw new Exception(e.ToString());
            }
            
            return true;
        }


        /// Tamam
        [HttpGet]
        public async Task<ActionResult<List<Vehicle>>> ListVehicle()
        {
            var conn = SqlConn.Connection();
            if (conn == null)
                throw new Exception("Sql Connection Error!");

            if (conn.State != ConnectionState.Open)
                conn.Open();

            var vehicleList = new List<Vehicle>();
            try
            {
                var query = "Select * From Vehicle";
                SqlCommand cmd = new SqlCommand(query, conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var vehicle = new Vehicle();
                    vehicle.Brand = dr["Brand"].ToString();
                    vehicle.Model = dr["Model"].ToString();
                    vehicle.CapacityKg = Convert.ToInt32(dr["CapacityKg"].ToString());
                    vehicle.CapacityM3 = Convert.ToInt32(dr["CapacityM3"].ToString());
                    vehicle.Plate = dr["Plate"].ToString();
                    vehicle.Type = dr["Type"].ToString();
                    vehicle.ModelYear = Convert.ToInt32(dr["ModelYear"].ToString());
                    vehicle.Color = dr["Color"].ToString();
                    vehicleList.Add(vehicle);
                }
            }
            catch (Exception e)
            {
                Log.Insert(e.ToString(),null, "ListVehicle");
                throw new Exception(e.ToString());
            }
            


            return vehicleList;
        }

        //Tamam
        [HttpPost]
        public async Task<ActionResult<List<Vehicle>>> FindVehicle([FromBody] Vehicle vehicle)
        {
            var conn = SqlConn.Connection();
            if (conn == null)
                throw new Exception("Sql Connection Error!");

            if (conn.State != ConnectionState.Open)
                conn.Open();

            var vehicleList = new List<Vehicle>();
            try
            {
                var query = "Select * From Vehicle Where Plate = @Plate";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Plate", vehicle.Plate);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var vehicles = new Vehicle();
                    vehicles.Brand = dr["Brand"].ToString();
                    vehicles.Model = dr["Model"].ToString();
                    vehicles.CapacityKg = Convert.ToInt32(dr["CapacityKg"].ToString());
                    vehicles.CapacityM3 = Convert.ToInt32(dr["CapacityM3"].ToString());
                    vehicles.Plate = dr["Plate"].ToString();
                    vehicles.Type = dr["Type"].ToString();
                    vehicles.ModelYear = Convert.ToInt32(dr["ModelYear"].ToString());
                    vehicles.Color = dr["Color"].ToString();
                    vehicleList.Add(vehicles);
                }
            }
            catch (Exception e)
            {
                Log.Insert(e.ToString(), null, "ListVehicle");
                throw new Exception(e.ToString());
            }
            return vehicleList;
        }
    }
}
